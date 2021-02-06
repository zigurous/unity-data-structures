using UnityEditor;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(UIntRange))]
    public sealed class UIntRangePropertyDrawer : RangePropertyDrawer
    {
        protected override PropertyField.DrawFunction draw =>
            PropertyDrawerUtility.UIntFieldWithChangeCheck;
    }

}
