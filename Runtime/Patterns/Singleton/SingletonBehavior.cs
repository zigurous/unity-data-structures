using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A singleton behavior that can be used to ensure that only one instance
    /// of a class is created.
    /// </summary>
    /// <typeparam name="T">The type of the singleton class.</typeparam>
    public abstract class SingletonBehavior<T> : MonoBehaviour where T : Component
    {
        private static volatile T instance;
        private static object lockObject = new object();
        private static bool isUnloading = false;

        /// <summary>
        /// The current instance of the class.
        /// The instance will be created if it does not already exist.
        /// </summary>
        /// <returns>The instance of the class.</returns>
        public static T Instance
        {
            get
            {
                if (isUnloading) {
                    return null;
                }

                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance = FindObjectOfType<T>();

                        if (instance == null)
                        {
                            GameObject singleton = new GameObject();
                            singleton.name = typeof(T).Name;
                            singleton.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
                            singleton.AddComponent<T>();
                            DontDestroyOnLoad(singleton);
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Checks if the singleton has been initialized and an instance is
        /// available to use.
        /// </summary>
        /// <returns>True if an instance is available, false otherwise.</returns>
        public static bool HasInstance => instance != null;

        /// <summary>
        /// Constructs a new instance of the class.
        /// </summary>
        protected SingletonBehavior() {}

        /// <summary>
        /// A Unity lifecycle method called when the behavior is initialized.
        /// </summary>
        protected virtual void Awake()
        {
            isUnloading = false;

            if (instance == null) {
                instance = this as T;
                OnSingletonInitialized();
            } else {
                Destroy(this);
            }
        }

        /// <summary>
        /// A Unity lifecycle method called when the behavior is destroyed.
        /// </summary>
        protected virtual void OnDestroy()
        {
            isUnloading = true;

            if (instance == this) {
                instance = null;
            }
        }

        /// <summary>
        /// A callback invoked when the singleton is initialized.
        /// </summary>
        protected virtual void OnSingletonInitialized() {}

    }

}
