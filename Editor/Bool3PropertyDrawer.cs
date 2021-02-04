using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(Bool3))]
    public sealed class Bool3PropertyDrawer : PropertyDrawer
    {
        private SerializedProperty _x;
        private SerializedProperty _y;
        private SerializedProperty _z;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_x == null) { _x = property.FindPropertyRelative("x"); }
            if (_y == null) { _y = property.FindPropertyRelative("y"); }
            if (_z == null) { _z = property.FindPropertyRelative("z"); }

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            float third = position.width / 3.0f;
            position.width /= 3.0f;
            position.width -= 3.0f;

            float labelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 10.0f;

            // X
            EditorGUI.BeginProperty(position, label, _x);
            {
                EditorGUI.BeginChangeCheck();
                bool value = EditorGUI.Toggle(position, "X", _x.boolValue);

                if (EditorGUI.EndChangeCheck()) {
                    _x.boolValue = value;
                }
            }
            EditorGUI.EndProperty();
            position.x += third + 1.5f;

            // Y
            EditorGUI.BeginProperty(position, label, _y);
            {
                EditorGUI.BeginChangeCheck();
                bool value = EditorGUI.Toggle(position, "Y", _y.boolValue);

                if (EditorGUI.EndChangeCheck()) {
                    _y.boolValue = value;
                }
            }
            EditorGUI.EndProperty();
            position.x += third + 1.5f;

            // Z
            EditorGUI.BeginProperty(position, label, _z);
            {
                EditorGUI.BeginChangeCheck();
                bool value = EditorGUI.Toggle(position, "Z", _z.boolValue);

                if (EditorGUI.EndChangeCheck()) {
                    _z.boolValue = value;
                }
            }
            EditorGUI.EndProperty();

            // Reset editor properties
            EditorGUIUtility.labelWidth = labelWidth;
        }

    }

}
