using System;
using UnityEngine;

namespace Zigurous.DataStructures
{
    /// <summary>Stores a quantity of a given entity type.</summary>
    /// <typeparam name="T">The type of entity being counted.</typeparam>
    [System.Serializable]
    public struct Quantity<T> : IEquatable<Quantity<T>> where T: IEquatable<T>
    {
        /// <summary>
        /// The entity being counted.
        /// </summary>
        [Tooltip("The entity being counted.")]
        public T entity;

        /// <summary>
        /// The number of entities.
        /// </summary>
        [Tooltip("The number of entities.")]
        public int amount;

        /// <summary>Creates a new Quantity with the given <paramref name="amount"/> of <paramref name="entity"/>.</summary>
        /// <param name="entity">The entity being counted.</param>
        /// <param name="amount">The amount of entities.</param>
        public Quantity(T entity, int amount)
        {
            this.entity = entity;
            this.amount = amount;
        }

        /// <returns>True if the quantity is equal to the <paramref name="other"/>.</returns>
        /// <param name="other">The quantity to compare to.</param>
        public bool Equals(Quantity<T> other)
        {
            return this.entity.Equals(other.entity) &&
                   this.amount == other.amount;
        }

        /// <returns>True if the quantity is equal to the <paramref name="other"/>.</returns>
        /// <param name="other">The object to compare to.</param>
        public override bool Equals(object obj)
        {
            if (obj is Quantity<T> quantity) {
                return Equals(quantity);
            } else {
                return false;
            }
        }

        /// <returns>
        /// The hash code of the quantity.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.entity.GetHashCode(), this.amount.GetHashCode());
        }

        /// <returns>
        /// The string representation of the quantity.
        /// </returns>
        public override string ToString()
        {
            return $"{this.amount.ToString()} {this.entity.ToString()}";
        }

        public static bool operator ==(Quantity<T> lhs, Quantity<T> rhs) => lhs.Equals(rhs);
        public static bool operator !=(Quantity<T> lhs, Quantity<T> rhs) => !lhs.Equals(rhs);

    }

}
