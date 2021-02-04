using System;
using System.Collections.Generic;

namespace Zigurous
{
    public static class ListExtensions
    {
        public static void Add<T>(this List<T> list, T value, int count)
        {
            for (int i = 0; i < count; i++) {
                list.Add(value);
            }
        }

        public static List<T> CombinedWith<T>(this List<T> list, List<T> otherList)
        {
            List<T> combinedList = new List<T>(list);
            combinedList.AddRange(otherList);
            return combinedList;
        }

        public static T ElementAt<T>(this List<T> list, int index)
        {
            if (index >= 0 && index < list.Count) {
                return list[index];
            } else {
                return default(T);
            }
        }

        public static T First<T>(this List<T> list) => (list.Count > 0) ? list[0] : default(T);
        public static T First<T>(this List<T> list, Predicate<T> where)
        {
            foreach (T element in list)
            {
                if (where(element) == true) {
                    return element;
                }
            }

            return default(T);
        }

        public static void For<T>(this List<T> list, Action<(T item, int index)> action)
        {
            for (int i = 0; i < list.Count; i++) {
                action((list[i], i));
            }
        }

        public static bool IsEmpty<T>(this List<T> list) => list.Count <= 0;
        public static bool IsNotEmpty<T>(this List<T> list) => list.Count > 0;

        public static bool IsFalseForEach<T>(this List<T> list, Predicate<T> predicate)
        {
            foreach (T element in list)
            {
                if (predicate(element)) {
                    return false;
                }
            }

            return true;
        }

        public static bool IsTrueForEach<T>(this List<T> list, Predicate<T> predicate)
        {
            foreach (T element in list)
            {
                if (!predicate(element)) {
                    return false;
                }
            }

            return true;
        }

        public static string Join<T>(this List<T> list, string delimiter = ",")
        {
            string joined = "";

            foreach (T item in list) {
                joined += item.ToString() + delimiter;
            }

            return joined.TrimEnd(delimiter.ToCharArray());
        }

        public static T Last<T>(this List<T> list) => (list.Count > 0) ? list[list.Count - 1] : default(T);

        public static List<TOutput> Map<TInput, TOutput>(this List<TInput> list, Converter<TInput, TOutput> converter) =>
            list.ConvertAll(converter);

        public static T Max<T>(this List<T> list) where T: IComparable<T>
        {
            T max = default(T);

            foreach (T item in list)
            {
                if (item.CompareTo(max) > 0) {
                    max = item;
                }
            }

            return max;
        }

        public static T Min<T>(this List<T> list) where T: IComparable<T>
        {
            T min = default(T);

            foreach (T item in list)
            {
                if (item.CompareTo(min) < 0) {
                    min = item;
                }
            }

            return min;
        }

        public static T Random<T>(this List<T> list) => list[UnityEngine.Random.Range(0, list.Count)];

        public delegate TSum Reducer<TSum, TItem>(TSum sum, TItem item);
        public static TSum Reduce<TItem, TSum>(this List<TItem> list, TSum initialValue, Reducer<TSum, TItem> reducer)
        {
            TSum sum = initialValue;

            foreach (TItem item in list) {
                sum = reducer(sum, item);
            }

            return sum;
        }

        public static void RemoveFirst<T>(this List<T> list)
        {
            if (list.Count > 0) {
                list.RemoveAt(0);
            }
        }

        public static void RemoveLast<T>(this List<T> list)
        {
            if (list.Count > 0) {
                list.RemoveAt(list.Count - 1);
            }
        }

        public static List<T> Where<T>(this List<T> list, Predicate<T> match) => list.FindAll(match);

    }

}
