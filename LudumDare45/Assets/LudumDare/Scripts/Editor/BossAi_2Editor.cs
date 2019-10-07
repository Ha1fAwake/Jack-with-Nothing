using System;
using UnityEditor;
using UnityEditorInternal;

namespace LudumDare.Scripts.Editor
{
    [CustomEditor(typeof(BossAi_2))]
    public class BossAi_2Editor:UnityEditor.Editor
    {
        private ReorderableList list;
        private SerializedProperty mapUnitSizeProp;
        private SerializedProperty rectProp;
        private SerializedProperty duringTimeProp;
        private SerializedProperty createCountProp;
        private SerializedProperty createInfosProp;

        private BossAi_2 ai;

        private void OnEnable()
        {
            ai=target as BossAi_2;
            mapUnitSizeProp = serializedObject.FindProperty("mapUnitSize");
            rectProp = serializedObject.FindProperty("rect");
            duringTimeProp = serializedObject.FindProperty("duringTime");
            createCountProp = serializedObject.FindProperty("createCount");
            createInfosProp = serializedObject.FindProperty("createInfos");

            list = new ReorderableList(serializedObject, createInfosProp, true, true, true, true);

            list.elementHeight = 2 * EditorGUIUtility.singleLineHeight;
            list.drawElementCallback = (rect, index, x, y) =>
            {
                var prop = createInfosProp.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(rect, prop);
            };
            list.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "创建信息");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(mapUnitSizeProp);
            EditorGUILayout.PropertyField(rectProp);
            EditorGUILayout.PropertyField(duringTimeProp);
            EditorGUILayout.PropertyField(createCountProp);
            list.DoLayoutList();

            

            serializedObject.ApplyModifiedProperties();
        }
    }
}