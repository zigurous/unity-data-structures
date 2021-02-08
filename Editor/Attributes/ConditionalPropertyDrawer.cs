using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures
{
    [CustomPropertyDrawer(typeof(ConditionalAttribute))]
    [CustomPropertyDrawer(typeof(ConditionalShowAttribute))]
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public sealed class ConditionalPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ConditionalAttribute conditionalAttribute = (ConditionalAttribute)attribute;

            bool enabled = GetConditionalAttributeResult(conditionalAttribute, property) == conditionalAttribute.show;

            if (enabled)
            {
                switch (conditionalAttribute.fieldType)
                {
                    case ConditionalAttribute.FieldType.Slider:
                        EditorGUI.Slider(position, property, conditionalAttribute.minValue, conditionalAttribute.maxValue, label);
                        break;

                    case ConditionalAttribute.FieldType.Enum:
                    case ConditionalAttribute.FieldType.Default:
                    default:
                        EditorGUI.PropertyField(position, property, label, true);
                        break;
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ConditionalAttribute conditionalAttribute = (ConditionalAttribute)attribute;
            bool enabled = GetConditionalAttributeResult(conditionalAttribute, property) == conditionalAttribute.show;

            if (enabled) {
                return EditorGUI.GetPropertyHeight(property, label);
            }

            // We want to undo the spacing added before and after the property
            return -EditorGUIUtility.standardVerticalSpacing;
        }

        private bool GetConditionalAttributeResult(ConditionalAttribute attribute, SerializedProperty property)
        {
            SerializedProperty updatedProperty = null;

            if (true /*!property.isArray*/)
            {
                // Get the full relative property path of the attribute field so we can have nested hiding
                string propertyPath = property.propertyPath;
                string conditionPath = propertyPath.Replace(property.name, attribute.field);
                updatedProperty = property.serializedObject.FindProperty(conditionPath);
            }

            // Fallback to the original implementation (does not work with nested serializedObjects)
            if (updatedProperty == null) {
                updatedProperty = property.serializedObject.FindProperty(attribute.field);
            }

            // Verify the property type is supported
            if (updatedProperty != null) {
                return CheckPropertyType(attribute, updatedProperty);
            }

            return true;
        }

        private bool CheckPropertyType(ConditionalAttribute attribute, SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return property.boolValue;
                case SerializedPropertyType.Enum:
                    if (attribute.enumFlags) {
                        return new Bitmask(property.intValue).HasFlag(attribute.enumValue);
                    } else {
                        return property.enumValueIndex == attribute.enumValue;
                    }
                default:
                    Debug.LogError("The data type of the property used for conditional hiding [" + property.propertyType + "] is not currently supported.");
                    return true;
            }
        }

    }

}
