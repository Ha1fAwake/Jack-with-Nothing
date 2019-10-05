using ReadyGamerOne.Utility;
using UnityEditor;
using UnityEngine;

namespace LudumDare.Model.Editor
{
    [CustomPropertyDrawer(typeof(BasicItem))]
    public class BasicItemDrawer:PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 4;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var index = 0;
            EditorGUI.LabelField(position.GetRectAtIndex(index++), "ID",property.FindPropertyRelative("id").intValue.ToString());
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("itemName"));
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("descriptions"));
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("sprite"));
        }
    }
}