using UnityEditor;
using UnityEngine;

namespace Assets.Resources.BattleSystem.CustomEditors
{
#if UNITY_EDITOR

    [CustomEditor(typeof(SpellOrganaizer))]
    public class SpellOrganaizerEditor : Editor
    {
        private SpellOrganaizer spellOrganaizer;

        private SerializedProperty enemyBattler;

        private SerializedProperty spellList;
        private SerializedProperty posList;

        private SerializedProperty cooldown;

        private void OnEnable()
        {
            spellOrganaizer = (SpellOrganaizer)target;

            enemyBattler = serializedObject.FindProperty("enemyBattleFSM");

            spellList = serializedObject.FindProperty("spells");
            posList = serializedObject.FindProperty("startPosSpells");

            cooldown = serializedObject.FindProperty("generalCooldown");
        }

        public override void OnInspectorGUI()
        {
            // Показываем поле со скриптом
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour(spellOrganaizer), typeof(MonoScript), false);
            float inspectorWidth = EditorGUIUtility.currentViewWidth;

            serializedObject.Update();

            EditorGUILayout.PropertyField(enemyBattler);

            EditorGUILayout.BeginVertical("Box");

            GUIStyle boldLabelStyle = new(EditorStyles.label)
            {
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter
            };
            EditorGUILayout.LabelField("Способности", boldLabelStyle);

            EditorGUILayout.Space();

            if (spellList.arraySize > 0)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUIUtility.labelWidth = 50;
                EditorGUILayout.LabelField("Способность");
                EditorGUILayout.LabelField("Стартовая позиция");
                EditorGUILayout.EndHorizontal();
            }



            for (int i = 0; i < spellList.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();

                SerializedProperty element = spellList.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(element, new GUIContent(""), includeChildren: true, GUILayout.ExpandWidth(true));

                element = posList.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(element, new GUIContent(""), includeChildren: true, GUILayout.ExpandWidth(true));

                EditorGUILayout.EndHorizontal();
            }


            if (GUILayout.Button("Add Spell"))
            {
                spellList.InsertArrayElementAtIndex(spellList.arraySize);
                posList.InsertArrayElementAtIndex(posList.arraySize);
            }
            if (spellList.arraySize > 0 && GUILayout.Button("Delete Spell"))
            {
                spellList.DeleteArrayElementAtIndex(spellList.arraySize - 1);
                posList.DeleteArrayElementAtIndex(posList.arraySize - 1);
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUIUtility.labelWidth = 150;
            EditorGUILayout.PropertyField(cooldown);

            if (cooldown.floatValue < 0)
            {
                cooldown.floatValue = 0;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}