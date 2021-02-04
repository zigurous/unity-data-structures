using System;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Bool3 : IEquatable<Bool3>
    {
        /// <summary>
        /// The X component.
        /// </summary>
        public bool x;

        /// <summary>
        /// The Y component.
        /// </summary>
        public bool y;

        /// <summary>
        /// The Z component.
        /// </summary>
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
        /// Creates a new Bool3 with given x, y, z components.
        /// </summary>
        public Bool3(bool x = false, bool y = false, bool z = false)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public bool Equals(Bool3 other)
        {
            return this.x == other.x &&
                   this.y == other.y &&
                   this.z == other.z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Bool3 bool3) {
                return Equals(bool3);
            } else {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.x.GetHashCode(), this.y.GetHashCode(), this.z.GetHashCode());
        }

        public static bool operator ==(Bool3 lhs, Bool3 rhs) => lhs.Equals(rhs);
        public static bool operator !=(Bool3 lhs, Bool3 rhs) => !lhs.Equals(rhs);

        public static Bool3 operator &(Bool3 a, Bool3 b) => new Bool3(
            a.x & b.x,
            a.y & b.y,
            a.z & b.z);

        public static Bool3 operator |(Bool3 a, Bool3 b) => new Bool3(
            a.x | b.x,
            a.y | b.y,
            a.z | b.z);

        public static Bool3 operator ^(Bool3 a, Bool3 b) => new Bool3(
            a.x ^ b.x,
            a.y ^ b.y,
            a.z ^ b.z);

        public static Bool3 operator !(Bool3 a) => new Bool3(
            !a.x,
            !a.y,
            !a.z);

    }

}
