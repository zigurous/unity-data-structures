using System;
using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Stores a tuple of 3 booleans.
    /// </summary>
    [System.Serializable]
    public struct Bool3 : IEquatable<Bool3>
    {
        /// <summary>
        /// The X component.
        /// </summary>
        [Tooltip("The X component.")]
        public bool x;

        /// <summary>
        /// The Y component.
        /// </summary>
        [Tooltip("The Y component.")]
        public bool y;

        /// <summary>
        /// The Z component.
        /// </summary>
        [Tooltip("The Z component.")]
        public bool z;

        /// <summary>
        /// Shorthand for writing Bool3(false, false, false).
        /// </summary>
        public static Bool3 False => new Bool3(false, false, false);

        /// <summary>
        /// Shorthand for writing Bool3(true, true, true).
        /// </summary>
        public static Bool3 True => new Bool3(true, true, true);

        /// <summary>
        /// Shorthand for writing Bool3(true, false, false).
        /// </summary>
        public static Bool3 X => new Bool3(true, false, false);

        /// <summary>
        /// Shorthand for writing Bool3(false, true, false).
        /// </summary>
        public static Bool3 Y => new Bool3(false, true, false);

        /// <summary>
        /// Shorthand for writing Bool3(false, false, true).
        /// </summary>
        public static Bool3 Z => new Bool3(false, false, true);

        /// <summary>
        /// Creates a new Bool3 with the specified values.
        /// </summary>
        /// <param name="x">The X component.</param>
        /// <param name="y">The Y component.</param>
        /// <param name="z">The Z component.</param>
        public Bool3(bool x = false, bool y = false, bool z = false)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Determines if the tuple is equal to <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The tuple to compare to.</param>
        public bool Equals(Bool3 other)
        {
            return this.x == other.x &&
                   this.y == other.y &&
                   this.z == other.z;
        }

        /// <summary>
        /// Determines if the tuple is equal to <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        public override bool Equals(object other)
        {
            if (other is Bool3 bool3) {
                return Equals(bool3);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the tuple.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.x.GetHashCode(), this.y.GetHashCode(), this.z.GetHashCode());
        }

        /// <summary>
        /// Converts the tuple to a string.
        /// </summary>
        /// <returns>A string representation of the tuple.</returns>
        public override string ToString()
        {
            return $"{this.x.ToString()}, {this.y.ToString()}, {this.z.ToString()}";
        }

        /// <summary>
        /// Gets or sets the component at the given <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the component to get or set.</param>
        public bool this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return this.x;
                    case 1: return this.y;
                    case 2: return this.z;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0: this.x = value; break;
                    case 1: this.y = value; break;
                    case 2: this.z = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static bool operator ==(Bool3 lhs, Bool3 rhs) => lhs.Equals(rhs);
        public static bool operator !=(Bool3 lhs, Bool3 rhs) => !lhs.Equals(rhs);

        public static Bool3 operator &(Bool3 a, Bool3 b) => new Bool3(a.x & b.x, a.y & b.y, a.z & b.z);
        public static Bool3 operator |(Bool3 a, Bool3 b) => new Bool3(a.x | b.x, a.y | b.y, a.z | b.z);
        public static Bool3 operator ^(Bool3 a, Bool3 b) => new Bool3(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z);
        public static Bool3 operator !(Bool3 a) => new Bool3(!a.x, !a.y, !a.z);

    }

}
