using UnityEditor;

namespace Zigurous.DataStructures.Editor
{
    [CustomPropertyDrawer(typeof(Bool3))]
    public sealed class Bool3PropertyDrawer : BasePropertyDrawer
    {
        protected override PropertyField[] GetChildFields(SerializedProperty property) => new PropertyField[] {
            new PropertyField(property.FindPropertyRelative("x"), PropertyDrawerUtility.BoolFieldWithChangeCheck),
            new PropertyField(property.FindPropertyRelative("y"), PropertyDrawerUtility.BoolFieldWithChangeCheck),
            new PropertyField(property.FindPropertyRelative("z"), PropertyDrawerUtility.BoolFieldWithChangeCheck),
        };

    }

}
