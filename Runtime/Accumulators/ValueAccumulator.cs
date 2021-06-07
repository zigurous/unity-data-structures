using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates a set of stored values into a single total value.
    /// </summary>
    public abstract class ValueAccumulator<T>
    {
        /// <summary>
        /// Keeps track of all accumulated values. Values are stored by unique
        /// hash codes.
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
        /// Returns the stored value with the given hash code identifier.
        /// </summary>
        public T GetValue(int id)
        {
            T value;

            if (this.values.TryGetValue(id, out value)) {
                return value;
            } else {
                return default(T);
            }
        }

        /// <summary>
        /// Stores a given value with a hash code identifier, and updates the
        /// total accumulated value.
        /// </summary>
        public void SetValue(T value, int id)
        {
            T currentValue;

            if (this.values.TryGetValue(id, out currentValue))
            {
                this.total = Subtract(currentValue);
                this.total = Add(value);
                this.values[id] = value;
            }
            else
            {
                this.total = Add(value);
                this.values.Add(id, value);
            }
        }

        /// <summary>
        /// Removes the stored value with the given hash code identifier, and
        /// updates the total accumulated value.
        /// </summary>
        public void RemoveValue(int id)
        {
            T value;

            if (this.values.TryGetValue(id, out value))
            {
                this.total = Subtract(value);
                this.values.Remove(id);
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
        protected abstract T Add(T value);

        /// <summary>
        /// Decreases the accumulated total by a given value.
        /// </summary>
        protected abstract T Subtract(T value);

    }

}
