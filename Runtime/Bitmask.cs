using System;
using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// A bitmask representation that can be used for bitwise operations.
    /// A bitmask is a set of bits that can be set or cleared.
    /// </summary>
    [Serializable]
    public struct Bitmask : IEquatable<Bitmask>, IEquatable<int>
    {
        /// <summary>
        /// The bitmask represented as a 32-bit integer.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        private int mask;

        /// <summary>
        /// Creates a new Bitmask from the given 32-bit integer.
        /// </summary>
        /// <param name="mask">The 32-bit integer to represent as a bitmask.</param>
        public Bitmask(int mask)
        {
            this.mask = mask;
        }

        /// <summary>
        /// Checks if the bitmask contains the <paramref name="flag"/>.
        /// <code>(mask &amp; flag) == flag</code>
        /// </summary>
        /// <param name="flag">The flag to check for.</param>
        public bool HasFlag(int flag)
        {
            return (this.mask & flag) == flag;
        }

        /// <summary>
        /// Checks if the bitmask contains any of the <paramref name="flags"/>.
        /// <code>(mask &amp; flags) != 0</code>
        /// </summary>
        /// <param name="flags">The flags to check for.</param>
        public bool HasAnyFlag(int flags)
        {
            return (this.mask & flags) != 0;
        }

        /// <summary>
        /// Checks if the bitmask contains only the given <paramref name="flags"/>
        /// and no other flags.
        /// <code>((mask ^ flags) &amp; flags) == 0</code>
        /// </summary>
        /// <param name="flags">The flags to check for.</param>
        public bool HasOnlyFlags(int flags)
        {
            return ((this.mask ^ flags) & flags) == 0;
        }

        /// <summary>
        /// Checks if the nth bit of the bitmask is set.
        /// </summary>
        /// <param name="n">The nth bit to check for.</param>
        public bool Has(int n)
        {
            return Get(n) != 0;
        }

        /// <summary>
        /// Returns the nth bit of the bitmask.
        /// </summary>
        /// <param name="n">The nth bit to get.</param>
        public int Get(int n)
        {
            return (this.mask >> n) & 1;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to 1.
        /// </summary>
        /// <param name="n">The nth bit to set.</param>
        public void Set(int n)
        {
            this.mask |= 1 << n;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to 0.
        /// </summary>
        /// <param name="n">The nth bit to clear.</param>
        public void Clear(int n)
        {
            this.mask &= ~(1 << n);
        }

        /// <summary>
        /// Toggles the nth bit of the bitmask.
        /// </summary>
        /// <param name="n">The nth bit to toggle.</param>
        public void Toggle(int n)
        {
            this.mask ^= 1 << n;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to x.
        /// </summary>
        /// <param name="n">The nth bit to set.</param>
        /// <param name="x">The value to set the bit to.</param>
        public void Change(int n, int x)
        {
            this.mask = (this.mask & ~(1 << n)) | (x << n);
        }

        /// <summary>
        /// Determines if the bitmask is equal to <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The bitmask to compare to.</param>
        public bool Equals(Bitmask other)
        {
            return this.mask == other.mask;
        }

        /// <summary>
        /// Determines if the bitmask is equal to <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The bitmask to compare to.</param>
        public bool Equals(int other)
        {
            return this.mask == other;
        }

        /// <summary>
        /// Determines if the bitmask is equal to <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The object to compare to.</param>
        public override bool Equals(object other)
        {
            if (other is Bitmask bitmask) {
                return Equals(bitmask);
            } else if (other is int integer) {
                return Equals(integer);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Returns the hash code of the bitmask.
        /// </summary>
        public override int GetHashCode()
        {
            return this.mask.GetHashCode();
        }

        /// <summary>
        /// Converts the bitmask to a string.
        /// </summary>
        public override string ToString()
        {
            string binary = System.Convert.ToString(this.mask, 2);
            return binary.PadLeft(64 - binary.Length, '0');
        }

        public static bool operator ==(Bitmask lhs, Bitmask rhs) => lhs.Equals(rhs);
        public static bool operator ==(Bitmask lhs, int rhs) => lhs.Equals(rhs);
        public static bool operator ==(int lhs, Bitmask rhs) => rhs.Equals(lhs);
        public static bool operator !=(Bitmask lhs, Bitmask rhs) => !lhs.Equals(rhs);
        public static bool operator !=(Bitmask lhs, int rhs) => !lhs.Equals(rhs);
        public static bool operator !=(int lhs, Bitmask rhs) => !rhs.Equals(lhs);

        public static Bitmask operator &(Bitmask a, Bitmask b) => new Bitmask(a.mask & b.mask);
        public static Bitmask operator |(Bitmask a, Bitmask b) => new Bitmask(a.mask | b.mask);
        public static Bitmask operator ^(Bitmask a, Bitmask b) => new Bitmask(a.mask ^ b.mask);
        public static Bitmask operator ~(Bitmask a) => new Bitmask(~a.mask);
        public static Bitmask operator <<(Bitmask a, int b) => new Bitmask(a.mask << b);
        public static Bitmask operator >>(Bitmask a, int b) => new Bitmask(a.mask >> b);

        public static implicit operator int(Bitmask value) => value.mask;
        public static implicit operator Bitmask(int value) => new Bitmask(value);

    }

}
