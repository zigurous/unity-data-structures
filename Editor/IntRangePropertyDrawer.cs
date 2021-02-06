using UnityEditor;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(IntRange))]
    public sealed class IntRangePropertyDrawer : RangePropertyDrawer
    {
        protected override PropertyField.DrawFunction draw =>
            PropertyDrawerUtility.IntFieldWithChangeCheck;
    }

}
