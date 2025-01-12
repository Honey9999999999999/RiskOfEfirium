using Assets.Scripts.Tools;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Light
{
    public class LightSwitcher : MonoBehaviour
    {
        public SerializeDictionary<Renderer, SerializeDictionary<Type, int>> lightMapMap;

        public LightingDataAsset lighting;

        private Type currentType;
        private const int MaxCountTypes = (int)Type.Alter;

        private void Start()
        {
            foreach (var renderer in lightMapMap.keyValues)
            {
                currentType = renderer.value.keyValues[0].key;
            }
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Switch();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Change();
            }
        }

        public void Switch()
        {
            if (lightMapMap.keyValues[0].key.lightmapIndex == -1)
            {
                SetState(currentType);
            }
            else
            {
                foreach (var renderer in lightMapMap.Keys)
                {
                    renderer.lightmapIndex = -1;
                }
            }
        }

        public void Change()
        {
            if ((int)currentType == MaxCountTypes)
            {
                currentType = 0;
            }
            else
            {
                currentType++;
            }

            SetState(currentType);
        }

        private void SetState(Type type)
        {
            foreach (var renderer in lightMapMap.Keys)
            {
                renderer.lightmapIndex = lightMapMap.GetValue(renderer).GetValue(type);
            }
        }
    }

    public enum Type
    {
        Standart,
        Alter
    }
}
