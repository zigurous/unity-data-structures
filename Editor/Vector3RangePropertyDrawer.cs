﻿// using UnityEditor;
// using UnityEngine;

// namespace Zigurous.DataStructures.Editor
// {
//     [CustomPropertyDrawer(typeof(Vector3Range))]
//     public sealed class Vector3RangePropertyDrawer : PropertyDrawer
//     {
//         private SerializedProperty _min;
//         private SerializedProperty _max;

//         public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//         {
//             if (_min == null) { _min = property.FindPropertyRelative("min"); }
//             if (_max == null) { _max = property.FindPropertyRelative("max"); }

//             position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

//             float half = position.width / 2.0f;
//             position.width /= 2.0f;
//             position.width -= 1.5f;

//             float labelWidth = EditorGUIUtility.labelWidth;
//             int indentLevel = EditorGUI.indentLevel;
//             EditorGUI.indentLevel = 0;

//             // Min
//             EditorGUIUtility.labelWidth = 24.0f;
//             EditorGUI.BeginProperty(position, label, _min);
//             {
//                 EditorGUI.BeginChangeCheck();
//                 Vector3 value = EditorGUI.Vector3Field(position, "Min", _min.vector3Value);

//                 if (EditorGUI.EndChangeCheck()) {
//                     _min.vector3Value = value;
//                 }
//             }
//             EditorGUI.EndProperty();
//             position.x += half + 1.5f;

//             // Max
//             EditorGUIUtility.labelWidth = 28.0f;
//             EditorGUI.BeginProperty(position, label, _max);
//             {
//                 EditorGUI.BeginChangeCheck();
//                 Vector3 value = EditorGUI.Vector3Field(position, "Max", _max.vector3Value);

//                 if (EditorGUI.EndChangeCheck()) {
//                     _max.vector3Value = value;
//                 }
//             }
//             EditorGUI.EndProperty();

//             // Reset editor properties
//             EditorGUIUtility.labelWidth = labelWidth;
//             EditorGUI.indentLevel = indentLevel;
//         }

//     }

// }