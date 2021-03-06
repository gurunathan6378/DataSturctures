﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Sorting : Form
    {
        public Sorting()
        {
            InitializeComponent();
        }

       
        private string DisplayResult (int[] output)
        {
            StringBuilder builder = new StringBuilder();
            foreach(int i in output)
            {
                builder.Append($"{i.ToString()},");
            }
            return builder.ToString();   
        }

        private string Display(int[] arr)
        {
            StringBuilder builder = new StringBuilder();
            arr.ToList().ForEach(e => builder.Append($" {e.ToString()}"));
            return builder.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Selection sort Time Complexity : 
            //Whether the array is sorted or not sorted finding min value in the array takes O(n^2)
            //Best/Worst/Average/Almost sorted Case the complexity is O(n^2)
            int[] arr = new int[] { 9, 7, 6, 15, 16, 5, 10, 11 };
            int minPos = 0;
            int minValue = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                minValue = arr[i];
                for(int j = i+1; j<arr.Length; j++)
                {
                    if (arr[j] < minValue)
                    {
                        minValue = arr[j];
                        minPos = j;
                    }
                }

                int t = arr[i];
                arr[i] = arr[minPos];
                arr[minPos] = t;                
            }
            MessageBox.Show(this.Display(arr));
        }

      



        private void quickSort_Lomuto_partition_scheme(int[] input, int lower, int upper)
        {
            if (input != null && input.Length > 0 && lower < upper)
            {
                int i = this.Lomuto_partition_scheme(input, lower, upper);
                quickSort_Lomuto_partition_scheme(input, lower, i - 1);
                quickSort_Lomuto_partition_scheme(input, i + 1, upper);
            }
        }


        /// <summary>
        /// Complexity : Worst case is O(n^2) if the array is already ascending ordered
        /// </summary>
        /// <param name="input"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        private int Lomuto_partition_scheme(int[] input, int lower, int upper)
        {
            /* original input 11, 23, 1, 4, 0, -1, 55, 20               
            */
            int returnValue = -1;
            if (input != null && input.Length > 0)
            {
                int pivot = input[upper];    // pivot
                int i = (lower - 1);  // Index of smaller element

                for (int j = lower; j <= upper - 1; j++)
                {
                    // If current element is smaller than or
                    // equal to pivot
                    if (input[j] <= pivot)
                    {
                        i++;    // increment index of smaller element

                        this.Swap(input, i, j);
                    }
                }

                this.Swap(input, i + 1, upper);
                return (i + 1);

            }
            return returnValue;
        }



        private void Swap(int[] input, int from, int to)
        {
            if (from != to)
            {
                input[from] = input[from] + input[to];
                input[to] = input[from] - input[to];
                input[from] = input[from] - input[to];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // https://en.wikipedia.org/wiki/Quicksort
            //int[] input = new int[] { 11, 23, 1, 4, 0, -1, 55, 20 };
            int[] input = new int[] { 3,2,1};

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Before Sorting {DisplayResult(input)}");
            //Complexity  
            //Best Case     : O(n log n) if arrays are not sorted or partially sorted or sub list array have equal elements between left and right
            //Average Case  : O(n log n) 
            //Worst Case    : O(n^2) if the arrays are fully sorted 
            //Space complexity : O(log n)
            quickSort_Lomuto_partition_scheme(input, 0, input.Length - 1);
            result.AppendLine($"After Sorting {DisplayResult(input)}");
            MessageBox.Show(result.ToString());
        }



        private void quickSort_Hoares_partition_scheme(int[] input, int lower, int upper)
        {
            if (input != null && input.Length > 0 && lower < upper)
            {
                int i = this.Hoare_Partition_Scheme(input, lower, upper);
                quickSort_Hoares_partition_scheme(input, lower, i);
                quickSort_Hoares_partition_scheme(input, i + 1, upper);
            }
        }



        private int Hoare_Partition_Scheme(int[] arr, int low, int high)
        {
            //initial input  11, 23, 1, 4, 0, -1, 55, 20 
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                // Find leftmost element greater than
                // or equal to pivot
                do
                {
                    i++;
                } while (arr[i] < pivot);

                // Find rightmost element smaller than
                // or equal to pivot
                do
                {
                    j--;
                } while (arr[j] > pivot);

                // If two pointers met.
                if (i >= j)
                    return j;

                Swap(arr, i, j);
            }       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // https://en.wikipedia.org/wiki/Quicksort

            //int[] input = new int[] { 11, 23, 1, 4, 0, -1, 55, 20 };
            int[] input = new int[] { 3,2,1};
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Before Sorting {DisplayResult(input)}");
            //Complexity              
            //Best Case     : O(n log n) if arrays are not sorted or partially sorted or sub list array have equal elements between left and right
            //Average Case  : O(n log n) 
            //Worst Case    : O(n^2) if the arrays are fully sorted 
            //Space         : O(log n)
            quickSort_Hoares_partition_scheme(input, 0, input.Length - 1);
            result.AppendLine($"After Sorting {DisplayResult(input)}");
            MessageBox.Show(result.ToString());            
        }

        private void Merge_Sort_Top_down_implementation()
        {
            //https://en.wikipedia.org/wiki/Merge_sort

            // Worst -case performance O(n log n)
            // Best -case performance O(n log n) typical, O(n) natural variant
            // Average performance O(n log n)
            // Worst -case space complexity  О(n) total, O(n) auxiliary

            //int[] A = new int[] { 11, 23, 1, 4, 0, -1, 55, 20 };
            int[] A = new int[] { 3,2,1};
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Top Down : Before Sorting {DisplayResult(A)} \n");
            int[] B = new int[A.Length];            
            Array.Copy(A, B, A.Length);
            this.TopDownSplitMerge(B, 0, A.Length, A);
            result.AppendLine($"Top Down : After Sorting {DisplayResult(A)}");
            MessageBox.Show(result.ToString());
        }

        // Sort the given run of array A[] using array B[] as a source.
        // iBegin is inclusive; iEnd is exclusive (A[iEnd] is not in the set).
        public void TopDownSplitMerge(int[] B, int iBegin, int iEnd, int[] A)
        {
            if (iEnd - iBegin < 2) // if run size == 1
                return;            //   consider it sorted

            // split the run longer than 1 item into halves
            int iMiddle = (iEnd + iBegin) / 2;              // iMiddle = mid point
            
            // recursively sort both runs from array A[] into B[]
            TopDownSplitMerge(A, iBegin, iMiddle, B);  // sort the left  run
            TopDownSplitMerge(A, iMiddle, iEnd, B);  // sort the right run
            
            // merge the resulting runs from array B[] into A[]
            TopDownMerge(B, iBegin, iMiddle, iEnd, A);
        } 

        //  Left source half is A[ iBegin:iMiddle-1].
        // Right source half is A[iMiddle:iEnd-1   ].
        // Result is            B[ iBegin:iEnd-1   ].
        public void TopDownMerge(int[] A, int iBegin, int iMiddle, int iEnd, int[] B)
        {
            int i = iBegin, j = iMiddle;

            // While there are elements in the left or right runs...
            for (int k = iBegin; k < iEnd; k++)
            {
                // If left run head exists and is <= existing right run head.
                if (i < iMiddle && (j >= iEnd || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i++;
                }
                else
                {
                    B[k] = A[j];
                    j++;
                }
            }
        }



        
        // Merges two subarrays of arr[]. 
        // First subarray is arr[l..m] 
        // Second subarray is arr[m+1..r] 
        void merge(int[] arr, int l,
                        int m, int r)
        {
            /*  12, 11, 13, 5, 6, 7  - 5
                l = 0 m = 1 r = 2
            */

            // Find sizes of two subarrays 
            // to be merged 
            int n1 = m - l + 1; 
            int n2 = r - m; 

            // Create temp arrays  
            int[] L = new int[n1];
            int[] R = new int[n2];

            // Copy data to temp arrays 
            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];

            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];


            // Merge the temp arrays  

            // Initial indexes of first 
            // and second subarrays 
            i = 0;
            j = 0;

            // Initial index of merged 
            // subarry array 
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements  
            // of L[] if any  
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements 
            // of R[] if any  
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that sorts 
        // arr[l..r] using merge() 
        void sort(int[] arr, int l, int r)
        {
            /* 12, 11, 13, 5, 6, 7  - 5
              l = 0 r = 5 m = 2
              l = 0 r = 2 m = 1 
              l = 0 r = 1 m = 0
              l = 1 r = 1 m = 0

             */
            if (l < r)
            {
                // Find the middle point 
                int m = (l + r) / 2;

                // Sort first and  
                // second halves 
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves 
                merge(arr, l, m, r);
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            // Merge_Sort_Top_down_implementation();

            //https://en.wikipedia.org/wiki/Merge_sort

            // Worst -case performance O(n log n)
            // Best -case performance O(n log n) typical, O(n) natural variant
            // Average performance O(n log n)
            // Worst -case space complexity  О(n) total, O(n) auxiliary

            int[] input = { 12, 11, 13, 5, 6, 7 };
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Top Down : Before Sorting {DisplayResult(input)} \n");         
            sort(input, 0, input.Length - 1);
            result.AppendLine($"Top Down : After Sorting {DisplayResult(input)}");
            MessageBox.Show(result.ToString());


        }

        private int IParent(int count)
        {
            // 11, 23, 1, 4, 0, -1, 55, 20
            return (count) / 2;
        }

        private int ILeft(int count)
        {
            return ((2* count));
        }

        private int IRight(int count)
        {
            return ((2 * count) + 1);
        }

        private void ShiftDown(int[]a, int start, int end)
        {
            /*  12, 11, 13, 5, 6, 7
                start = 0 end = 5, child = 1 root = 0, interchange = 0  13, 11, 12, 5, 6, 7

            */
            int root = start;
            int child = 0;
            int interChange = 0;

            while(this.ILeft(root) <= end) //do    (While the root has at least one child)
            {
                child = this.ILeft(root); // (Left child of root)
                interChange = root;       // (Keeps track of child to swap with)

                if (a[interChange] < a[child])
                {
                    interChange = child;
                }

                //(If there is a right child and that child is greater)
                if ((child + 1) <= end && a[interChange] < a[child + 1])
		        {
                    interChange = child + 1;
                }

                if (interChange == root)
                {
                    //(The root holds the largest element.Since we assume the heaps rooted at the
                    //children are valid, this means that we are done.)
                    return;
                }
                else
                {
                    this.Swap(a, root, interChange);
                    root = interChange; //(repeat to continue sifting down the child now)
                }
            }
        }


        public void Heapify(int[] a , int count)
        {
            // 12, 11, 13, 5, 6, 7
            //(start is assigned the index in 'a' of the last parent node)
            //(the last element in a 0-based array is at index count-1; find the parent of that element)
            int start = this.IParent(count - 1);

            while (start >= 0)
            {
                //(sift down the node at index 'start' to the proper place such that all nodes below the start index are in heap order)
                this.ShiftDown(a, start, count - 1);
                //(go to the next parent node)
                start--;
                //(after sifting down the root all nodes/elements are in heap order)
            }
        }

        public void HeapSortAlogrithm(int[] a, int count)
        {
            //input: an unordered array a of length count

            //(Build the heap in array a so that largest value is at the root)
            this.Heapify(a, count);

            //(The following loop maintains the invariants that a[0:end] is a heap and every element
            //beyond end is greater than everything before it (so a[end:count] is in sorted order))
            int end = count - 1;
            while(end > 0)        
            {
                // 7 11, 12, 5, 6, 13
                // end = 4
                //(a[0] is the root and largest value. The swap moves it in front of the sorted elements.)
                this.Swap(a , end, 0);
                //(the heap size is reduced by one)
                end = end - 1;
                //(the swap ruined the heap property, so restore it)
                this.ShiftDown(a, 0, end);
        
            }
        }

        public void SortNew(int[] arr)
        {
            int n = arr.Length;

            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyNew(arr, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end 
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // call max heapify on the reduced heap 
                HeapifyNew(arr, i, 0);
            }
        }


        // To heapify a subtree rooted with node i which is 
        // an index in arr[]. n is size of heap 
        void HeapifyNew(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            // If left child is larger than root 
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far 
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree 
                HeapifyNew(arr, n, largest);
            }
        }

        private void HeapSort_Click(object sender, EventArgs e)
        {
            /*
             https://en.wikipedia.org/wiki/Heapsort
             http://www.geeksforgeeks.org/heap-sort/
             https://youtu.be/HqPJF2L5h9U
             */

            // Worst -case performance O(n log n)
            // Best -case performance O(n) 
            // Average performance O(n log n)
            // Worst -case space complexity  O(1) auxiliary

            //11, 23, 1, 4, 0, -1, 55, 20 
            //12, 11, 13, 5, 6, 7
            int[] input = { 12, 11, 13, 5, 6, 7 };
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Before Sorting {DisplayResult(input)}");

            this.HeapSortAlogrithm(input, input.Length);
            //this.SortNew(input);
            result.AppendLine($"After Sorting {DisplayResult(input)}");
            MessageBox.Show(result.ToString());
        }

        private void btn_Bubble_Sort_Click(object sender, EventArgs e)
        {
            /*
                Time Complexity is O(n^2)
                http://www.geeksforgeeks.org/bubble-sort/
            */

            int[] input = new int[] { 1,5, 4,2, 0, 12, 10 };

            if (input == null || input.Length == 0)
            {
                MessageBox.Show("Input array is empty");
            }

            StringBuilder result = new StringBuilder();
            result.Append($"Before Sorting {DisplayResult(input)} \n \n");

            for(int i = 0; i<input.Length; i++)
            {
                for (int j = 0; j < input.Length - i-1; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        input[j] = input[j] + input[j + 1];
                        input[j + 1] = input[j] - input[j + 1];
                        input[j] = input[j] - input[j + 1];
                    }
                }
            }

            result.Append($"After Sorting {DisplayResult(input)}");

            MessageBox.Show(result.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //http://quiz.geeksforgeeks.org/insertion-sort/
            //Time Complexity : 
            // Best case  : If array is in sorted order from small to big then time complexity is O(n) since no inversion 
            // Worst case : If all element is less than towards its left element then each element has to slide towards its 
            //              next position and inversion has to take place for n-1 elements where complexity is O(n^2)
            //              If half array is sorted and half array is not in sorted order the complexity is still O(n^2) 
            //Average case : O(n^2)
            //Almost sorted means the last element is smaller which means all the elements has to inverse at one time which is O(n) complexity
            int[] arr = new int[] { 9, 7, 6, 15, 16, 5, 10, 11 };
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int key = arr[i];
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
            MessageBox.Show(this.Display(arr));
        }
    }
}
