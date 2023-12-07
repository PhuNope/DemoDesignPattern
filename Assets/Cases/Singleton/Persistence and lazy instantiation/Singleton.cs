using UnityEngine;

namespace Persistence_and_lazy_instantiation {
    public class Singleton : MonoBehaviour {
        private static Singleton instance;

        public static Singleton Instance {
            get {
                if (instance == null) {
                    SetupInstance();
                }
                return instance;
            }
        }

        private void Awake() {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else {
                Destroy(gameObject);
            }
        }

        private static void SetupInstance() {
            instance = FindObjectOfType<Singleton>();

            if (instance == null) {
                GameObject gameObj = new GameObject();
                gameObj.name = "Singleton";
                instance = gameObj.AddComponent<Singleton>();
                DontDestroyOnLoad(gameObj);
            }
        }
    }
}