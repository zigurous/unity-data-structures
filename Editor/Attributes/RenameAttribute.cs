using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    public class RenameAttribute : PropertyAttribute
    {
        public string newName;

        public RenameAttribute(string newName)
        {
            this.newName = newName;
        }

    }

    [CustomPropertyDrawer(typeof(RenameAttribute))]
    public class RenamePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, new GUIContent((attribute as RenameAttribute).newName));
        }

    }

}
