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
        private static volatile T _instance;
        private static object _lock = new object();
        private static bool _isUnloading = false;

        /// <returns>
        /// True if the singleton has been initialized and an instance is
        /// available to use.
        /// </returns>
        public static bool HasInstance => _instance != null;

        /// <summary>
        /// The current instance of the class.
        /// The instance will be created if it does not already exist.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_isUnloading) {
                    return null;
                }

                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = FindObjectOfType<T>();

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            singleton.name = typeof(T).Name;
                            singleton.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
                            singleton.AddComponent<T>();
                            DontDestroyOnLoad(singleton);
                        }
                    }
                }

                return _instance;
            }
        }

        protected SingletonBehavior() {}

        protected virtual void Awake()
        {
            _isUnloading = false;

            if (_instance == null) {
                _instance = this as T;
                OnSingletonInitialized();
            } else {
                Destroy(this);
            }
        }

        protected virtual void OnDestroy()
        {
            _isUnloading = true;

            if (_instance == this) {
                _instance = null;
            }
        }

        /// <summary>
        /// A callback invoked when the singleton is first initialized.
        /// </summary>
        protected virtual void OnSingletonInitialized() {}

    }

}
