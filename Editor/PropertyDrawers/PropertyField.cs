using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    public struct PropertyField
    {
        public delegate void DrawFunction(PropertyField property, Rect position);

        public SerializedProperty property;
        public DrawFunction draw;
        public GUIContent label;

        public PropertyField(SerializedProperty property, DrawFunction draw)
        {
            this.property = property;
            this.draw = draw;
            this.label = new GUIContent(property.displayName);
        }

        public PropertyField(SerializedProperty property, DrawFunction draw, string label)
        {
            this.property = property;
            this.draw = draw;
            this.label = new GUIContent(label);
        }

        public PropertyField(SerializedProperty property, DrawFunction draw, GUIContent label)
        {
            this.property = property;
            this.draw = draw;
            this.label = label;
        }

        public void Draw(Rect position) => this.draw.Invoke(this, position);

    }

}
