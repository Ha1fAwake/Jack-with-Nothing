using ReadyGamerOne.Utility;
using UnityEditor;
using UnityEngine;

namespace LudumDare.Model.Editor
{
    [CustomPropertyDrawer(typeof(MergeInfo))]
    public class MergeInfoDrawer:PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 4;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var mgr = property.FindPropertyRelative("mgr").objectReferenceValue as ItemMgr;
            var showStrings = mgr.ItemNames;
            var index = 0;

            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("prefab"));
            
            var targetIdProp = property.FindPropertyRelative("targetIdIndex");
            targetIdProp.intValue= EditorGUI.Popup(position.GetRectAtIndex(index++), "目标物品", targetIdProp.intValue, showStrings);

            var sourId1Prop = property.FindPropertyRelative("sourId1Index");
            sourId1Prop.intValue = EditorGUI.Popup(position.GetRectAtIndex(index++), "材料一", sourId1Prop.intValue,
                showStrings);

            var sourId2Prop = property.FindPropertyRelative("sourId2Index");
            sourId2Prop.intValue = EditorGUI.Popup(position.GetRectAtIndex(index++), "材料二", sourId2Prop.intValue,
                showStrings);
        }
    }
}