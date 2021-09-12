namespace Zigurous.DataStructures
{
    /// <summary>
    /// A type that can retrieve and recycle objects from a shared pool.
    /// </summary>
    /// <typeparam name="T">The type of object to be pooled.</typeparam>
    public interface IObjectPool<T> where T: class
    {
        /// <summary>
        /// Removes and returns an object from the pool.
        /// </summary>
        /// <returns>An object from the pool.</returns>
        T Retrieve();

        /// <summary>
        /// Adds an object back to the pool so it can be reused.
        /// </summary>
        /// <param name="item">The object to recycle.</param>
        void Recycle(T item);

        /// <summary>
        /// Empties the pool of all objects.
        /// </summary>
        void Empty();
    }

}
