// ArrayIntersectionTests.cs
using NUnit.Framework;
using ArrayIntersectionLib;
using System;

namespace ArrayIntersectionTests
{
    [TestFixture]
    public class ArrayIntersectionUnitTests
    {
        /// <summary>
        /// Helper method to compare two integer arrays irrespective of their order.
        /// Returns true if both arrays contain the same elements, false otherwise.
        /// </summary>
        private bool AreArraysEqual(int[] actual, int[] expected)
        {
            if (actual == null && expected == null)
                return true;
            if (actual == null || expected == null)
                return false;
            if (actual.Length != expected.Length)
                return false;

            Array.Sort(actual);
            Array.Sort(expected);

            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] != expected[i])
                    return false;
            }

            return true;
        }

        [Test]
        public void Test_TypicalCase()
        {
            int[] arr1 = { 4, 9, 5 };
            int[] arr2 = { 9, 4, 9, 8, 4 };
            int[] expected = { 4, 9 };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_OneArrayEmpty()
        {
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = { };
            int[] expected = { };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_BothArraysEmpty()
        {
            int[] arr1 = { };
            int[] arr2 = { };
            int[] expected = { };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_NoCommonElements()
        {
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = { 4, 5, 6 };
            int[] expected = { };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_AllElementsCommon()
        {
            int[] arr1 = { 7, 7, 7 };
            int[] arr2 = { 7, 7, 7, 7 };
            int[] expected = { 7 };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_WithDuplicates()
        {
            int[] arr1 = { 1, 2, 2, 3, 4 };
            int[] arr2 = { 2, 2, 4, 4, 6 };
            int[] expected = { 2, 4 };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_WithNegativeNumbers()
        {
            int[] arr1 = { -1, -2, -3, 4 };
            int[] arr2 = { -3, 4, 5 };
            int[] expected = { -3, 4 };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_DifferentSizes()
        {
            int[] arr1 = { 1, 3, 5, 7, 9 };
            int[] arr2 = { 3, 4, 5, 6, 7 };
            int[] expected = { 3, 5, 7 };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_LargeArrays()
        {
            // Creating large arrays with overlapping elements
            int size = 10000;
            int[] arr1 = new int[size];
            int[] arr2 = new int[size];
            int overlapStart = 5000;

            for (int i = 0; i < size; i++)
            {
                arr1[i] = i + 1;        // 1 to 10000
                arr2[i] = i + overlapStart + 1; // 5001 to 15000
            }

            // Expected intersection: 5001 to 10000
            int expectedSize = size - overlapStart;
            int[] expected = new int[expectedSize];
            for (int i = 0; i < expectedSize; i++)
            {
                expected[i] = overlapStart + 1 + i;
            }

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_SingleElementArrays()
        {
            int[] arr1 = { 100 };
            int[] arr2 = { 100 };
            int[] expected = { 100 };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_SingleElementArrays_NoIntersection()
        {
            int[] arr1 = { 100 };
            int[] arr2 = { };
            int[] expected = { };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_ArraysWithMinMaxValues()
        {
            int[] arr1 = { int.MinValue, 0, int.MaxValue };
            int[] arr2 = { int.MinValue, int.MaxValue, 100 };
            int[] expected = { int.MinValue, int.MaxValue };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed");
        }

        [Test]
        public void Test_NullInputs()
        {
            int[] arr1 = null;
            int[] arr2 = { 1, 2, 3 };
            int[] expected = { };

            int[] resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            int[] resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed for null arr1");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed for null arr1");

            arr1 = new int[] { 1, 2, 3 };
            arr2 = null;
            resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed for null arr2");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed for null arr2");

            arr1 = null;
            arr2 = null;
            resultHashSet = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
            resultSorting = ArrayIntersection.IntersectUsingSorting(arr1, arr2);

            Assert.IsTrue(AreArraysEqual(resultHashSet, expected), "HashSet Approach Failed for both null");
            Assert.IsTrue(AreArraysEqual(resultSorting, expected), "Sorting Approach Failed for both null");
        }
    }
}
