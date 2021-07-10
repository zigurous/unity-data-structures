namespace Zigurous.DataStructures
{
    /// <summary>A type that can register and unregister modules.</summary>
    /// <typeparam name="T">The type of module that can be registered.</typeparam>
    public interface IModular<T> where T: class
    {
        /// <summary>Registers a module to the entity.</summary>
        /// <returns>True if the module was registered, false if the module cannot be registered.</returns>
        /// <param name="module">The module to register.</param>
        bool Register(T module);

        /// <summary>Unregisters a module from the entity.</summary>
        /// <returns>True if the module was unregistered, false if the module cannot be unregistered.</returns>
        /// <param name="module">The module to unregister.</param>
        bool Unregister(T module);

        /// <returns>True if the module is registered, false if the module is not registered.</returns>
        /// <param name="module">The module to check for registration.</param>
        bool IsRegistered(T module);
    }

}
