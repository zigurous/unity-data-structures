﻿using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(EulerRange))]
    public class EulerRangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = Slider(position, property.FindPropertyRelative("_min"));
            position = Slider(position, property.FindPropertyRelative("_max"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect Slider(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 2);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            float value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.Slider(field, label, property.floatValue, -360f, 360f);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.floatValue = value;
            }

            return position;
        }

    }

}
