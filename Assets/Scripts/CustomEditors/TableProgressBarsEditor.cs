using Assets.Scripts.CraftSystem.UI;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Scripts.CustomEditors
{
    [CustomEditor(typeof(TableProgressBars))]
    public class TableProgressBarsEditor : Editor
    {
        private TableProgressBars table;
        //private SerializedProperty testScriptProperty;

        public void OnEnable()
        {
            table = (TableProgressBars)target;

            //testScriptProperty = serializedObject.FindProperty("progressBar");
        }

        
        public override void OnInspectorGUI()
        {
            //EditorGUILayout.PropertyField(testScriptProperty, new GUIContent("Test Script"));

            table.progressBar = (CharacteristicProgressBar)EditorGUILayout.ObjectField("Префаб шкалы", table.progressBar, typeof(CharacteristicProgressBar));
            table.overrideBarColors = EditorGUILayout.Toggle("Заменить цвета шкалы", table.overrideBarColors);

            if (table.overrideBarColors)
            {
                EditorGUILayout.BeginVertical("Box");

                table.fillerColor = EditorGUILayout.ColorField("Шкала прогресса", table.fillerColor);
                table.backgroundColor = EditorGUILayout.ColorField("Задняя стенка", table.backgroundColor);
                table.improveColor = EditorGUILayout.ColorField("Улучшение", table.improveColor);
                table.downgraidColor = EditorGUILayout.ColorField("Даунгрейд", table.downgraidColor);

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(table.gameObject);
                EditorSceneManager.MarkSceneDirty(table.gameObject.scene);
            }
        }
    }
}
