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
        /// <summary>A function delegate that creates a new instance of an object.</summary>
        /// <returns>A new instance of an object.</returns>
        public delegate T Generator();

        /// <summary>
        /// The function delegate that generates a new object.
        /// </summary>
        private Generator _generator;

        /// <summary>
        /// The list of all objects waiting to be reused.
        /// </summary>
        private Queue<T> _pool;

        /// <summary>
        /// The list of objects currently being used.
        /// </summary>
        private List<T> _activeItems;

        /// <summary>
        /// The maximum number of objects that can be generated.
        /// </summary>
        public int maxCapacity { get; private set; }

        /// <summary>
        /// Whether active objects should be reused when the object pool has
        /// reached capacity.
        /// </summary>
        public bool reuseActive { get; private set; }

        /// <returns>
        /// The number of objects currently being used.
        /// </returns>
        public int ActiveCount => _activeItems.Count;

        /// <returns>
        /// The number of objects available to be reused.
        /// </returns>
        public int AvailableCount => _pool.Count;

        // Prevent use of default constructor.
        private ObjectPool() {}

        /// <summary>
        /// Creates a new object pool with an initial capacity. New objects are
        /// created as needed using the object type default value.
        /// </summary>
        /// <param name="initialCapacity">The initial capacity of the pool.</param>
        public ObjectPool(int initialCapacity)
        {
            _pool = new Queue<T>(initialCapacity);
            _activeItems = new List<T>(initialCapacity);
            _generator = () => default(T);

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
            _pool = new Queue<T>(initialCapacity);
            _activeItems = new List<T>(initialCapacity);
            _generator = () => default(T);

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
            _pool = new Queue<T>(initialCapacity);
            _activeItems = new List<T>(initialCapacity);
            _generator = generator;

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
            _pool = new Queue<T>(initialCapacity);
            _activeItems = new List<T>(initialCapacity);
            _generator = generator;

            this.maxCapacity = maxCapacity;
            this.reuseActive = reuseActive;
        }

        /// <summary>
        /// Disposes of all class resources.
        /// </summary>
        public void Dispose()
        {
            _pool.Clear();
            _activeItems.Clear();
            _generator = null;
        }

        /// <summary>
        /// Disposes of all class resources and invokes a cleanup function on
        /// each object in the pool. This is useful, for example, if you want to
        /// destroy the objects when the pool is disposed.
        /// </summary>
        /// <param name="cleanup">The cleanup function to invoke on each object.</param>
        public void Dispose(Action<T> cleanup)
        {
            if (cleanup != null)
            {
                while (_pool.Count > 0) {
                    cleanup(_pool.Dequeue());
                }

                foreach (T item in _activeItems) {
                    cleanup(item);
                }
            }

            _pool.Clear();
            _activeItems.Clear();
        }

        /// <returns>
        /// An item from the object pool. If there are no available objects in
        /// the pool, either a new object will be generated or the oldest object
        /// will be reused depending upon how the object pool was created.
        /// </returns>
        public T Retrieve()
        {
            T item = null;

            if (_activeItems.Count >= this.maxCapacity)
            {
                if (this.reuseActive)
                {
                    item = _activeItems[0];
                    _activeItems.RemoveAt(0);
                }
            }
            else
            {
                if (_pool.Count > 0) {
                    item = _pool.Dequeue();
                }

                if (item == null && _generator != null) {
                    item = _generator.Invoke();
                }
            }

            if (item != null) {
                _activeItems.Add(item);
            }

            return item;
        }

        /// <summary>Adds an item back to the object pool so it can be reused.</summary>
        /// <param name="item">The item to add to the pool.</param>
        public void Recycle(T item)
        {
            if (item != null)
            {
                _activeItems.Remove(item);
                _pool.Enqueue(item);
            }
        }

        /// <summary>
        /// Empties the object pool of all objects.
        /// </summary>
        public void Empty()
        {
            _activeItems.Clear();
            _pool.Clear();
        }

        /// <summary>
        /// Empties the object pool of all objects and invokes a cleanup
        /// function on each object. This is useful, for example, if you want to
        /// destroy the objects when the pool is emptied.
        /// </summary>
        /// <param name="cleanup">The cleanup function to invoke on each object.</param>
        public void Empty(Action<T> cleanup)
        {
            if (cleanup != null)
            {
                while (_pool.Count > 0) {
                    cleanup(_pool.Dequeue());
                }

                foreach (T item in _activeItems) {
                    cleanup(item);
                }
            }

            _activeItems.Clear();
            _pool.Clear();
        }

    }

}
