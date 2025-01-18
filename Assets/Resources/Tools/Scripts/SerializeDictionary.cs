using System;
using System.Collections.Generic;

namespace Assets.Scripts.Tools
{
    [Serializable]
    public class SerializeDictionary<K, V>
    {
        public List<KeyValue<K, V>> keyValues;

        public bool isUniqueKeys = false;

        public List<K> Keys { get 
            {
                List<K> keys = new();

                foreach (var keyValue in keyValues)
                {
                    keys.Add(keyValue.key);
                }

                return keys;
            }
        }

        public SerializeDictionary()
        {
            keyValues = new();
        }

        public void Add(K key, V value)
        {
            if (isUniqueKeys)
            {
                bool isExist = false;
                foreach (var keyValue in keyValues)
                {
                    if (KeysAreEqual(keyValue.key, key))
                    {
                        isExist = true;

                        return;
                    }
                }

                if (!isExist)
                {
                    keyValues.Add(new KeyValue<K, V>(key, value));
                }
            }
            else
            {
                keyValues.Add(new KeyValue<K, V>(key, value));
            }
        }

        public V GetValue(K key)
        {
            foreach (var item in keyValues)
            {
                if(KeysAreEqual(item.key, key))
                {
                    return item.value;
                }
            }

            throw new Exception($"Key {key} is not Exist.");
        }

        public void RemoveLast()
        {
            keyValues.RemoveAt(keyValues.Count - 1);
        }
        public void RemoveAt(K key)
        {
            foreach (var keyValue in keyValues)
            {
                if(KeysAreEqual(keyValue.key, key))
                {
                    keyValues.Remove(keyValue);

                    return;
                }
            }
        }

        public bool KeysAreEqual(K key1, K key2)
        {
            return key1.Equals(key2);
        }
    }



    [Serializable]
    public class KeyValue<K, V>
    {
        public K key;
        public V value;

        public KeyValue(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
