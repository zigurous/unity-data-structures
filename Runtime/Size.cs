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
        /// Calculates the area (width * height).
        /// </summary>
        public int Area => System.Math.Abs(this.width * this.height);

        /// <summary>
        /// Shorthand for writing Size(0, 0).
        /// </summary>
        public static Size zero => new Size(0, 0);

        /// <summary>
        /// Shorthand for writing Size(1, 1).
        /// </summary>
        public static Size one => new Size(1, 1);

        /// <summary>
        /// Shorthand for writing Size(int.MaxValue, int.MaxValue).
        /// </summary>
        public static Size max => new Size(int.MaxValue, int.MaxValue);

        /// <summary>
        /// Shorthand for writing Size(2).
        /// </summary>
        public static Size sq2 => new Size(2);

        /// <summary>
        /// Shorthand for writing Size(4).
        /// </summary>
        public static Size sq4 => new Size(4);

        /// <summary>
        /// Shorthand for writing Size(8).
        /// </summary>
        public static Size sq8 => new Size(8);

        /// <summary>
        /// Shorthand for writing Size(16).
        /// </summary>
        public static Size sq16 => new Size(16);

        /// <summary>
        /// Shorthand for writing Size(32).
        /// </summary>
        public static Size sq32 => new Size(32);

        /// <summary>
        /// Shorthand for writing Size(64).
        /// </summary>
        public static Size sq64 => new Size(64);

        /// <summary>
        /// Shorthand for writing Size(128).
        /// </summary>
        public static Size sq128 => new Size(128);

        /// <summary>
        /// Shorthand for writing Size(256).
        /// </summary>
        public static Size sq256 => new Size(256);

        /// <summary>
        /// Shorthand for writing Size(512).
        /// </summary>
        public static Size sq512 => new Size(512);

        /// <summary>
        /// Shorthand for writing Size(1024).
        /// </summary>
        public static Size sq1024 => new Size(1024);

        /// <summary>
        /// Shorthand for writing Size(2048).
        /// </summary>
        public static Size sq2048 => new Size(2048);

        /// <summary>
        /// Shorthand for writing Size(4096).
        /// </summary>
        public static Size sq4096 => new Size(4096);

        /// <summary>
        /// Shorthand for writing Size(8192).
        /// </summary>
        public static Size sq8192 => new Size(8192);

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
            return String.Format("(width: {0}, height: {1})", this.width, this.height);
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
