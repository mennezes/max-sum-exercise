using System;

namespace MaxSum
{
    public class MaxSum
    {
        /// <summary>
        /// Finds the biggest sum of numbers in an array, with no adjacent elements
        /// </summary>
        /// <param name="arr">An array of non-negative integers, with a length between 1 and 10^9</param>
        /// <returns></returns>
        public int FindSum(int[] arr)
        {
            // Check the data
            if (arr == null) throw new ArgumentNullException("arr");
            if (arr.Length == 0) return 0;
            if (arr.Length > Math.Pow(10, 9)) throw new ArgumentException("The array exceeds the maximum length of 10^9", "arr");

            // Uses two integers to store values when we take the number at I, or when we skip
            long takeSum = arr[0];
            long skipSum = 0;

            // Loops through the array and starts at 1 because the 0 index is our first take sum
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < 0) throw new ArgumentException($"The array must contain non-negative numbers only", "arr");

                // The new Take sum will be the previous skip sum + the current number
                long newTakeSum = skipSum + arr[i];

                // Check if taking the current number is better than skipping it
                if (newTakeSum > takeSum)
                {
                    // It's better to take it, so, the new skipping sum is the older sum (we skipped the current index)
                    // and the new take sum is the previous skipping plus the current number
                    skipSum = takeSum;
                    takeSum = newTakeSum;
                }
                else
                {
                    // Not taking this number is better, so, skip it
                    skipSum = takeSum;
                }
            }

            // Final vali
            long sum = takeSum > skipSum ? takeSum : skipSum;
            if (sum > int.MaxValue) throw new OverflowException($"The sum of {sum} exceeds the int32 max value");

            // Return the bigger sum
            return (int)sum;
        }
    }
}
