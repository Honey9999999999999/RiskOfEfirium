using Assets.Scripts.Light;
using Assets.Scripts.Tools;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.CustomEditors
{
    [CustomEditor(typeof(LightSwitcher))]
    internal class LightSwitcherEditor : Editor
    {
        private LightSwitcher switcher;
        private SerializeDictionary<Renderer, SerializeDictionary<Type, int>> lightMapMap;

        public void OnEnable()
        {
            switcher = (LightSwitcher)target;
            lightMapMap = switcher.lightMapMap;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (lightMapMap == null || lightMapMap.keyValues == null)
            {
                EditorGUILayout.HelpBox("Dictionary is not initialized!", MessageType.Warning);
                return;
            }

            EditorGUILayout.LabelField("Light Map Map", EditorStyles.boldLabel);

            foreach (var outerEntry in lightMapMap.keyValues)
            {
                EditorGUILayout.BeginVertical("box");
                outerEntry.key = (Renderer)EditorGUILayout.ObjectField("Renderer", outerEntry.key, typeof(Renderer), true);

                if (outerEntry.value != null && outerEntry.value.keyValues != null)
                {
                    foreach (var innerEntry in outerEntry.value.keyValues)
                    {
                        EditorGUILayout.BeginHorizontal();
                        innerEntry.key = (Type)EditorGUILayout.EnumPopup("Type", innerEntry.key);
                        innerEntry.value = EditorGUILayout.IntField("Value", innerEntry.value);
                        EditorGUILayout.EndHorizontal();
                    }
                }

                if (GUILayout.Button("Add Inner Entry"))
                {
                    if (outerEntry.value.keyValues.Count == 0)
                    {
                        outerEntry.value.Add(Type.Standart, 0);
                    }
                    else
                    {
                        outerEntry.value.Add((Type)((int)outerEntry.value.keyValues[^1].key + 1), 0);
                    }
                }
                if (outerEntry.value.keyValues.Count > 0 && GUILayout.Button("Remove Inner Entry"))
                {
                    outerEntry.value.keyValues.RemoveAt(lightMapMap.keyValues.Count - 1);
                }

                EditorGUILayout.EndVertical();
            }

            if (GUILayout.Button("Add Outer Entry"))
            {
                lightMapMap.Add(null, new SerializeDictionary<Type, int>());
            }
            if (lightMapMap.keyValues.Count > 0 && GUILayout.Button("Remove Outer Entry"))
            {
                lightMapMap.keyValues.RemoveAt(lightMapMap.keyValues.Count - 1);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(switcher);
            }

            // Применяем изменения
            serializedObject.ApplyModifiedProperties();
        }
    }
}
