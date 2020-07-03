using System;
using System.Collections.Generic;
using System.Linq;

namespace R4ZE.Extensions
{
    /// <summary>
    /// Library for List Extensions
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Adds an entry to the list, if the entry does not exist.
        /// </summary>
        public static void AddIfNotExists<T>(this IList<T> list, T value)
        {
            checkListIsNull(list);
            if(!list.Contains(value))
            {
                list.Add(value);
            }
        }

        /// <summary>
        /// Updates an entry, if the entry exists.
        /// </summary>
        public static void UpdateValue<T>(this IList<T> list, T value, T newValue)
        {
            checkListAndValueIsNull(list, value);
            checkValueIsNull(newValue);

            if(list.Contains(value))
            {
                var index = list.IndexOf(value);
                list[index] = newValue;
            }
        }

        /// <summary>
        /// Deletes an entry, if the entry exists.
        /// </summary>
        public static void DeleteIfExists<T>(this IList<T> list, T value)
        {
            checkListAndValueIsNull(list, value);

            if (list.Contains(value))
            {
                list.Remove(value);
            }
        }

        /// <summary>
        /// Checks if the values of the list are null.
        /// </summary>
        public static bool AreValuesNull<T>(this IList<T> list)
        {
            checkListIsNull(list);
            return list.All(x => x == null);
        }

        /// <summary>
        /// Checks if the list is null or empty
        /// </summary>
        /// <returns>True if the list is null or empty, false if otherwise.</returns>
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count <= 0;
        }

        #region Private Methods
        private static void checkListAndValueIsNull<T>(this IList<T> list, T value)
        {
            checkListIsNull(list);
            checkValueIsNull(value);
        }

        private static void checkValueIsNull<T>(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
        }

        private static void checkListIsNull<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
        }
        #endregion
    }
}

