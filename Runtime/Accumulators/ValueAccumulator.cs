using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates a set of stored values into a single total value.
    /// </summary>
    /// <typeparam name="T">The type of value to accumulate.</typeparam>
    public abstract class ValueAccumulator<T>
    {
        /// <summary>
        /// Keeps track of all accumulated values.
        /// Values are stored with unique identifiers.
        /// </summary>
        public Dictionary<int, T> values { get; protected set; } = new Dictionary<int, T>();

        /// <summary>
        /// The total accumulated value.
        /// </summary>
        public T total { get; protected set; }

        /// <summary>
        /// The number of unique values being accumulated.
        /// </summary>
        public int Count => this.values.Count;

        /// <summary>
        /// Returns the stored value with the given <paramref name="identifier"/>,
        /// or the default of <typeparamref name="T"/> if the value does not exist.
        /// </summary>
        /// <param name="id">The identifier of the stored value.</param>
        public T GetValue(int identifier)
        {
            T value;

            if (this.values.TryGetValue(identifier, out value)) {
                return value;
            } else {
                return default(T);
            }
        }

        /// <summary>
        /// Stores a given <paramref name="value"/> with the <paramref name="identifier"/>.
        /// The total accumulated value is updated based on the difference
        /// between the new and old value.
        /// </summary>
        /// <param name="value">The value to set.</param>
        /// <param name="identifier">The identifier of the value.</param>
        public void SetValue(T value, int identifier)
        {
            T currentValue;

            if (this.values.TryGetValue(identifier, out currentValue))
            {
                this.total = Subtract(currentValue);
                this.total = Add(value);
                this.values[identifier] = value;
            }
            else
            {
                this.total = Add(value);
                this.values.Add(identifier, value);
            }
        }

        /// <summary>
        /// Removes the value stored with the given <paramref name="identifier"/>
        /// and updates the total accumulated value.
        /// </summary>
        /// <param name="identifier">The identifier of the stored value to remove.</param>
        public void RemoveValue(int identifier)
        {
            T value;

            if (this.values.TryGetValue(identifier, out value))
            {
                this.total = Subtract(value);
                this.values.Remove(identifier);
            }
        }

        /// <summary>
        /// Removes all stored values and resets the total accumulated value.
        /// </summary>
        public void Clear()
        {
            this.values.Clear();
            this.total = default(T);
        }

        /// <summary>
        /// Increases the accumulated total by a given value.
        /// </summary>
        /// <param name="value">The value to add to the total.</param>
        /// <returns>The new total value.</returns>
        protected abstract T Add(T value);

        /// <summary>
        /// Decreases the accumulated total by a given value.
        /// </summary>
        /// <param name="value">The value to subtract from the total.</param>
        /// <returns>The new total value.</returns>
        protected abstract T Subtract(T value);

    }

}
