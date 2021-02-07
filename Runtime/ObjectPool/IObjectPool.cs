using System;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A type that can retrieve and recycle objects from a shared pool.
    /// </summary>
    public interface IObjectPool<T> : IDisposable where T: class
    {
        /// <summary>
        /// Retrieves an item from the object pool.
        /// </summary>
        T Retrieve();

        /// <summary>
        /// Adds an item back to the object pool so it can be reused.
        /// </summary>
        void Recycle(T item);

        /// <summary>
        /// Empties the object pool of all objects.
        /// </summary>
        void Empty();
    }

}
