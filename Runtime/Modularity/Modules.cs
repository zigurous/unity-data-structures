using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Manages a list of registered entity modules.
    /// </summary>
    public sealed class Modules<T> : IModular<T> where T: class
    {
        /// <summary>
        /// The modules registered to the entity.
        /// </summary>
        public List<T> items { get; private set; }

        /// <summary>
        /// A callback invoked when a new module is registered.
        /// </summary>
        public Action<T> registered;

        /// <summary>
        /// A callback invoked when a module is unregistered.
        /// </summary>
        public Action<T> unregistered;

        /// <summary>
        /// The amount of modules registered to the entity.
        /// </summary>
        public int Count => this.items.Count;

        /// <summary>
        /// Returns the module at the given index.
        /// </summary>
        public T this[int index] => this.items.ElementAt(index);

        private Modules() {}

        /// <summary>
        /// Creates a new Modules instance with a set capacity.
        /// </summary>
        public Modules(int capacity, Action<T> registered = null, Action<T> unregistered = null)
        {
            this.items = new List<T>(capacity);
            this.registered = registered;
            this.unregistered = unregistered;
        }

        /// <summary>
        /// Creates a new Modules instance and pre-registers a list of given
        /// items.
        /// </summary>
        public Modules(T[] items, Action<T> registered = null, Action<T> unregistered = null)
        {
            this.items = new List<T>(items);
            this.registered = registered;
            this.unregistered = unregistered;

            if (registered != null)
            {
                for (int i = 0; i < items.Length; i++) {
                    registered.Invoke(items[i]);
                }
            }
        }

        /// <summary>
        /// Registers an item to the entity. Returns false if the item cannot be
        /// registered.
        /// </summary>
        public bool Register(T item)
        {
            if (item == null || this.items.Contains(item)) {
                return false;
            }

            this.items.Add(item);

            if (this.registered != null) {
                this.registered.Invoke(item);
            }

            return true;
        }

        /// <summary>
        /// Unregisters an item from the entity. Returns true if the item is
        /// unregistered.
        /// </summary>
        public bool Unregister(T item)
        {
            if (item != null && this.items.Remove(item))
            {
                if (this.unregistered != null) {
                    this.unregistered.Invoke(item);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Deternines if the provided item is registered.
        /// </summary>
        public bool IsRegistered(T item)
        {
            return this.items.Contains(item);
        }

    }

}
