using System;
using UnityEngine;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Size : IEquatable<Size>, IComparable<Size>
    {
        /// <summary>
        /// The width of the entity.
        /// </summary>
        [Tooltip("The width of the entity.")]
        public int width;

        /// <summary>
        /// The height of the entity.
        /// </summary>
        [Tooltip("The height of the entity.")]
        public int height;

        /// <summary>
        /// Calculates the area of the dimensions (width * height).
        /// </summary>
        public int Area => System.Math.Abs(this.width * this.height);

        /// <summary>
        /// Shorthand for writing Size(0, 0).
        /// </summary>
        public static Size Zero => new Size(0, 0);

        /// <summary>
        /// Shorthand for writing Size(1, 1).
        /// </summary>
        public static Size One => new Size(1, 1);

        /// <summary>
        /// Shorthand for writing Size(int.MaxValue, int.MaxValue).
        /// </summary>
        public static Size Max => new Size(int.MaxValue, int.MaxValue);

        /// <summary>
        /// Creates a new Size of given width and height.
        /// </summary>
        public Size(int width = 0, int height = 0)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Creates a new Size with uniform width and height.
        /// </summary>
        public Size(int size)
        {
            this.width = size;
            this.height = size;
        }

        public override string ToString()
        {
            return String.Format("(width: {0}, height: {0})", this.width, this.height);
        }

        public bool Equals(Size other)
        {
            return this.width == other.width &&
                   this.height == other.height;
        }

        public override bool Equals(object obj)
        {
            if (obj is Size size) {
                return Equals(size);
            } else {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.width.GetHashCode(), this.height.GetHashCode());
        }

        public int CompareTo(Size other)
        {
            int a = this.Area;
            int b = other.Area;

            if (a == b) return 0;
            else if (a > b) return 1;
            else return -1;
        }

        public static bool operator ==(Size lhs, Size rhs) => lhs.Equals(rhs);
        public static bool operator !=(Size lhs, Size rhs) => !lhs.Equals(rhs);

    }

}
