using UnityEngine;

public static class ResourceLoader
{
    public static T Load<T>(string path) where T : Object
    {
        return GameObject.Instantiate(Resources.Load<T>(path));
    }
    public static T Load<T>(string path, Transform parent) where T : Object
    {
        return GameObject.Instantiate(Resources.Load<T>(path), parent);
    }
}
