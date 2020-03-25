using UnityEngine;
using UnityEngine.SceneManagement;

namespace Extensions.Singleton
{
    /// <summary>
    /// Generic singleton class meant for inheritance
    /// </summary>
    /// <typeparam name="T">Type of class (private static T instance)</typeparam>
    /// <typeparam name="A">Type of calling (public static A Instance)</typeparam>
    public abstract class GenericSingleton<T, A> : MonoBehaviour where T : Component, A
    {
        private static T instance;
        public static A Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.hideFlags = HideFlags.HideAndDontSave;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {

            if (instance == null)
            {
                instance = this as T;
            } else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {

        }

        protected virtual void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        protected virtual void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }
    }
}
