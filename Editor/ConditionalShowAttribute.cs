using System;

namespace Zigurous.DataStructures
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    public sealed class ConditionalShowAttribute : ConditionalAttribute
    {
        public ConditionalShowAttribute(string boolField)
        {
            this.field = boolField;
            this.fieldType = FieldType.Default;
            this.show = true;
        }

        public ConditionalShowAttribute(string sliderField, float minValue, float maxValue)
        {
            this.field = sliderField;
            this.fieldType = FieldType.Slider;
            this.show = true;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public ConditionalShowAttribute(string enumField, int enumValue, bool enumFlags = false)
        {
            this.field = enumField;
            this.fieldType = FieldType.Enum;
            this.show = true;
            this.enumValue = enumValue;
            this.enumFlags = enumFlags;
        }

    }

}
