using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace MaxSum.Tests.Steps
{
    [Binding]
    public class MaxSumSteps
    {
        private readonly MaxSum _maxSum = new MaxSum();
        private int[] _values;

        [Given(@"the numbers in the array are (.*)")]
        public void GivenTheNumbersInTheArrayAre(int[] values)
        {
            _values = values;
        }

        [Then(@"the sum should be (.*)")]
        public void ThenTheSumShouldBe(int expected)
        {
            Assert.AreEqual(expected, _maxSum.FindSum(_values));
        }

        [Given(@"there is no array")]
        public void GivenThereIsNoArray()
        {
            _values = null;
        }

        [Then(@"an ArgumentNullException should be thrown")]
        public void ThenAnArgumentNullExceptionShouldBeThrown()
        {
            bool thrown = false;
            try
            {
                _maxSum.FindSum(_values);
            }
            catch (ArgumentNullException)
            {
                thrown = true;
            }
            catch
            {
                // Ignores
            }

            Assert.IsTrue(thrown);
        }

        [Given(@"the size of the array is (.*)")]
        public void GivenTheSizeOfTheArrayExceeds(long arraySize)
        {
            _values = new int[arraySize];
        }


        [Then(@"an ArgumentException should be thrown")]
        public void ThenAnArgumentExceptionShouldBeThrown()
        {
            bool thrown = false;
            try
            {
                _maxSum.FindSum(_values);
            }
            catch (ArgumentException)
            {
                thrown = true;
            }
            catch
            {
                // Ignores
            }

            Assert.IsTrue(thrown);
        }

        [Then(@"an OverflowException should be thrown")]
        public void ThenAnOverflowExceptionShouldBeThrown()
        {
            bool thrown = false;
            try
            {
                _maxSum.FindSum(_values);
            }
            catch (OverflowException)
            {
                thrown = true;
            }
            catch
            {
                // Ignores
            }

            Assert.IsTrue(thrown);
        }

        [StepArgumentTransformation]
        public int[] TransformToIntegerArray(string numbers)
        {
            return numbers.Split(",").Select(int.Parse).ToArray();
        }
    }
}
