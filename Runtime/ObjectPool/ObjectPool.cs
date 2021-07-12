using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Reuses objects from a shared pool to prevent instantiating new objects.
    /// The object pool can have a set capacity or it can grow in size.
    /// Optionally, objects that are currently active can be reused when the
    /// pool has reached capacity.
    /// </summary>
    /// <typeparam name="T">The type of object to pool.</typeparam>
    public sealed class ObjectPool<T> : IObjectPool<T> where T: class, IDisposable
    {
        /// <summary>
        /// A function delegate that creates a new instance of <typeparamref name="T"/>.
        /// </summary>
        public delegate T Generator();

        /// <summary>
        /// The function delegate that generates a new object.
        /// </summary>
        public Generator generator { get; private set; }

        /// <summary>
        /// The list of all objects waiting to be reused.
        /// </summary>
        public Queue<T> pool { get; private set; }

        /// <summary>
        /// The list of objects currently being used.
        /// </summary>
        public List<T> activeItems { get; private set; }

        /// <summary>
        /// The maximum number of objects that can be generated.
        /// </summary>
        public int maxCapacity { get; private set; }

        /// <summary>
        /// Whether active objects should be reused when the object pool has
        /// reached capacity.
        /// </summary>
        public bool reuseActive { get; private set; }

        /// <summary>
        /// The number of objects currently being used.
        /// </summary>
        public int ActiveCount => this.activeItems.Count;

        /// <summary>
        /// The number of objects available to be reused.
        /// </summary>
        public int AvailableCount => this.pool.Count;

        // Prevent use of default constructor.
        private ObjectPool() {}

        /// <summary>
        /// Creates a new object pool with an initial capacity. New objects are
        /// created as needed using the object type default value.
        /// </summary>
        /// <param name="initialCapacity">The initial capacity of the pool.</param>
        public ObjectPool(int initialCapacity)
        {
            this.pool = new Queue<T>(initialCapacity);
            this.activeItems = new List<T>(initialCapacity);
            this.generator = () => default(T);
            this.maxCapacity = int.MaxValue;
            this.reuseActive = false;
        }

        /// <summary>
        /// Creates a new object pool with an initial capacity and max capacity.
        /// Optionally active objects can be reused when the pool has reached
        /// max capacity. New objects are created as needed using the object
        /// type default value.
        /// </summary>
        /// <param name="initialCapacity">The initial capacity of the pool.</param>
        /// <param name="maxCapacity">The maximum number of objects that can be generated.</param>
        /// <param name="reuseActive">Whether active objects should be reused when the object pool has reached max capacity.</param>
        public ObjectPool(int initialCapacity, int maxCapacity, bool reuseActive = false)
        {
            this.pool = new Queue<T>(initialCapacity);
            this.activeItems = new List<T>(initialCapacity);
            this.generator = () => default(T);

            this.maxCapacity = maxCapacity;
            this.reuseActive = reuseActive;
        }

        /// <summary>
        /// Creates a new object pool with a given generator function and
        /// initial capacity. New objects are created as needed with no max
        /// capacity.
        /// </summary>
        /// <param name="generator">The function delegate that generates a new object.</param>
        /// <param name="initialCapacity">The initial capacity of the pool.</param>
        public ObjectPool(Generator generator, int initialCapacity)
        {
            this.pool = new Queue<T>(initialCapacity);
            this.activeItems = new List<T>(initialCapacity);
            this.generator = generator;

            this.maxCapacity = int.MaxValue;
            this.reuseActive = false;
        }

        /// <summary>
        /// Creates a new object pool with a given generator function and set
        /// capacity limits. Optionally active objects can be reused when the
        /// pool has reached max capacity.
        /// </summary>
        /// <param name="generator">The function delegate that generates a new object.</param>
        /// <param name="initialCapacity">The initial capacity of the pool.</param>
        /// <param name="maxCapacity">The maximum number of objects that can be generated.</param>
        /// <param name="reuseActive">Whether active objects should be reused when the object pool has reached max capacity.</param>
        public ObjectPool(Generator generator, int initialCapacity, int maxCapacity, bool reuseActive = false)
        {
            this.pool = new Queue<T>(initialCapacity);
            this.activeItems = new List<T>(initialCapacity);
            this.generator = generator;

            this.maxCapacity = maxCapacity;
            this.reuseActive = reuseActive;
        }

        /// <summary>
        /// Disposes of all class resources.
        /// </summary>
        public void Dispose()
        {
            this.pool.Clear();
            this.activeItems.Clear();
            this.generator = null;
        }

        /// <summary>
        /// Disposes of all class resources and invokes a
        /// <paramref name="cleanup"/> function on each object in the pool.
        /// </summary>
        /// <remarks>
        /// The <paramref name="cleanup"/> function is useful, for example, if
        /// you want to destroy the objects when the pool is disposed.
        /// </remarks>
        /// <param name="cleanup">The cleanup function to invoke on each object.</param>
        public void Dispose(Action<T> cleanup)
        {
            if (cleanup != null)
            {
                while (this.pool.Count > 0) {
                    cleanup(this.pool.Dequeue());
                }

                foreach (T item in this.activeItems) {
                    cleanup(item);
                }
            }

            Dispose();
        }

        /// <summary>
        /// Returns an item from the object pool and removes it from the pool.
        /// If there are no available objects in the pool, either a new object
        /// will be generated or the oldest object will be reused depending upon
        /// how the object pool was created.
        /// </summary>
        public T Retrieve()
        {
            T item = null;

            if (this.activeItems.Count >= this.maxCapacity)
            {
                if (this.reuseActive)
                {
                    item = this.activeItems[0];
                    this.activeItems.RemoveAt(0);
                }
            }
            else
            {
                if (this.pool.Count > 0) {
                    item = this.pool.Dequeue();
                }

                if (item == null && this.generator != null) {
                    item = this.generator.Invoke();
                }
            }

            if (item != null) {
                this.activeItems.Add(item);
            }

            return item;
        }

        /// <summary>
        /// Adds an item back to the object pool so it can be reused.
        /// </summary>
        /// <param name="item">The item to add to the pool.</param>
        public void Recycle(T item)
        {
            if (item != null)
            {
                this.activeItems.Remove(item);
                this.pool.Enqueue(item);
            }
        }

        /// <summary>
        /// Empties the object pool of all objects.
        /// </summary>
        public void Empty()
        {
            this.activeItems.Clear();
            this.pool.Clear();
        }

        /// <summary>
        /// Empties the object pool of all objects and invokes a
        /// <paramref name="cleanup"/> function on each object.
        /// </summary>
        /// <remarks>
        /// The <paramref name="cleanup"/> function is useful, for example, if
        /// you want to destroy the objects when the pool is emptied.
        /// </remarks>
        /// <param name="cleanup">The cleanup function to invoke on each object.</param>
        public void Empty(Action<T> cleanup)
        {
            if (cleanup != null)
            {
                while (this.pool.Count > 0) {
                    cleanup(this.pool.Dequeue());
                }

                foreach (T item in this.activeItems) {
                    cleanup(item);
                }
            }

            Empty();
        }

    }

}
