namespace Zigurous.DataStructures
{
    /// <summary>
    /// A type that can register and unregister modules.
    /// </summary>
    public interface IModular<T> where T: class
    {
        /// <summary>
        /// Registers a module to the entity. Returns false if the module cannot
        /// be registered.
        /// </summary>
        bool Register(T module);

        /// <summary>
        /// Unregisters a module from the entity. Returns true if the module is
        /// unregistered.
        /// </summary>
        bool Unregister(T module);

        /// <summary>
        /// Determines if the provided module is registered.
        /// </summary>
        bool IsRegistered(T module);
    }

}
