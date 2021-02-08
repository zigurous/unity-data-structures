using System;

namespace Zigurous.DataStructures
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    public sealed class ConditionalHideAttribute : ConditionalAttribute
    {
        public ConditionalHideAttribute(string boolField)
        {
            this.field = boolField;
            this.fieldType = FieldType.Default;
            this.show = false;
        }

        public ConditionalHideAttribute(string sliderField, float minValue, float maxValue)
        {
            this.field = sliderField;
            this.fieldType = FieldType.Slider;
            this.show = false;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public ConditionalHideAttribute(string enumField, int enumValue, bool enumFlags = false)
        {
            this.field = enumField;
            this.fieldType = FieldType.Enum;
            this.show = false;
            this.enumValue = enumValue;
            this.enumFlags = enumFlags;
        }

    }

}
