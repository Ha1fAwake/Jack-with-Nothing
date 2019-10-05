using UnityEditor;
using UnityEngine;

namespace ReadyGamerOne.Const.Editor
{
    [CustomPropertyDrawer(typeof(ConstStringChooser))]
    public class ConstStringChooserDrawer:PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var indexProp = property.FindPropertyRelative("selectedIndex");
            indexProp.intValue = EditorGUI.Popup(position, property.displayName, indexProp.intValue,
                ConstStringAsset.Instance.constStrings.ToArray());
        }
    }
}