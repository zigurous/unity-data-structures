using System;
using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Stores the size of an entity.
    /// </summary>
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

        /// <returns>
        /// The area of the entity (width * height).
        /// </returns>
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

        /// <summary>Creates a new size of the given <paramref name="width"/> and <paramref name="height"/>.</summary>
        /// <param name="width">The width of the entity.</param>
        /// <param name="height">The height of the entity.</param>
        public Size(int width = 0, int height = 0)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>Creates a new size with uniform width and height.</summary>
        /// <param name="size">The uniform size of the entity.</param>
        public Size(int size)
        {
            this.width = size;
            this.height = size;
        }

        /// <summary>
        /// <see cref="IComparable{T}.CompareTo(T)"/>.
        /// </summary>
        /// <param name="other">The size to compare to.</param>
        public int CompareTo(Size other)
        {
            int a = this.Area;
            int b = other.Area;

            if (a == b) return 0;
            else if (a > b) return 1;
            else return -1;
        }

        /// <returns>True if the size is equal to the <paramref name="other"/>.</returns>
        /// <param name="other">The size to compare to.</param>
        public bool Equals(Size other)
        {
            return this.width == other.width &&
                   this.height == other.height;
        }

        /// <returns>True if the size is equal to the <paramref name="other"/>.</returns>
        /// <param name="other">The object to compare to.</param>
        public override bool Equals(object other)
        {
            if (other is Size size) {
                return Equals(size);
            } else {
                return false;
            }
        }

        /// <returns>
        /// The hash code of the size.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.width.GetHashCode(), this.height.GetHashCode());
        }

        /// <returns>
        /// The string representation of the size.
        /// </returns>
        public override string ToString()
        {
            return $"{this.width.ToString()}x{this.height.ToString()}";
        }

        public static bool operator ==(Size lhs, Size rhs) => lhs.Equals(rhs);
        public static bool operator !=(Size lhs, Size rhs) => !lhs.Equals(rhs);

    }

}
