using System;
using UnityEngine;

namespace Zigurous.DataStructures
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    public abstract class ConditionalAttribute : PropertyAttribute
    {
        public enum FieldType
        {
            Default,
            Enum,
            Slider,
        }

        // General
        public string field;
        public FieldType fieldType;
        public bool show;

        // Enum
        public int enumValue;
        public bool enumFlags;

        // Slider
        public float minValue;
        public float maxValue;

    }

}
