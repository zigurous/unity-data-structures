using System;

namespace Zigurous.DataStructures
{
    [System.Serializable]
    public struct Quantity<T> : IEquatable<Quantity<T>> where T: IEquatable<T>
    {
        /// <summary>
        /// The entity being counted.
        /// </summary>
        public T entity;

        /// <summary>
        /// The number of entities.
        /// </summary>
        public int amount;

        /// <summary>
        /// Creates a new Quantity with given amount of entity.
        /// </summary>
        public Quantity(T entity, int amount)
        {
            this.entity = entity;
            this.amount = amount;
        }

        public bool Equals(Quantity<T> other)
        {
            return this.entity.Equals(other.entity) &&
                   this.amount == other.amount;
        }

        public override bool Equals(object obj)
        {
            if (obj is Quantity<T> quantity) {
                return Equals(quantity);
            } else {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.entity.GetHashCode(), this.amount.GetHashCode());
        }

        public static bool operator ==(Quantity<T> lhs, Quantity<T> rhs) => lhs.Equals(rhs);
        public static bool operator !=(Quantity<T> lhs, Quantity<T> rhs) => !lhs.Equals(rhs);

    }

}
