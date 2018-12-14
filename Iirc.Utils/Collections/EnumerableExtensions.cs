// ---------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="Czech Technical University in Prague">
//   Copyright (c) 2018 Czech Technical University in Prague
// </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Iirc.Utils.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Iirc.Utils.Math;

    public static class EnumerableExtensions
    {
        public static IEnumerable<Tuple<T, T>> OrderedPairs<T>(this IEnumerable<T> values)
        {
            var arr = values.ToArray();
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    yield return Tuple.Create(arr[i], arr[j]);
                }
            }
        }

        public static IEnumerable<Tuple<T, T>> SuccessionPairs<T>(this IEnumerable<T> values)
        {
            T currValue = default(T);
            bool firstValueObtained = false;
            foreach (var nextValue in values)
            {
                if (firstValueObtained)
                {
                    yield return Tuple.Create(currValue, nextValue);
                    currValue = nextValue;
                }
                else
                {
                    currValue = nextValue;
                    firstValueObtained = true;
                }
            }
        }

        public static int IndexMin<T, K>(this IList<T> values, Func<T, K> keySelector)
        {
            if (values.Any() == false)
            {
                throw new ArgumentException("List cannot be empty");
            }

            if (values.Count == 1)
            {
                return 0;
            }

            var comparer = Comparer<K>.Default;

            var indexWithSmallestKey = 0;
            var smallestKey = keySelector(values[indexWithSmallestKey]);

            var currentIndex = 1;
            foreach (var value in values.SkipFirst())
            {
                var key = keySelector(value);
                if (comparer.Compare(key, smallestKey) < 0)
                {
                    indexWithSmallestKey = currentIndex;
                    smallestKey = key;
                }
            }

            return indexWithSmallestKey;
        }

        public static T ArgMin<T, K>(this IEnumerable<T> values, Func<T, K> keySelector)
        {
            // TODO (performance): not very efficient
            return values.OrderBy(keySelector).First();
        }

        public static IEnumerable<T> SkipFirst<T>(this IEnumerable<T> values)
        {
            return values.Skip(1);
        }

        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> values)
        {
            return values.SkipLast(1);
        }

        public static IEnumerable<int> RangeTo(int from, int to)
        {
            for (var value = from; value <= to; value += 1)
            {
                yield return value;
            }
        }

        public static bool TryWhereFirstNonZero(this IEnumerable<double> values, out int index)
        {
            var comparer = NumericComparer.Default;

            index = 0;
            foreach (var value in values)
            {
                if (comparer.AreEqual(value, 0.0) == false)
                {
                    return true;
                }

                index++;
            }

            index = default(int);
            return false;
        }

        public static bool TryWhereLastNonZero(this IEnumerable<double> values, out int index)
        {
            var comparer = NumericComparer.Default;

            index = values.Count() - 1;
            foreach (var value in values.Reverse())
            {
                if (comparer.AreEqual(value, 0.0) == false)
                {
                    return true;
                }

                index--;
            }

            index = default(int);
            return false;
        }

        public static bool TryWhereNonZero(this IEnumerable<double> values, out int index)
        {
            return values.TryWhereFirstNonZero(out index);
        }

        public static bool TryWhereNonZero<T>(this IDictionary<T, double> dict, out KeyValuePair<T, double> pairNonZero)
        {
            var comparer = NumericComparer.Default;

            foreach (var pair in dict)
            {
                if (comparer.AreEqual(pair.Value, 0.0) == false)
                {
                    pairNonZero = pair;
                    return true;
                }
            }

            pairNonZero = default(KeyValuePair<T, double>);
            return false;
        }
    }
}