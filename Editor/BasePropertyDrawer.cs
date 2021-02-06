using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    public abstract class BasePropertyDrawer : PropertyDrawer
    {
        protected PropertyField[] _fields;
        protected virtual int fieldColumns => 2;
        protected virtual bool drawPropertyLabel => true;
        protected virtual bool indentChildFields => false;

        protected abstract PropertyField[] GetChildFields(SerializedProperty property);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Start drawing the property
            EditorGUI.BeginProperty(position, label, property);

            // Draw the property label
            if (this.drawPropertyLabel) {
                position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            }

            // Store orginal sizes so they can be set back to their original values
            int indent = EditorGUI.indentLevel;
            float labelWidth = EditorGUIUtility.labelWidth;

            // Do not make child fields indented
            if (!this.indentChildFields) {
                EditorGUI.indentLevel = 0;
            }

            // Create references to child fields
            if (_fields == null) {
                _fields = GetChildFields(property);
            }

            // Draw child fields
            if (_fields != null)
            {
                Rect rect = new Rect(position);
                rect.width = PropertyDrawerUtility.CalculateFieldWidth(position, this.fieldColumns);

                for (int i = 0; i < _fields.Length; i++)
                {
                    // Draw the current field
                    PropertyField field = _fields[i];

                    // Calculate the width of the field label
                    float fieldLabelWidth = EditorStyles.label.CalcSize(new GUIContent(field.label)).x;
                    EditorGUIUtility.labelWidth = fieldLabelWidth;

                    field.Draw(rect);

                    // Move the field rect to the next position
                    rect = PropertyDrawerUtility.AdvanceFieldPosition(position, rect, i + 1, this.fieldColumns);
                }
            }

            // Set sizes back to their original values
            EditorGUI.indentLevel = indent;
            EditorGUIUtility.labelWidth = labelWidth;

            // Finish drawing the property
            EditorGUI.EndProperty();
        }

    }

}
