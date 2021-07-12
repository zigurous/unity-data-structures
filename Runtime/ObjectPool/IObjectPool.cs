using System;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A type that can retrieve and recycle objects from a shared pool.
    /// </summary>
    /// <typeparam name="T">The type of object to be pooled.</typeparam>
    public interface IObjectPool<T> : IDisposable where T: class
    {
        /// <summary>
        /// Returns an item from the object pool and removes it from the pool.
        /// </summary>
        T Retrieve();

        /// <summary>
        /// Adds an item back to the object pool so it can be reused.
        /// </summary>
        /// <param name="item">The item to recycle.</param>
        void Recycle(T item);

        /// <summary>
        /// Empties the object pool of all objects.
        /// </summary>
        void Empty();
    }

}
