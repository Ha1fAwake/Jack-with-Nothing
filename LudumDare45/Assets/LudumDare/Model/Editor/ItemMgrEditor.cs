using System;
using UnityEditor;
using UnityEditorInternal;

namespace LudumDare.Model.Editor
{
    [CustomEditor(typeof(ItemMgr))]
    public class ItemMgrEditor:UnityEditor.Editor
    {
        private ReorderableList reorderableList;
        private SerializedProperty listProp;
        private ItemMgr mgr;
        private void OnEnable()
        {
            mgr=target as ItemMgr;
            listProp = serializedObject.FindProperty("itemInfos");
            reorderableList = new ReorderableList(serializedObject, listProp, true,
                true, true,true);
            reorderableList.elementHeight = 4 * EditorGUIUtility.singleLineHeight;
            reorderableList.drawElementCallback = (rect, index, x, y) =>
            {
                var prop = listProp.GetArrayElementAtIndex(index++);
                EditorGUI.PropertyField(rect, prop);
            };

            reorderableList.onAddCallback = OnAddItem;

            reorderableList.drawHeaderCallback = (rect) =>
                EditorGUI.LabelField(rect, "物品信息");

        }

        private void OnAddItem(ReorderableList list)
        {
            var size = listProp.arraySize;
            listProp.arraySize++;
            list.index = size;

            var itemProp = listProp.GetArrayElementAtIndex(size);

            itemProp.FindPropertyRelative("id").intValue = mgr.GetID();

            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            reorderableList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}