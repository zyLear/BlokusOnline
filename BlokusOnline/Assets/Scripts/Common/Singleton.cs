using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Common {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

        private static T _instance;

        public static T Instance {
            get {
                if (_instance == null) {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (_instance == null) {
                        GameObject gameObject = new GameObject(("(singleton)" + typeof(T)));
                        _instance = gameObject.AddComponent<T>();
                        DontDestroyOnLoad(gameObject);
                        Debug.Log("create singleton gameObject complete");
                    }
                }
                return _instance;
            }
        }
    }

}
