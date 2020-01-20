Feature: MaxSum
	As a Mathematician
	I want to know the maximum sum of a subset of an array
	Excluding adjacent indexes

Scenario: Finding the sum
	Given the numbers in the array are <numbers>
	Then the sum should be <expected>
Examples:
| numbers                   | expected |
| 1,2,3,1                   | 4        |
| 2,7,9,3,1                 | 12       |
| 1,2,3,4,5                 | 9        |
| 2,1,2,5,3,1               | 8        |
| 2,2,2,5,5                 | 9        |
| 0,1                       | 1        |
| 0                         | 0        |
| 10                        | 10       |
| 1,1,1,1,1                 | 3        |
| 1,2,3,10,11,100,1,200,300 | 412      |

Scenario: Finding the sum of an empty array
	Given the size of the array is 0
	Then the sum should be 0

Scenario: Finding the sum of a null array
	Given there is no array
	Then an ArgumentNullException should be thrown

Scenario: Find the sum of an array with a negative number
	Given the numbers in the array are 1,-2,4
	Then an ArgumentException should be thrown

Scenario: Overflowing the sum
	Given the numbers in the array are 2147483640,2147483640,2147483640,2147483640
	Then an OverflowException should be thrown