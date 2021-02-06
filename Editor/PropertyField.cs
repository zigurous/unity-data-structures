using UnityEditor;
using UnityEngine;

namespace Zigurous.DataStructures.Editor
{
    public struct PropertyField
    {
        public delegate void DrawFunction(PropertyField property, Rect position);

        public SerializedProperty property;
        public DrawFunction draw;
        public string label;

        public PropertyField(SerializedProperty property, DrawFunction draw)
        {
            this.property = property;
            this.draw = draw;
            this.label = property.displayName;
        }

        public PropertyField(SerializedProperty property, DrawFunction draw, string label)
        {
            this.property = property;
            this.draw = draw;
            this.label = label;
        }

        public void Draw(Rect position) => this.draw.Invoke(this, position);

    }

}
