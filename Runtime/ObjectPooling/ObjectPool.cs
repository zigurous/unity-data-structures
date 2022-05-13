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
    public sealed class ObjectPool<T> : IObjectPool<T>, IDisposable where T: class
    {
        /// <summary>
        /// A function delegate that creates a new instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>A new instance of <typeparamref name="T"/>.</returns>
        public delegate T Generator();

        /// <summary>
        /// The list of all objects waiting to be reused (Read only).
        /// </summary>
        public Queue<T> pool { get; private set; }

        /// <summary>
        /// The list of objects currently being used (Read only).
        /// </summary>
        public List<T> activeItems { get; private set; }

        /// <summary>
        /// The number of objects currently being used (Read only).
        /// </summary>
        public int activeCount => activeItems.Count;

        /// <summary>
        /// The number of objects available to be reused (Read only).
        /// </summary>
        public int availableCount => pool.Count;

        /// <summary>
        /// The maximum number of objects that can be generated.
        /// </summary>
        public int maxCapacity { get; set; }

        /// <summary>
        /// Whether active objects should be reused when the object pool has
        /// reached capacity.
        /// </summary>
        public bool reuseActive { get; set; }

        /// <summary>
        /// The function that generates a new object.
        /// </summary>
        public Generator generator { get; set; }

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
            pool.Clear();
            activeItems.Clear();
            generator = null;
        }

        /// <summary>
        /// Disposes of all class resources and invokes a cleanup function on
        /// each object in the pool.
        /// </summary>
        /// <remarks>
        /// The cleanup function is useful, for example, if you want to destroy
        /// the objects when the pool is disposed.
        /// </remarks>
        /// <param name="cleanup">The cleanup function to invoke on each object.</param>
        public void Dispose(Action<T> cleanup)
        {
            if (cleanup != null)
            {
                while (pool.Count > 0) {
                    cleanup(pool.Dequeue());
                }

                foreach (T item in activeItems) {
                    cleanup(item);
                }
            }

            Dispose();
        }

        /// <summary>
        /// Removes and returns an object from the pool. If there are no
        /// available objects in the pool, either a new object will be generated
        /// or the oldest object will be reused depending upon how the object
        /// pool is configured.
        /// </summary>
        /// <returns>An object from the pool.</returns>
        public T Retrieve()
        {
            T item = null;

            if (activeItems.Count >= maxCapacity)
            {
                if (reuseActive)
                {
                    item = activeItems[0];
                    activeItems.RemoveAt(0);
                }
            }
            else
            {
                if (pool.Count > 0) {
                    item = pool.Dequeue();
                }

                if (item == null && generator != null) {
                    item = generator.Invoke();
                }
            }

            if (item != null) {
                activeItems.Add(item);
            }

            return item;
        }

        /// <summary>
        /// Adds an object back to the pool so it can be reused.
        /// </summary>
        /// <param name="item">The object to recycle.</param>
        public void Recycle(T item)
        {
            if (item != null)
            {
                activeItems.Remove(item);
                pool.Enqueue(item);
            }
        }

        /// <summary>
        /// Empties the pool of all objects.
        /// </summary>
        public void Empty()
        {
            activeItems.Clear();
            pool.Clear();
        }

        /// <summary>
        /// Empties the pool of all objects and invokes a cleanup function on
        /// each object.
        /// </summary>
        /// <remarks>
        /// The cleanup function is useful, for example, if you want to destroy
        /// the objects when the pool is emptied.
        /// </remarks>
        /// <param name="cleanup">The cleanup function to invoke on each object.</param>
        public void Empty(Action<T> cleanup)
        {
            if (cleanup != null)
            {
                while (pool.Count > 0) {
                    cleanup(pool.Dequeue());
                }

                foreach (T item in activeItems) {
                    cleanup(item);
                }
            }

            Empty();
        }

    }

}
