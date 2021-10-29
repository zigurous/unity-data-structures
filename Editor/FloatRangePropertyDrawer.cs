﻿using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(FloatRange))]
    public class FloatRangePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            position = FloatField(position, property.FindPropertyRelative("m_Min"));
            position = FloatField(position, property.FindPropertyRelative("m_Max"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();
        }

        private Rect FloatField(Rect position, SerializedProperty property)
        {
            Rect field = EditorGUIUtility.GetFieldRect(position, 2);
            position.x += field.width + EditorGUIUtility.standardHorizontalSpacing;

            EditorGUI.BeginChangeCheck();

            float value = EditorGUIUtility.FieldWrapper(property.displayName, (label) => {
                return EditorGUI.FloatField(field, label, property.floatValue);
            });

            if (EditorGUI.EndChangeCheck()) {
                property.floatValue = value;
            }

            return position;
        }

    }

}
