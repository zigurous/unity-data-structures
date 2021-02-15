using System;
using System.Collections.Generic;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Accumulates a set of stored values into a single total value.
    /// </summary>
    public abstract class ValueAccumulator<T> : IDisposable
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
        /// Disposes of all class resources.
        /// </summary>
        public virtual void Dispose()
        {
            this.values?.Clear();
            this.values = null;
        }

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
                // Subtract the previous value from the total before adding the
                // new value
                this.total = SplitDifference(value, currentValue);
                this.values[id] = value;
            }
            else
            {
                // Store the id value and add to the total
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
                // Subtract the id value from the total and remove from the
                // stored list
                this.total = Subtract(value);
                this.values.Remove(id);
            }
        }

        /// <summary>
        /// Increases the total accumulated value by a given amount.
        /// </summary>
        protected abstract T Add(T amount);

        /// <summary>
        /// Decreases the total accumulated value by a given amount.
        /// </summary>
        protected abstract T Subtract(T amount);

        /// <summary>
        /// Updates the total accumulated value by splitting the difference
        /// between a given new and old value.
        /// </summary>
        protected abstract T SplitDifference(T newValue, T oldValue);

    }

}
