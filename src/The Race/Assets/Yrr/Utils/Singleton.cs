using UnityEngine;


namespace Yrr.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {               
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        var singleton = new GameObject(typeof(T).ToString());
                        _instance = singleton.AddComponent<T>();
                        DontDestroyOnLoad(singleton);
                    }

                    if (_instance is IInitializable initializable)
                    {
                        initializable.Initialize();
                    }
                }

                return _instance;
            }
        }
    }
}