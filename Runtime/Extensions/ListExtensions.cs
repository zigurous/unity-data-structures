using System;
using System.Collections.Generic;
using System.Text;

namespace Zigurous.DataStructures
{
    /// <summary>
    /// Extension methods for lists.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// A reusable string builder.
        /// </summary>
        private static StringBuilder stringBuilder;

        /// <summary>
        /// Adds a specified <paramref name="amount"/> of
        /// <paramref name="value"/> to the list.
        /// </summary>
        /// <param name="list">The list to add to.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="amount">The number of times to add the value.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static void Add<T>(this List<T> list, T value, int amount)
        {
            for (int i = 0; i < amount; i++) {
                list.Add(value);
            }
        }

        /// <summary>
        /// Combines the list with another.
        /// </summary>
        /// <param name="list">The first list.</param>
        /// <param name="other">The second list.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <returns>A new list containing all the items of <paramref name="list"/> and <paramref name="other"/>.</returns>
        public static List<T> CombinedWith<T>(this List<T> list, List<T> other)
        {
            List<T> combinedList = new List<T>(list);
            combinedList.AddRange(other);
            return combinedList;
        }

        /// <summary>
        /// Returns the item at <paramref name="index"/>, or the default value
        /// of <typeparamref name="T"/> if the list is empty.
        /// </summary>
        /// <param name="list">The list to get the item from.</param>
        /// <param name="index">The index of the item to get.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T ItemAt<T>(this List<T> list, int index)
        {
            if (index >= 0 && index < list.Count) {
                return list[index];
            } else {
                return default(T);
            }
        }

        /// <summary>
        /// Filters the list to only contain items that satisfy the
        /// <paramref name="predicate"/>.
        /// </summary>
        /// <param name="list">The list to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <returns>A new list with the filtered items removed.</returns>
        public static List<T> Filter<T>(this List<T> list, Predicate<T> predicate)
        {
            return list.FindAll(predicate);
        }

        /// <summary>
        /// Returns the first item in the list, or the default value of
        /// <typeparamref name="T"/> if the list is empty.
        /// </summary>
        /// <param name="list">The list to get the item from.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T First<T>(this List<T> list)
        {
            if (list.Count > 0) {
                return list[0];
            } else {
                return default(T);
            }
        }

