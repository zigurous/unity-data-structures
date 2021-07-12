namespace Zigurous.DataStructures
{
    /// <summary>
    /// A type that can register and unregister modules.
    /// </summary>
    /// <typeparam name="T">The type of module that can be registered.</typeparam>
    public interface IModular<T> where T: class
    {
        /// <summary>
        /// Registers a <paramref name="module"/> to the entity.
        /// </summary>
        /// <param name="module">The module to register.</param>
        /// <returns>True if the module was registered, false if the module cannot be registered.</returns>
        bool Register(T module);

        /// <summary>
        /// Unregisters a <paramref name="module"/> from the entity.
        /// </summary>
        /// <param name="module">The module to unregister.</param>
        /// <returns>True if the module was unregistered, false if the module cannot be unregistered.</returns>
        bool Unregister(T module);

        /// <summary>
        /// Checks if the <paramref name="module"/> is registered.
        /// </summary>
        /// <param name="module">The module to check for registration.</param>
        bool IsRegistered(T module);
    }

}
