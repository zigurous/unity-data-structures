using UnityEditor;

namespace Zigurous.DataStructures.Editor
{
    public abstract class RangePropertyDrawer : BasePropertyDrawer
    {
        protected abstract PropertyField.DrawFunction draw { get; }

        protected override PropertyField[] GetChildFields(SerializedProperty property) => new PropertyField[] {
            new PropertyField(property.FindPropertyRelative("_min"), this.draw),
            new PropertyField(property.FindPropertyRelative("_max"), this.draw),
        };

    }

}