        /// <summary>
        /// Returns the first item in the list that satisfies the
        /// <paramref name="predicate"/>, or the default value of
        /// <typeparamref name="T"/> if no item satisfies the
        /// <paramref name="predicate"/>.
        /// </summary>
        /// <param name="list">The list to get the item from.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T First<T>(this List<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item) == true) {
                    return item;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Returns the first non-null item in the list, or the default value of
        /// <typeparamref name="T"/> if all items are null.
        /// </summary>
        /// <param name="list">The list to get the item from.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T FirstNonNull<T>(this List<T> list) where T: class
        {
            foreach (T item in list)
            {
                if (item != null) {
                    return item;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Invokes an <see cref="Action{T}"/> for each item in the list.
        /// </summary>
        /// <param name="list">The list to iterate over.</param>
        /// <param name="action">The action to invoke.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static void For<T>(this List<T> list, Action<(T item, int index)> action)
        {
            for (int i = 0; i < list.Count; i++) {
                action((list[i], i));
            }
        }

        /// <summary>
        /// Checks if any item in the list satisfies the
        /// <paramref name="predicate"/>.
        /// </summary>
        /// <param name="list">The list to search in.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static bool IsAny<T>(this List<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item) == true) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if each item in the list satisfies the
        /// <paramref name="predicate"/>.
        /// </summary>
        /// <param name="list">The list to search in.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static bool IsEach<T>(this List<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item) == false) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count <= 0;
        }

        /// <summary>
        /// Checks if the list is not empty.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static bool IsNotEmpty<T>(this List<T> list)
        {
            return list.Count > 0;
        }

        /// <summary>
        /// Checks if <paramref name="index"/> is within the bounds of the list.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="index">The index to check.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static bool IsInBounds<T>(this List<T> list, int index)
        {
            return index >= 0 && index < list.Count;
        }

        /// <summary>
        /// Checks if <paramref name="index"/> is out of bounds of the list.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="index">The index to check.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static bool IsNotInBounds<T>(this List<T> list, int index)
        {
            return index < 0 || index >= list.Count;
        }

        /// <summary>
        /// Joins the items of the list into a string separated by the
        /// <paramref name="delimiter"/>.
        /// </summary>
        /// <param name="array">The array to join.</param>
        /// <param name="delimiter">The delimiter to use.</param>
        /// <param name="startIndex">The index to start at.</param>
        /// <param name="endIndex">The index to end at.</param>
        /// <typeparam name="T">The type of the array.</typeparam>
        public static string Join<T>(this List<T> list, string delimiter, int startIndex = 0, int endIndex = int.MaxValue)
        {
            if (list.Count == 0) {
                return "";
            }

            if (stringBuilder == null) {
                stringBuilder = new StringBuilder();
            } else {
                stringBuilder.Clear();
            }

            int start = System.Math.Max(0, startIndex);
            int end = System.Math.Min(list.Count - 1, endIndex - 1);

            for (int i = start; i < end; i++) {
                stringBuilder.Append(list[i]).Append(delimiter);
            }

            stringBuilder.Append(list[end]);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns the last item in the list, or the default of
        /// <typeparamref name="T"/> if the list is empty.
        /// </summary>
        /// <param name="list">The list to get the item from.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T Last<T>(this List<T> list)
        {
            if (list.Count > 0) {
                return list[list.Count - 1];
            } else {
                return default(T);
            }
        }

        /// <summary>
        /// Returns the last item in the list that satisfies the
        /// <paramref name="predicate"/>, or the default of
        /// <typeparamref name="T"/> if no item satisfies the
        /// <paramref name="predicate"/>.
        /// </summary>
        /// <param name="list">The list to get the item from.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T Last<T>(this List<T> list, Predicate<T> predicate)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                T item = list[i];

                if (predicate(item) == true) {
                    return item;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Returns the last non-null item in the list, or the default of
        /// <typeparamref name="T"/> if all items are null.
        /// </summary>
        /// <param name="list">The list to get the item from.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T LastNonNull<T>(this List<T> list) where T: class
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                T item = list[i];

                if (item != null) {
                    return item;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Maps the items of the list to a new list using a given
        /// <paramref name="converter"/>.
        /// </summary>
        /// <param name="list">The list to map.</param>
        /// <param name="converter">The converter to use.</param>
        /// <typeparam name="TInput">The type of the input list.</typeparam>
        /// <typeparam name="TOutput">The type of the output list.</typeparam>
        /// <returns>A new list with the converted items.</returns>
        public static List<TOutput> Map<TInput, TOutput>(this List<TInput> list, Converter<TInput, TOutput> converter)
        {
            return list.ConvertAll(converter);
        }

        /// <summary>
        /// Filters out all null items from the list.
        /// </summary>
        /// <param name="list">The list to filter.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <returns>A new list with all null items removed.</returns>
        public static List<T> NonNull<T>(this List<T> list) where T: class
        {
            if (list.Count > 0) {
                return list.FindAll(item => item != null);
            } else {
                return list;
            }
        }

        /// <summary>
        /// Returns a random item from the list, or the default of
        /// <typeparamref name="T"/> if the list is empty.
        /// </summary>
        /// <param name="list">The list to get the random item from.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static T Random<T>(this List<T> list)
        {
            if (list.Count > 0) {
                return list[UnityEngine.Random.Range(0, list.Count)];
            } else {
                return default(T);
            }
        }

        /// <summary>
        /// A function delegate that reduces a list into a single value.
        /// </summary>
        /// <param name="sum">The current sum.</param>
        /// <param name="item">The current item being reduced.</param>
        /// <typeparam name="TSum">The type of the reduced value.</typeparam>
        /// <typeparam name="TItem">The type of items in the list.</typeparam>
        /// <returns>The reduced value.</returns>
        public delegate TSum Reducer<TSum, TItem>(TSum sum, TItem item);

        /// <summary>
        /// Reduces the items of the list to a single value.
        /// </summary>
        /// <param name="list">The list to reduce.</param>
        /// <param name="initialValue">The initial value to use.</param>
        /// <param name="reducer">The reducer to use.</param>
        /// <typeparam name="TSum">The type of the reduced value.</typeparam>
        /// <typeparam name="TItem">The type of items in the list.</typeparam>
        /// <returns>The reduced value.</returns>
        public static TSum Reduce<TItem, TSum>(this List<TItem> list, TSum initialValue, Reducer<TSum, TItem> reducer)
        {
            TSum sum = initialValue;

            foreach (TItem item in list) {
                sum = reducer(sum, item);
            }

            return sum;
        }

        /// <summary>
        /// Removes the first item in the list.
        /// </summary>
        /// <param name="list">The list to remove from.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static void RemoveFirst<T>(this List<T> list)
        {
            if (list.Count > 0) {
                list.RemoveAt(0);
            }
        }

        /// <summary>
        /// Removes the last item in the list.
        /// </summary>
        /// <param name="list">The list to remove from.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static void RemoveLast<T>(this List<T> list)
        {
            if (list.Count > 0) {
                list.RemoveAt(list.Count - 1);
            }
        }

        /// <summary>
        /// Reverses the order of the items in the list.
        /// </summary>
        /// <param name="list">The list to reverse.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <returns>A new list with the order of the items reversed.</returns>
        public static List<T> Reversed<T>(this List<T> list)
        {
            List<T> reversed = new List<T>(list.Count);

            for (int i = 0, j = list.Count - 1; i < list.Count; i++, j--) {
                reversed[i] = list[j];
            }

            return reversed;
        }

        /// <summary>
        /// Shuffles the list in place.
        /// </summary>
        /// <remarks>The shuffle is done using the Fisher-Yates algorithm.</remarks>
        /// <param name="list">The list to shuffle.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static void Shuffle<T>(this List<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                T temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
        }

        /// <summary>
        /// Shuffles the list in place using the given random number generator.
        /// </summary>
        /// <remarks>The shuffle is done using the Fisher-Yates algorithm.</remarks>
        /// <param name="list">The list to shuffle.</param>
        /// <param name="rng">The random number generator to use.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        public static void Shuffle<T>(this List<T> list, Random rng)
        {
            int n = list.Count;

            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
        }

        /// <summary>
        /// Filters the list to only contain items that satisfy the
        /// <paramref name="predicate"/>.
        /// </summary>
        /// <param name="list">The list to filter.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <returns>A new list with the filtered items removed.</returns>
        public static List<T> Where<T>(this List<T> list, Predicate<T> predicate)
        {
            return list.FindAll(predicate);
        }

        /// <summary>
        /// Wraps the <paramref name="index"/> in the list to the other end when
        /// outside the bounds.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <param name="index">The index to wrap.</param>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <returns>The wrapped index.</returns>
        public static int WrapIndex<T>(this List<T> list, int index)
        {
            return ((index % list.Count) + list.Count) % list.Count;
        }

    }

}
