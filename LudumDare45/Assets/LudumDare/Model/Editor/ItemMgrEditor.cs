using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace LudumDare.Model.Editor
{
    [CustomEditor(typeof(ItemMgr))]
    public class ItemMgrEditor:UnityEditor.Editor
    {
        private Vector2 pos;
        private ReorderableList itemList;
        private SerializedProperty itemListProp;
        private ReorderableList mergeInfoList;
        private SerializedProperty mergeInfoListProp;
        private ItemMgr mgr;
        
        private void OnEnable()
        {
            mgr=target as ItemMgr;

            #region ItemList

            itemListProp = serializedObject.FindProperty("itemInfos");
            itemList = new ReorderableList(serializedObject, itemListProp, false,
                true, true,true);
            itemList.elementHeight = 7 * EditorGUIUtility.singleLineHeight;
            itemList.drawElementCallback = (rect, index, x, y) =>
            {
                var prop = itemListProp.GetArrayElementAtIndex(index++);
                EditorGUI.PropertyField(rect, prop);
            };
            itemList.onAddCallback = OnAddItem;
            itemList.drawHeaderCallback = (rect) =>
                EditorGUI.LabelField(rect, "物品信息");            

            #endregion

            #region MergeInfoList

            mergeInfoListProp = serializedObject.FindProperty("merageInfos");
            mergeInfoList = new ReorderableList(serializedObject, mergeInfoListProp, false, true, true, true);

            mergeInfoList.elementHeight = 3 * EditorGUIUtility.singleLineHeight;
            mergeInfoList.drawElementCallback = (rect, index, x, y) =>
            {
                var prop = mergeInfoListProp.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(rect, prop);
            };

            mergeInfoList.onAddCallback = OnAddMergeInfo;

            mergeInfoList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "合成信息");


            #endregion
        }

        private void OnAddMergeInfo(ReorderableList list)
        {
            var size = mergeInfoListProp.arraySize;
            mergeInfoListProp.arraySize++;
            list.index = size;

            var mergeProp = mergeInfoListProp.GetArrayElementAtIndex(size);
            mergeProp.FindPropertyRelative("mgr").objectReferenceValue = mgr;
            serializedObject.ApplyModifiedProperties();
        }

        private void OnAddItem(ReorderableList list)
        {
            var size = itemListProp.arraySize;
            itemListProp.arraySize++;
            list.index = size;

            var itemProp = itemListProp.GetArrayElementAtIndex(size);

            itemProp.FindPropertyRelative("id").intValue = mgr.GetID();

            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            pos= EditorGUILayout.BeginScrollView(pos);
            itemList.DoLayoutList();
            mergeInfoList.DoLayoutList();
            EditorGUILayout.EndScrollView();
            serializedObject.ApplyModifiedProperties();
        }
    }
}