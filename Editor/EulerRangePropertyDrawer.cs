// using UnityEditor;
// using UnityEngine;

// namespace Zigurous.DataStructures.Editor
// {
//     [CustomPropertyDrawer(typeof(EulerRange))]
//     public sealed class EulerRangePropertyDrawer : PropertyDrawer
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
//                 EditorGUI.Slider(position, _min, -360.0f, 360.0f, "Min");
//             }
//             EditorGUI.EndProperty();
//             position.x += half + 1.5f;

//             // Max
//             EditorGUIUtility.labelWidth = 28.0f;
//             EditorGUI.BeginProperty(position, label, _max);
//             {
//                 EditorGUI.BeginChangeCheck();
//                 EditorGUI.Slider(position, _max, -360.0f, 360.0f, "Max");
//             }
//             EditorGUI.EndProperty();

//             // Reset editor properties
//             EditorGUIUtility.labelWidth = labelWidth;
//             EditorGUI.indentLevel = indentLevel;
//         }

//     }

// }
