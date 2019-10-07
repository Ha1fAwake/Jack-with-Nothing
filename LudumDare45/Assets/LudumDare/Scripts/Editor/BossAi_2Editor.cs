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
        private SerializedProperty testLayerProp;
        private SerializedProperty rectProp;
        private SerializedProperty duringTimeProp;
        private SerializedProperty createCountProp;
        private SerializedProperty createInfosProp;
        private SerializedProperty itemCountAtOneTimeProp;

        private SerializedProperty offsetProp;
        private BossAi_2 ai;

        private void OnEnable()
        {
            ai=target as BossAi_2;
            mapUnitSizeProp = serializedObject.FindProperty("mapUnitSize");
            rectProp = serializedObject.FindProperty("map");
            duringTimeProp = serializedObject.FindProperty("duringTime");
            testLayerProp = serializedObject.FindProperty("testLayer");
            createCountProp = serializedObject.FindProperty("createCount");
            itemCountAtOneTimeProp = serializedObject.FindProperty("itemCountAtOneTime");
            createInfosProp = serializedObject.FindProperty("createInfos");

            offsetProp = serializedObject.FindProperty("offset");
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

            EditorGUILayout.PropertyField(testLayerProp);
            EditorGUILayout.PropertyField(mapUnitSizeProp);
            EditorGUILayout.PropertyField(rectProp);
            EditorGUILayout.PropertyField(offsetProp);
            EditorGUILayout.PropertyField(duringTimeProp);
            EditorGUILayout.PropertyField(createCountProp);
            EditorGUILayout.PropertyField(itemCountAtOneTimeProp);
            
            list.DoLayoutList();

            

            serializedObject.ApplyModifiedProperties();
        }
    }
}