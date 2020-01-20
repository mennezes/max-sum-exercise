# Max Sum
The goal of this algorithm is to find the maximum sum of non adjacent array elements. The array must be non-empty and contain only positive numbers.
Example 1: [1,2,3,4] = 6

# Implementation
The implementation can be found on the project MaxSum, class MaxSum, method FindSum. The method signature is `public int FindSum(int[] arr)`
Basic validation is executed on the begining of the algorithm, and validation about non-negative numbers, is executed during the execution.

# Tests
The project MaxSum.Tests contains BDD tests with example data based on the requirements.

# Remarks
As the requirement was to return an `integer` of an array of `integer` numbers, the sum can overflow the `Int32` max value. To avoid wrong results, the sum is executed using `long` numbers and before return, it is validated against the max value. If it overflows, an `OverflowException` is thrown.
