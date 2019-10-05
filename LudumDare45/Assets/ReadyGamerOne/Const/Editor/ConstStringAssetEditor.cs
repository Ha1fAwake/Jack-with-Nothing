using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ReadyGamerOne.Const.Editor
{
    [CustomEditor(typeof(ConstStringAsset))]
    public class ConstStringAssetEditor:UnityEditor.Editor
    {
        private Vector2 pos;
        [MenuItem("ReadyGamerOne/ShowConstStrings")]
        public static void CreateAsset()
        {
            Selection.activeInstanceID = ConstStringAsset.Instance.GetInstanceID();
        }


        private ReorderableList varList;
        private ConstStringAsset asset;
        private void OnEnable()
        {
            asset=target as ConstStringAsset;
            
            var varListProp = serializedObject.FindProperty("constStrings");
            this.varList = new ReorderableList(serializedObject, varListProp, false, true, true, true);
            //绘制单个元素
            varList.drawElementCallback =
                (rect, index, isActive, isFocused) =>
                {
                    EditorGUI.PropertyField(rect, varListProp.GetArrayElementAtIndex(index));
                };

        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            pos = EditorGUILayout.BeginScrollView(pos);
            varList.DoLayoutList();
            EditorGUILayout.EndScrollView();

            foreach (var VARIABLE in asset.constStrings)
            {
                if (string.IsNullOrEmpty(VARIABLE))
                {
                    EditorGUILayout.HelpBox("字符串不得为空！！！",MessageType.Error);
                }
            }
            
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}