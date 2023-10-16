using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SelectionSort : ISortingAlgorithm
    {
        

        public void Sort(int[] A)
        {
            //TODO #1: Implement SelectionSort
            for(int pivotPos=0; pivotPos<A.Length-1; pivotPos++)
            {
                for(int i=pivotPos+1; i<A.Length; i++)
                {
                    if (A[pivotPos] > A[i])
                    {
                        Swap(A,pivotPos,i);
                    }

                }
               


            }
            
        }

        private void Swap(int[] A,int pivotPos,int i) {

            int aux = A[pivotPos];
            A[pivotPos] = A[i];
            A[i] = aux;
        }

        public bool CheckIsCorrect()
        {
            int n = 10;
            int[] A = Utils.CreateIntArray(n);

            Console.WriteLine("1.1 Checking Sort()");
            Sort(A);
            if (!Utils.IsOrdered(A))
            {
                Console.WriteLine("FAILED");
                return false;
            }
            Console.WriteLine("PASSED");
            return true;
        }
    }
}
