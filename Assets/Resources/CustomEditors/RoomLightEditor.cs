using Assets.Resources.MapSystem.Scripts;
using Assets.Scripts.LabyrinthGenerator;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Resources.CustomEditors
{
    [CustomEditor(typeof(RoomLight))]
    public class RoomLightEditor : Editor
    {
        private RoomLight roomLight;
        private SerializedProperty meshProperty;
        private SerializedProperty emergencyLightsProperty;
        private SerializedProperty lightProperty;

        private void OnEnable()
        {
            roomLight = (RoomLight)target;
            meshProperty = serializedObject.FindProperty("targetMesh");
            emergencyLightsProperty = serializedObject.FindProperty("emergencyLights");
            lightProperty = serializedObject.FindProperty("blinkingLight");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            roomLight.type = (RoomType)EditorGUILayout.EnumPopup("Тип комнаты", roomLight.type);
            roomLight.indexLigtMapOffset = EditorGUILayout.IntField("Сдвиг по индексу карт света", roomLight.indexLigtMapOffset);

            if (roomLight.indexLigtMapOffset < 0)
            {
                roomLight.indexLigtMapOffset = 0;
            }

            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.PrefixLabel("Настройки света");
            EditorGUILayout.Space();

            roomLight.isGeneralLighting = EditorGUILayout.Toggle("Общее освещение", roomLight.isGeneralLighting);

            if (roomLight.isGeneralLighting)
            {
                roomLight.ambientColor = EditorGUILayout.ColorField("Цвет освещения", roomLight.ambientColor);
            }
            else
            {
                roomLight.isEmergencyLighting = EditorGUILayout.Toggle("Аварийное освещение", roomLight.isEmergencyLighting);

                if (roomLight.isEmergencyLighting)
                {
                    roomLight.isEmergencyBlinking = EditorGUILayout.Toggle("Перебои со светом", roomLight.isEmergencyBlinking);

                    EditorGUILayout.PropertyField(emergencyLightsProperty, new GUIContent("Аварийные источники света"));

                    if (roomLight.isEmergencyBlinking)
                    {
                        EditorGUILayout.PropertyField(lightProperty, new GUIContent("Сломанный источник света"));
                    }
                }
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(meshProperty, new GUIContent("MeshRenderer"));

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(roomLight.gameObject);
                EditorSceneManager.MarkSceneDirty(roomLight.gameObject.scene);
            }
        }
    }
}