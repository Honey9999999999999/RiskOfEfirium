using UnityEngine;

namespace Assets.Scripts.Tools
{
    public static class Instantiater
    {
        public static T Instantiate<T>(string path) where T : Object
        {
            return GameObject.Instantiate(Resources.Load<T>(path));
        }
        public static T Instantiate<T>(string path, Transform parent) where T : Object
        {
            return GameObject.Instantiate(Resources.Load<T>(path), parent);
        }
    }
}
