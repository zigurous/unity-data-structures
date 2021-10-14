﻿using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(Size))]
    public class SizePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = IntField(position, property.FindPropertyRelative("width"));
            position = IntField(position, property.FindPropertyRelative("height"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect IntField(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 2);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            int value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.IntField(field, label, property.intValue);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.intValue = value;
            }

            return position;
        }

    }

}
