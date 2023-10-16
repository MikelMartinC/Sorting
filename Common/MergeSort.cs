using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class MergeSort : ISortingAlgorithm
    {
        public int[] Partition(int[] A, int startIndex, int endIndex)
        {
            //TODO #1: return a new array with all elements in A from index startIndex to endIndex (both included): A[startIndex..endIndex]

            int[] partition = null;

            int size = endIndex - startIndex + 1;

            partition = new int[size];

            Array.Copy(A,statIndex, partition, 0, size);
            return partition;
        }

        public void MergePartitions(int[] A, int[] leftPartition, int[] rightPartition)
        {
            //TODO #2: Merge in A the two partitions sorting them

            int leftLength = leftPartition.Length;
            int rightLength = rightPartition.Length;
            int i= 0, j= 0; k=0;
            
            while (i < leftLength && j < rightLength)
            {
                if (leftPartition[i] < rightPartition[j])
                {
                    A[k] = leftPartition[i];
                    i++;
                }
                else
                {
                    A[k] = rightLength[j];
                    j++;
                }
                k++;
            }
            while (i < leftLength)
            {
                A[k]= leftPartition[i];
                i++;
                k++;
            }
            while( j < rightLength)
            {
                A[k]= rightPartition[j];
                j++;
                k++;
            }
        }

        public void Sort(int[] A)
        {
            //TODO #3: Implement MergeSort using the methods above
            int length = A.Length;
            if (length <= 1 )
            {
                return;
            }
            int mid = length / 2;
            int[] leftPartition = Partition(A, 0, mid - 1);
            int[] rightPartition = Partition(A, mid, length - 1);

            Sort(leftPartition);
            Sort(rightPartition);

            MergePartitions(A, leftPartition, rightPartition);
        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Partition()");
            if (!Utils.IsPartitionCorrect(A, Partition(A, 0, 3), 0, 3))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            if (!Utils.IsPartitionCorrect(A, Partition(A, 1, 1), 1, 1))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            Console.WriteLine("1.2. Checking MergePartitions()");
            int[] leftPartition = new int[3] { 1, 4, 6 };
            int[] rightPartition = new int[3] { 2, 3, 7 };
            int[] merged = new int[6] { 1, 4, 6, 2, 3, 7 };
            MergePartitions(merged, leftPartition, rightPartition);
            if (!Utils.IsOrdered(merged))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
