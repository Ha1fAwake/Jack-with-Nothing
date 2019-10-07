using ReadyGamerOne.Utility;
using UnityEditor;
using UnityEngine;

namespace LudumDare.Scripts
{
    [CustomPropertyDrawer(typeof(ItemCreatable))]
    public class ItemCreateableDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var index = 0;
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("ItemName"));
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("weight"));
        }
    }
}