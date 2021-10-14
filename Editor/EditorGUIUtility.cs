using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    internal static class EditorGUIUtility
    {
        internal static float singleLineHeight => UnityEditor.EditorGUIUtility.singleLineHeight;
        internal static float standardVerticalSpacing => UnityEditor.EditorGUIUtility.standardVerticalSpacing;
        internal const float standardHorizontalSpacing = 4f;

        internal static Rect GetFieldRect(Rect position, int columns)
        {
            float spacing = standardHorizontalSpacing * (columns - 1);
            position.width = (position.width - spacing) / columns;
            return position;
        }

        internal static T FieldWrapper<T>(string label, System.Func<GUIContent, T> draw)
        {
            GUIContent content = new GUIContent(label);

            float labelWidth = EditorStyles.label.CalcSize(content).x;
            float originalWidth = UnityEditor.EditorGUIUtility.labelWidth;

            UnityEditor.EditorGUIUtility.labelWidth = labelWidth;

            T value = draw(content);

            UnityEditor.EditorGUIUtility.labelWidth = originalWidth;

            return value;
        }

    }

}
