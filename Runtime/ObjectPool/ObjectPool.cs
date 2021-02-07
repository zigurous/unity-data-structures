using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Reuses objects from a shared pool to prevent instantiating new objects.
    /// The object pool can have a set capacity or it can grow in size.
    /// Optionally, objects that are currently active can be reused
    /// when the pool has reached capacity.
    /// </summary>
    public sealed class ObjectPool<T> : IObjectPool<T> where T: class
    {
        /// <summary>
        /// Creates a new instance of an object.
        /// </summary>
        public delegate T Generator();

        /// <summary>
        /// The list of all objects waiting to be reused.
        /// </summary>
        private Queue<T> _pool;

        /// <summary>
        /// The list of objects currently being used.
        /// </summary>
        private List<T> _activeItems;

        /// <summary>
        /// The function that generates a new object.
        /// </summary>
        private Generator _generator;

        /// <summary>
        /// The maximum number of objects that can be generated.
        /// </summary>
        public int capacity { get; private set; }

        /// <summary>
        /// Whether active objects should be reused when
        /// the object pool has reached capacity.
        /// </summary>
        public bool reuseActive { get; private set; }

        /// <summary>
        /// The number of objects currently being used.
        /// </summary>
        public int ActiveCount => _activeItems.Count;

        /// <summary>
        /// The number of objects available to be reused.
        /// </summary>
        public int AvailableCount => _pool.Count;

        /// <summary>
        /// Creates a new ObjectPool with no capacity.
        /// New objects are created using the default
        /// value of the object type.
        /// </summary>
        public ObjectPool()
        {
            _pool = new Queue<T>();
            _activeItems = new List<T>();
            _generator = () => default(T);

            this.capacity = int.MaxValue;
            this.reuseActive = false;
        }

        /// <summary>
        /// Creates a new ObjectPool with a given object capacity.
        /// Optionally, active objects can be reused when the pool
        /// has reached capacity. New objects are created using the
        /// default value of the object type.
        /// </summary>
        public ObjectPool(int capacity, bool reuseActive = false)
        {
            _pool = new Queue<T>(capacity);
            _activeItems = new List<T>(capacity);
            _generator = () => default(T);

            this.capacity = capacity;
            this.reuseActive = reuseActive;
        }

        /// <summary>
        /// Creates a new ObjectPool with a given generator function
        /// and no object capacity.
        /// </summary>
        public ObjectPool(Generator generator)
        {
            _pool = new Queue<T>();
            _activeItems = new List<T>();
            _generator = generator;

            this.capacity = int.MaxValue;
            this.reuseActive = false;
        }

        /// <summary>
        /// Creates a new ObjectPool with a given generator function
        /// and a set object capacity. Optionally, active objects
        /// can be reused when the pool has reached capacity.
        /// </summary>
        public ObjectPool(Generator generator, int capacity, bool reuseActive = false)
        {
            _pool = new Queue<T>(capacity);
            _activeItems = new List<T>(capacity);
            _generator = generator;

            this.capacity = capacity;
            this.reuseActive = reuseActive;
        }

        /// <summary>
        /// Disposes of all class resources.
        /// </summary>
        public void Dispose()
        {
            if (_pool != null)
            {
                _pool.Clear();
                _pool = null;
            }

            if (_activeItems != null)
            {
                _activeItems.Clear();
                _activeItems = null;
            }

            _generator = null;
        }

        /// <summary>
        /// Disposes of all class resources and invokes a
        /// cleanup function on each object in the pool.
        /// This is useful, for example, if you want to
        /// destroy the objects when the pool is disposed.
        /// </summary>
        public void Dispose(Action<T> cleanup)
        {
            if (_pool != null)
            {
                if (cleanup != null)
                {
                    while (_pool.Count > 0) {
                        cleanup(_pool.Dequeue());
                    }
                }

                _pool.Clear();
                _pool = null;
            }

            if (_activeItems != null)
            {
                if (cleanup != null)
                {
                    foreach (T item in _activeItems) {
                        cleanup(item);
                    }
                }

                _activeItems.Clear();
                _activeItems = null;
            }

            _generator = null;
        }

        /// <summary>
        /// Retrieves an item from the object pool.
        /// If there are no available objects in the pool,
        /// either a new object will be generated or
        /// the oldest object will be reused depending
        /// upon how the ObjectPool was created.
        /// </summary>
        public T Retrieve()
        {
            T item;

            if (_activeItems.Count >= this.capacity)
            {
                if (this.reuseActive)
                {
                    item = _activeItems[0];
                    _activeItems.RemoveAt(0);
                }
                else
                {
                    item = null;
                }
            }
            else
            {
                if (_pool.Count > 0) {
                    return _pool.Dequeue() ?? _generator.Invoke();
                } else {
                    return _generator.Invoke();
                }
            }

            if (item != null) {
                _activeItems.Add(item);
            }

            return item;
        }

        /// <summary>
        /// Adds an item back to the object pool
        /// so it can be reused.
        /// </summary>
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
        /// Empties the object pool of all objects and
        /// invokes a cleanup function on each object.
        /// This is useful, for example, if you want to
        /// destroy the objects when the pool is emptied.
        /// </summary>
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
