using System.Collections;
using UnityEngine;

namespace CoroutineManager
{
    public class Coroutines : MonoBehaviour
    {
        private static Coroutines instance;

        private void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(this);
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static Coroutine StartRoutine(IEnumerator routine)
        {
            return instance.StartCoroutine(routine);
        }
        public static void StopRoutine(Coroutine routine)
        {
            instance.StopCoroutine(routine);
        }
    }
}
