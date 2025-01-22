#if UNITY_EDITOR

using Assets.Scripts.Entities;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.LabyrinthGenerator;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using static LootContainer;

namespace Assets.Resources.CustomEditors
{
    [CustomEditor(typeof(LootContainer))]
    public class LootContainerEditor : Editor
    {
        private LootContainer container;
        private SerializedProperty dropEventProperty;
        private SerializedProperty openEventProperty;

        public void OnEnable()
        {
            container = (LootContainer)target;
            dropEventProperty = serializedObject.FindProperty("OnDroped");
            openEventProperty = serializedObject.FindProperty("OnOpened");
        }

        public override void OnInspectorGUI()
        {
            // Рендеринг полей инспектора
            container.typeSpawn = (TypeSpawn)EditorGUILayout.EnumPopup("Метод спавна", container.typeSpawn);

            switch (container.typeSpawn)
            {
                case TypeSpawn.Item:
                    container.itemName = (ItemNames)EditorGUILayout.EnumPopup("Предмет", container.itemName);
                    break;
                case TypeSpawn.Room:
                    container.roomType = (RoomType)EditorGUILayout.EnumPopup("Дроп лист комнаты", container.roomType);
                    break;
                case TypeSpawn.Enemy:
                    container.enemyName = (NamesOfEnemies)EditorGUILayout.EnumPopup("Дроп лист врага", container.enemyName);
                    break;
                default:
                    break;
            }
            EditorGUILayout.Space();

            container.openAmount = EditorGUILayout.IntField("Количество открываний", container.openAmount);

            // Принудительное применение ограничения [Min(1)]
            if (container.openAmount < 1)
            {
                container.openAmount = 1;
            }

            container.maxLootAmount = EditorGUILayout.IntField("Количество дропа за раз", container.maxLootAmount);

            if (container.maxLootAmount < 1)
            {
                container.maxLootAmount = 1;
            }

            container.isRandomazeLootAmount = EditorGUILayout.Toggle("Рандомизировать количество", container.isRandomazeLootAmount);

            EditorGUILayout.Space();

            // Обновляем объект для синхронизации изменений
            serializedObject.Update();

            EditorGUILayout.PropertyField(dropEventProperty, new GUIContent("Событие при дропе предмета"));
            EditorGUILayout.PropertyField(openEventProperty, new GUIContent("Событие при опустении контейнера"));

            // Применяем изменения
            serializedObject.ApplyModifiedProperties();


            if (GUI.changed)
            {
                EditorUtility.SetDirty(container.gameObject);
                EditorSceneManager.MarkSceneDirty(container.gameObject.scene);
            }
        }
    }
}

#endif