using System;
using System.Collections.Generic;

namespace CodingKata_Infinites
{
    public class Infinite
    {
        public static IEnumerable<int> All()
        {
            var i = 1;

            while (i > 0)
                yield return i++;
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> list, Func<T, bool> predicateFunc)
        {
            foreach (T item in list)
            {
                if (predicateFunc(item))
                    yield return item;
            }
        }

        public static IEnumerable<int> Odds()
        {
            return Filter(All(), n => n % 2 != 0);
        }

        public static IEnumerable<int> Evens()
        {
            return Filter(All(), n => n % 2 == 0);
        }
    }
}