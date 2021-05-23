using System;

namespace Zigurous.DataStructures
{
    public struct Bitmask : IEquatable<Bitmask>, IEquatable<int>
    {
        /// <summary>
        /// The bitmask represented as a 32-bit integer.
        /// </summary>
        private int mask;

        /// <summary>
        /// Creates a new Bitmask from a 32-bit integer.
        /// </summary>
        public Bitmask(int mask)
        {
            this.mask = mask;
        }

        /// <summary>
        /// Returns true if the bitmask contains another mask and there no flags
        /// set on the other mask that are not set on the bitmask.
        /// </summary>
        public bool ContainsMaskExclusive(int other)
        {
            return ((this.mask ^ other) & other) == 0;
        }

        /// <summary>
        /// Returns true if the bitmask contains the flag. <c>(mask &amp; flag)
        /// == flag</c>
        /// </summary>
        public bool HasFlag(int flag)
        {
            return (this.mask & flag) == flag;
        }

        /// <summary>
        /// Returns true if the bitmask contains any of the flags. <c>(mask
        /// &amp; flags) != 0</c>
        /// </summary>
        public bool HasAnyFlag(int flags)
        {
            return (this.mask & flags) != 0;
        }

        /// <summary>
        /// Returns true if the nth bit of the bitmask is set.
        /// </summary>
        public bool Has(int n)
        {
            return Get(n) != 0;
        }

        /// <summary>
        /// Returns the nth bit of the bitmask.
        /// </summary>
        public int Get(int n)
        {
            return (this.mask >> n) & 1;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to 1.
        /// </summary>
        public void Set(int n)
        {
            this.mask |= 1 << n;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to 0.
        /// </summary>
        public void Clear(int n)
        {
            this.mask &= ~(1 << n);
        }

        /// <summary>
        /// Toggles the nth bit of the bitmask.
        /// </summary>
        public void Toggle(int n)
        {
            this.mask ^= 1 << n;
        }

        /// <summary>
        /// Sets the nth bit of the bitmask to x.
        /// </summary>
        public void Change(int n, int x)
        {
            this.mask = (this.mask & ~(1 << n)) | (x << n);
        }

        public bool Equals(Bitmask other)
        {
            return this.mask == other.mask;
        }

        public bool Equals(int other)
        {
            return this.mask == other;
        }

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

        public override int GetHashCode()
        {
            return this.mask.GetHashCode();
        }

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
