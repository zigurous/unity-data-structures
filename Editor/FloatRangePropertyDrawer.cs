using UnityEditor;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(FloatRange))]
    public sealed class FloatRangePropertyDrawer : RangePropertyDrawer
    {
        protected override PropertyField.DrawFunction draw =>
            PropertyDrawerUtility.FloatFieldWithChangeCheck;
    }

}
