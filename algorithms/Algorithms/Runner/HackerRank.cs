using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Runner
{
    public static class HackerRank
    {
        // 1) Solve Me First FP (https://www.hackerrank.com/challenges/fp-solve-me-first/problem)
        // Complexity: 
        //     - Worse, Average and Best cases are O(1);
        // Memory usage: O(1);
        // How to improve: no options;
        public static int SumTwoNumbers(int A, int B)
        {
            return A + B;
        }

        // 2) Hello World N Times (https://www.hackerrank.com/challenges/fp-hello-world-n-times/problem)
        // Complexity: 
        //    - Worse and average case is O(N). Happens when n > 0;
        //    - Best case is O(1). Happens when n == 0;
        // Memory usage: O(1). Requiring memory only for allocating variables;
        // How to improve: no options;
        public static void HelloWorldNTimes(int n)
        {
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine("Hello world");
            }
        }

        // 3) List Replication (https://www.hackerrank.com/challenges/fp-list-replication/problem)
        // Complexity: 
        //     - Worse case is O(N^2). Happens when 'times' value == numbers.Length;
        //     - Average case is O(N*S). Happens when 'times' value and numbers.Length are different;
        //     - Best case is O(1). Happens when numbers.Length == 0;
        // Memory usage:
        //     - Worse case is O(N^2). Happens when 'times' == numbers.Length.
        //     - Average case is (N*S). Happens when 'times' != numbers.Length and both are not 0
        //     - Best case is O(1). Happens when numbers.Length == 1;
        // How to improve: no options;
        public static List<int> ListReplication(int times, List<int> numbers)
        {
            var result = new List<int>();
            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 0; j < times; j++)
                {
                    result.Add(numbers[i]);
                }
            }

            return result;
        }

        // 4) Filter Array (https://www.hackerrank.com/challenges/fp-filter-array/problem)
        // Complexity:
        //     - Worse and average cases O(N). Happens when numbers.Length > 0;
        //     - Best case O(1). Happens when numbers.length == 0;
        // Memory usage:
        //     - Worse and average cases: O(N). Happens when constraint > of some or most of numbers;
        //     - Best case: O(1). Happens when all numbers > constraint;
        // How to improve:
        //     - We can decrease amount of operations using marshaling.
        //       We will need only 1 loop instead of 2 because we can use 'cut' part of array containing zeros;  
        public static int[] FilterArray(int constraint, int[] numbers)
        {
            var amountOfLeftNumbers = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < constraint)
                {
                    amountOfLeftNumbers++;
                }
            }

            if (amountOfLeftNumbers == 0)
            {
                return new int[0];
            }

            var result = new int[amountOfLeftNumbers];
            var j = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < constraint)
                {
                    result[j++] = numbers[i];
                }
            }

            return result;
        }

        public static int[] FilterArrayMarshaling(int constraint, int[] numbers)
        {
            var resultActualLength = 0;
            var result = new int[numbers.Length];
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < constraint)
                {
                    result[resultActualLength++] = numbers[i];
                }
            }

            var size = Marshal.SizeOf(result[0]) * resultActualLength;
            var p = Marshal.AllocHGlobal(size);
            Marshal.Copy(result, 0, p, resultActualLength);

            var finalResult = new int[resultActualLength];
            Marshal.Copy(p, finalResult, 0, resultActualLength);

            return finalResult;
        }

        // 5) Filter Positions in a List (https://www.hackerrank.com/challenges/fp-filter-positions-in-a-list/problem)
        // Input: A List of integers (List<int> numbers)
        // Output: A List of filtered numbers
        // Complexity:
        //     - Worse and Average cases O(N). Happens when numbers.Count > 0;
        //     - Best case: O(1). Happens when numbers.Count == 0;
        // Memory usage:
        //     - Worse and Average cases O(N). Happens when numbers.Count > 0;
        //     - Best case: O(1). Happens when numbers.Count == 0;
        // How to improve: no options;
        public static int[] FilterPositionsInAList(List<int> numbers)
        {
            var length = numbers.Count % 2 == 0 ? numbers.Count / 2 : (numbers.Count + 1) / 2;
            var result = new int[length];
            var j = 0;

            for (var i = 0; i < numbers.Count; i += 2)
            {
                result[j++] = numbers[i];
            }

            return result;
        }

        // 6) Array Of N Elements (https://www.hackerrank.com/challenges/fp-array-of-n-elements/problem)
        // Complexity:
        //     - Worse and average cases: O(N). Happens when amount > 0;
        //     - Best case: O(1). Happens when amount == 0;
        // Memory usage: 
        //     - Worse and average cases: O(N). Happens when amount > 0;
        //     - Best case: O(1). Happens when amount == 0; 
        // How to improve:
        //     - With marshaling. Allocate an array in the low level;
        public static int[] ArrayOfNElements(int amount)
        {
            var res = new int[amount];
            for (var i = 0; i < amount; i++)
            {
                res[i] = i;
            }

            return res;
        }

        // 7) Reverse a List (https://www.hackerrank.com/challenges/fp-reverse-a-list/problem)
        // Complexity:
        //     - Worse and Average cases: O(N). Happens when n.Length > 0;
        //     - Best case: O(1). Happens when n.Length = 0;
        // Memory usage:
        //     - Worse and Average cases: O(N). Happens when n.Length > 0;
        //     - Best case: O(1). Happens when n.Length = 0;
        // How to improve: no options;
        public static int[] ReverseAList(int[] n)
        {
            var result = new int[n.Length];
            for (var i = 0; i < n.Length; i++)
            {
                result[i] = n[n.Length - 1 - i];
            }

            return result;
        }

        // 8) Sum of odd elements (https://www.hackerrank.com/challenges/fp-sum-of-odd-elements/problem)
        // Complexity:
        //     - Worse and Average cases: O(N). Happens when elements.Length > 0;
        //     - Best case: O(1). Happens when elements.Length == 1;
        // Memory usage: 
        //     - In all cases: O(1);
        // How to improve: no options;
        public static int SumOdd(int[] elements)
        {
            var result = 0;
            for (var i = 0; i < elements.Length; i++)
            {
                if (elements[i] % 2 != 0)
                {
                    result += elements[i];
                }
            }

            return result;
        }
        
        // 9) List length (https://www.hackerrank.com/challenges/fp-list-length)
        // Complexity:
        //     - Worse and Average cases: O(N). Happens when elements.Length > 0;
        //     - Best case: O(1). Happens when elements.Length == 1;
        // Memory usage: 
        //     - In all cases: O(1);
        // How to improve:
        //     - Store 'length' property inside type
        public static int ListLength(int[] elements)
        {
            var i = 0;

            while(i < elements.Length) 
            {
                i++;
            }

            return i;
        }
        
        // 10) Update List (https://www.hackerrank.com/challenges/fp-update-list/problem)
        // Complexity:
        //     - Worse and Average cases: O(N). Happens when elements.Length > 0;
        //     - Best case: O(1). Happens when elements.Length == 1;
        // Memory usage: 
        //     - In all cases: O(N);
        // How to improve: no options;
        public static int[] UpdateList(int[] elements)
        {
            var result = new int[elements.Length];

            for(var i = 0; i < elements.Length; i++)
            {
                result[i] = elements[i];
                if(result[i] < 0)
                {
                    result[i] = result[i] * -1;
                }
            }

            return result;
        }
    }
}
