using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    public static class PropertyDrawerUtility
    {
        public static float standardHorizontalSpacing = 4.0f;

        public static void FloatFieldWithChangeCheck(PropertyField field, Rect position)
        {
            EditorGUI.BeginChangeCheck();

            float value = EditorGUI.FloatField(position, field.label, field.property.floatValue);

            if (EditorGUI.EndChangeCheck()) {
                field.property.floatValue = value;
            }
        }

        public static void IntFieldWithChangeCheck(PropertyField field, Rect position)
        {
            EditorGUI.BeginChangeCheck();

            int value = EditorGUI.IntField(position, field.label, field.property.intValue);

            if (EditorGUI.EndChangeCheck()) {
                field.property.intValue = value;
            }
        }

        public static void UIntFieldWithChangeCheck(PropertyField field, Rect position)
        {
            EditorGUI.BeginChangeCheck();

            uint value = (uint)EditorGUI.IntField(position, field.label, field.property.intValue);

            if (EditorGUI.EndChangeCheck()) {
                field.property.intValue = (int)value;
            }
        }

        public static void Vector2FieldWithChangeCheck(PropertyField field, Rect position)
        {
            EditorGUI.BeginChangeCheck();

            Vector2 value = EditorGUI.Vector2Field(position, field.label, field.property.vector2Value);

            if (EditorGUI.EndChangeCheck()) {
                field.property.vector2Value = value;
            }
        }

        public static void Vector3FieldWithChangeCheck(PropertyField field, Rect position)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 value = EditorGUI.Vector3Field(position, field.label, field.property.vector3Value);

            if (EditorGUI.EndChangeCheck()) {
                field.property.vector3Value = value;
            }
        }

        public static Rect AdvanceFieldPosition(Rect position, Rect field, int index, int columns)
        {
            int column = index % columns;

            if (column == 0)
            {
                // Advance row
                field.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                field.x = position.x;
            }
            else
            {
                // Advance column
                field.x += field.width + standardHorizontalSpacing;
            }

            return field;
        }

        public static float CalculateFieldWidth(Rect position, int columns)
        {
            return (position.width - (standardHorizontalSpacing * (columns - 1))) / columns;
        }

    }

}
