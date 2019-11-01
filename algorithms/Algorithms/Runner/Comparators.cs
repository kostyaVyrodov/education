using System;
using System.Collections.Generic;
using System.Linq;

namespace Runner
{
    public static class Comparators
    {
        public static void TwoCollectionsShouldBeSame(IEnumerable<int> actual, IEnumerable<int> expected)
        {
            var l1 = actual.ToList();
            var l2 = expected.ToList();

            if (l1.Count != l2.Count)
            {
                throw new Exception("collections are different");
            }

            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i] != l2[i])
                {
                    throw new Exception("collections are different");
                }
            }
        }

        public static void TwoNumbersShouldBeSame(int actual, int expected)
        {
            if (actual != expected)
            {
                throw new Exception("numbers are different");
            }
        }
    }
}
