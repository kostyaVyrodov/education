using System;
using System.Collections.Generic;

namespace Runner
{
    public static class HackerRankTests
    {
        public static void RunTests()
        {
            SumTwoNumbers_Test();
            ListReplication_Test();
            FilterArray_Test();
            FilterArrayMarshaling_Test();
            FilterPositionsInAList_Test();
            ArrayOfNElements_Test();
            ReverseAList_Test();
            SumOdd_Test();
            ListLength_Test();
            UpdateList_Test();

            Console.WriteLine("Tests successfully finished!");
        }

        static void SumTwoNumbers_Test()
        {
            var expectedResult = 3;
            var actualResult = HackerRank.SumTwoNumbers(1, 2);

            Comparators.TwoNumbersShouldBeSame(expectedResult, actualResult);
        }

        static void ListReplication_Test()
        {
            var expectedResult = new List<int> {1, 1, 1, 2, 2, 2, 3, 3, 3};
            var stubTimes = 3;
            var stubNumbers = new List<int> {1, 2, 3};
            var actualResult = HackerRank.ListReplication(stubTimes, stubNumbers);

            Comparators.TwoCollectionsShouldBeSame(actualResult, expectedResult);
        }

        static void FilterArray_Test()
        {
            var expectedResult = new[] {1, 2};
            var stubConstraint = 3;
            var stubNumbers = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var actualResult = HackerRank.FilterArray(stubConstraint, stubNumbers);

            Comparators.TwoCollectionsShouldBeSame(actualResult, expectedResult);
        }

        static void FilterArrayMarshaling_Test()
        {
            var expectedResult = new[] {1, 2};
            var stubConstraint = 3;
            var stubNumbers = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var actualResult = HackerRank.FilterArrayMarshaling(stubConstraint, stubNumbers);

            Comparators.TwoCollectionsShouldBeSame(actualResult, expectedResult);
        }

        static void FilterPositionsInAList_Test()
        {
            var expectedResult = new[] {1, 3, 5, 7, 9};
            var stubNumber = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var actualResult = HackerRank.FilterPositionsInAList(stubNumber);

            Comparators.TwoCollectionsShouldBeSame(actualResult, expectedResult);
        }

        static void ArrayOfNElements_Test()
        {
            var expectedResult = new[] {0, 1, 2};
            var stubNumber = 3;
            var actualResult = HackerRank.ArrayOfNElements(stubNumber);

            Comparators.TwoCollectionsShouldBeSame(actualResult, expectedResult);
        }

        static void ReverseAList_Test()
        {
            var expectedResult = new[] {0, 1, 2};
            var stubList = new[] {2, 1, 0};
            var actualResult = HackerRank.ReverseAList(stubList);

            Comparators.TwoCollectionsShouldBeSame(actualResult, expectedResult);
        }

        static void SumOdd_Test()
        {
            var expectedResult = 12;
            var stubList = new[] {-2, 1, 4, 0, 3, -1, 9};
            var actualResult = HackerRank.SumOdd(stubList);

            Comparators.TwoNumbersShouldBeSame(actualResult, expectedResult);
        }

        static void ListLength_Test()
        {
            var expectedResult = 3;
            var stubList = new[] {1, 2, 3};
            var actualResult = HackerRank.ListLength(stubList);

            Comparators.TwoNumbersShouldBeSame(actualResult, expectedResult);
        }
        
        static void UpdateList_Test()
        {
            var expectedResult = new[] {1, 2, 3, 2};
            var stubList = new[] {-1, 2, -3, 2};
            var actualResult = HackerRank.UpdateList(stubList);

            Comparators.TwoCollectionsShouldBeSame(actualResult, expectedResult);
        }
    }
}
