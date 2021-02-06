using System;
using System.Collections.Generic;
using System.Text;

namespace Zigurous.DataStructures
{
    public static class ArrayExtensions
    {
        public static T[] Concat<T>(this T[] array, T element)
        {
            T[] combinedArray = new T[array.Length + 1];

            for (int i = 0; i < array.Length; i++) {
                combinedArray[i] = array[i];
            }

            combinedArray[array.Length] = element;

            return combinedArray;
        }

        public static T[] Concat<T>(this T[] array, T[] elements)
        {
            if (elements.Length == 0) {
                return array;
            }

            T[] combinedArray = new T[array.Length + elements.Length];

            for (int i = 0; i < array.Length; i++) {
                combinedArray[i] = array[i];
            }

            for (int i = 0; i < elements.Length; i++) {
                combinedArray[array.Length + i] = elements[i];
            }

            return combinedArray;
        }

        public static bool Contains<T>(this T[] array, T match) where T: IEquatable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(match)) {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsType<T>(this T[] array, Type type)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GetType() == type) {
                    return true;
                }
            }

            return false;
        }

        public static T ElementAt<T>(this T[] array, int index)
        {
            if (index >= 0 && index < array.Length) {
                return array[index];
            } else {
                return default(T);
            }
        }

        public static T[] Filter<T>(this T[] array, Predicate<T> filter)
        {
            List<T> list = new List<T>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                T element = array[i];

                if (filter(element) == true) {
                    list.Add(element);
                }
            }

            return list.ToArray();
        }

        public static T First<T>(this T[] array)
        {
            if (array.Length > 0) {
                return array[0];
            } else {
                return default(T);
            }
        }

        public static T First<T>(this T[] array, Predicate<T> where)
        {
            for (int i = 0; i < array.Length; i++)
            {
                T element = array[i];

                if (where(element) == true) {
                    return element;
                }
            }

            return default(T);
        }

        public static T FirstNonNull<T>(this T[] array) where T: class
        {
            for (int i = 0; i < array.Length; i++)
            {
                T element = array[i];

                if (element != null) {
                    return element;
                }
            }

            return default(T);
        }

        public static T[] Flatten<T>(this T[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            T[] flat = new T[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    T element = array[x, y];
                    flat[x * width + y] = element;
                }
            }

            return flat;
        }

        public static T[] Flatten<T>(this T[,,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);
            int depth = array.GetLength(2);

            T[] flat = new T[width * height * depth];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        T element = array[x, y, z];
                        flat[x + width * (y + height * z)] = element;
                    }
                }
            }

            return flat;
        }

        public static void For<T>(this T[] array, Action<(T element, int index)> action)
        {
            for (int i = 0; i < array.Length; i++) {
                action((array[i], i));
            }
        }

        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            for (int i = 0; i < array.Length; i++) {
                action(array[i]);
            }
        }

        public static int IndexOf<T>(this T[] array, T element) where T: IEquatable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(element)) {
                    return i;
                }
            }

            return -1;
        }

        public static bool IsAny<T>(this T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]) == true) {
                    return true;
                }
            }

            return false;
        }

        public static bool IsEach<T>(this T[] array, Predicate<T> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]) == false) {
                    return false;
                }
            }

            return true;
        }

        public static bool IsEmpty(this Array array) => array.Length <= 0;
        public static bool IsNotEmpty(this Array array) => array.Length > 0;
        public static bool IsInBounds(this Array array, int index) => index >= 0 && index < array.Length;
        public static bool IsNotInBounds(this Array array, int index) => index < 0 || index >= array.Length;

        public static string Join<T>(this T[] array, string delimiter, int startIndex = 0, int endIndex = int.MaxValue)
        {
            if (array.Length == 0) return "";
            StringBuilder stringBuilder = new StringBuilder();

            int start = System.Math.Max(0, startIndex);
            int end = System.Math.Min(array.Length - 1, endIndex - 1);

            for (int i = start; i < end; i++) {
                stringBuilder.Append(array[i]).Append(delimiter);
            }

            stringBuilder.Append(array[end]);
            return stringBuilder.ToString();
        }

        public static T Last<T>(this T[] array)
        {
            if (array.Length > 0) {
                return array[array.Length - 1];
            } else {
                return default(T);
            }
        }

        public static T Last<T>(this T[] array, Predicate<T> where)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                T element = array[i];

                if (where(element) == true) {
                    return element;
                }
            }

            return default(T);
        }

        public static T LastNonNull<T>(this T[] array) where T: class
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                T element = array[i];

                if (element != null) {
                    return element;
                }
            }

            return default(T);
        }

        public static TOutput[] Map<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
        {
            TOutput[] output = new TOutput[array.Length];

            for (int i = 0; i < array.Length; i++) {
                output[i] = converter(array[i]);
            }

            return output;
        }

        public static T[] NonNull<T>(this T[] array) where T: class
        {
            if (array.Length > 0) {
                return Filter(array, element => element != null);
            } else {
                return array;
            }
        }

        public static T Random<T>(this T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        public delegate TSum Reducer<TSum, TElement>(TSum sum, TElement element);
        public static TSum Reduce<TElement, TSum>(this TElement[] array, TSum initialValue, Reducer<TSum, TElement> reducer)
        {
            TSum sum = initialValue;

            for (int i = 0; i < array.Length; i++) {
                sum = reducer(sum, array[i]);
            }

            return sum;
        }

        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            if (index < 0 || index >= array.Length) {
                return array;
            }

            T[] removed = new T[array.Length - 1];

            if (index > 0) {
                Array.Copy(array, 0, removed, 0, index);
            }

            if (index < array.Length - 1) {
                Array.Copy(array, index + 1, removed, index, array.Length - index - 1);
            }

            return removed;
        }

        public static void Reverse<T>(this T[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                T temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
        }

        public static T[] Reversed<T>(this T[] array)
        {
            T[] reversed = new T[array.Length];

            for (int i = 0, j = array.Length - 1; i < array.Length; i++, j--) {
                reversed[i] = array[j];
            }

            return reversed;
        }

        public static int RotatedIndex(this Array array, int index)
        {
            int length = array.Length;
            if (length == 0) return 0;
            while (index < 0) index += length;
            while (index >= length) index -= length;
            return index;
        }

        public static T[] Slice<T>(this T[] array, int amount)
        {
            T[] slice = new T[amount];

            for (int i = 0; i < amount; i++) {
                slice[i] = array[i];
            }

            return slice;
        }

        public static void Sort<T>(this T[] array, Comparison<T> comparison)
        {
            Array.Sort(array, comparison);
        }

        public static T[] Where<T>(this T[] array, Predicate<T> match)
        {
            return Filter(array, match);
        }

    }

}
