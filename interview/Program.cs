//Write a function that takes as parameters two unsorted arrays of integers and 
//    outputs an array with the intersection of the two inputs. arrays. 
//    a. Follow up: how to optimize this? (a: store largest in a tree and traverse 
//    for each element in another array, or sort both arrays and iterate through them together)
//b. Follow up: what is the big O time for this? (a: O(n * log(n)) 
//    to sort and O(n) to find each intersected element = O(n*log(n)))
//has context menu.


using System;
using System.Collections.Generic;


public class ArrayIntersection
{
    public static int[] IntersectUsingHashSet(int[] arr1, int[] arr2)
    {
        if (arr1 == null || arr2 == null)
        {
            return new int[0];
        }
        HashSet<int> set = new HashSet<int>();
        foreach (int num in arr1)
        {
            set.Add(num);
        }
        HashSet<int> result = new HashSet<int>();
        foreach (int num in arr2)
        {
            if (set.Contains(num))
            {
                result.Add(num);
            }
        }

        int[] resultArray = new int[result.Count];
        result.CopyTo(resultArray);
        return resultArray;
    }


    public static int[] IntersectUsingSort(int[] arr1, int[] arr2)
    {
        if (arr1 == null || arr2 == null)
        {
            return new int[0];
        }
        Array.Sort(arr1);
        Array.Sort(arr2);
        int i = 0;
        int j = 0;
        List<int> result = new List<int>();
        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] == arr2[j])
            {
                result.Add(arr1[i]);
                i++;
                j++;
            }
            else if (arr1[i] < arr2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }
        return result.ToArray();
    }
}


public class Program
{ 
    public static void Main()
    {
        int[] arr1 = {4,9,5  };
        int[] arr2 = { 9,4,9,8,4 };
        int[] intersection = ArrayIntersection.IntersectUsingHashSet(arr1, arr2);
        Console.WriteLine("Intersection  " + string.Join(",", intersection));
       intersection = ArrayIntersection.IntersectUsingSort(arr1, arr2);
            Console.WriteLine("Intersection  " + string.Join(",", intersection));

        }
}

//follow up question: how to optimize this? 
// Optimizing the intersion depends on the specific constraints of the problem, such as the 
//size of the arrays, the range of values, and the available memory.
//1. using hashset.  - pros : the time complexity is O(n+m), where n and m are the lengths of the two arrays.
//space complexity : requires additional space propotinall to the size of the arrays.
//Cons: Requires extra memeory for the Hashset
//2. using sort and two pointers:   - pros: no extra space required,
//Cons:  time complexity is O(nlogn + mlogm), where n and m are the lengths of the two arrays.


//choosing apprach: I would choose Hashset apprach when you aim for better time complexity and have enough memory to store the hashset.
//I would choose sort and two pointers apprach when you aim for better space complexity and have limited memory.



// what is the big O time for this?
//haset approach: O(n+m) where n and m are the lengths of the two arrays.

//sort and two pointers approach: O(nlogn + mlogm) where n and m are the lengths of the two arrays.



//compasion of two approaches:
//1. Hashset approach: offer better time complexity of O(n+m) but requires extra space proportional to the size of the arrays.
//2. Sort and two pointers approach: offer better space complexity of O(1) but requires O(nlogn + mlogm) time complexity.


//consultion: There are pros and corn in both approaches.
//The choice of the approach depends on the specific constraints of the problem, such as the size of the arrays,
//the range of values, and the available memory.
//If you aim for better time complexity and have enough memory to store the hashset, you can choose the hashset approach.
//If you aim for better space complexity and have limited memory, you can choose the sort and two pointers approach.




