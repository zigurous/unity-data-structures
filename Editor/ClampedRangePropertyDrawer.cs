﻿using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(ClampedRange))]
    public class ClampedRangePropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return (EditorGUIUtility.singleLineHeight * 3f) +
                   (EditorGUIUtility.standardVerticalSpacing * 2f);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            SerializedProperty range = property.FindPropertyRelative("range");
            SerializedProperty clamp = property.FindPropertyRelative("clamp");

            position = RangeProperty(position, range);
            position = RangeProperty(position, clamp);

            SerializedProperty rangeMin = range.FindPropertyRelative("_min");
            SerializedProperty rangeMax = range.FindPropertyRelative("_max");

            SerializedProperty clampMin = clamp.FindPropertyRelative("_min");
            SerializedProperty clampMax = clamp.FindPropertyRelative("_max");

            rangeMin.floatValue = Mathf.Clamp(rangeMin.floatValue, clampMin.floatValue, clampMax.floatValue);
            rangeMax.floatValue = Mathf.Clamp(rangeMax.floatValue, clampMin.floatValue, clampMax.floatValue);

            EditorGUI.EndProperty();
        }

        private Rect RangeProperty(Rect position, SerializedProperty property)
        {
            position.y += EditorGUIUtility.singleLineHeight;
            position.y += EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.BeginProperty(position, new GUIContent(property.displayName), property);

            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel++;

            Rect field = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent(property.displayName));

            EditorGUI.indentLevel = 0;

            field = FloatField(field, property.FindPropertyRelative("_min"));
            field = FloatField(field, property.FindPropertyRelative("_max"));

            EditorGUI.indentLevel = indentLevel;
            EditorGUI.EndProperty();

            return position;
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
