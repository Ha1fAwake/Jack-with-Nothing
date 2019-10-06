using ReadyGamerOne.Const;
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
            return EditorGUIUtility.singleLineHeight * 6;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var left = 0.15f;
            var style = new GUIStyle()
            {
                fontSize = 20
            };
            var nameProp = property.FindPropertyRelative("itemName");
            EditorGUI.LabelField(position.GetLeft(left),ConstStringChooser.GetShowText(nameProp),style);
            position = position.GetRight(1 - left);
            var index = 0;
            EditorGUI.LabelField(position.GetRectAtIndex(index++), "ID",property.FindPropertyRelative("id").intValue.ToString());
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), nameProp);
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("descriptions"));
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("fontSprite"));
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("infoSprite"));
            EditorGUI.PropertyField(position.GetRectAtIndex(index++), property.FindPropertyRelative("prefab"));
            EditorGUI.PropertyField(position.GetRectAtIndex(index++),
                property.FindPropertyRelative("exchangeCondition"));
        }
    }
}