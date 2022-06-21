using System;

namespace Task_4
{
    public class Vector
    {
        private int[] array;

        public Vector()
        {
            array = new int[10];
        }

        public Vector(int n)
        {
            array = new int[n];
        }

        #region

        public void InitRandom(int min, int max)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(min, max);
            }
        }

        public void InitShuffle()
        {
            Random rnd = new Random();
            int randNum;

            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    randNum = rnd.Next(-10, array.Length);
                    if (!array.Contains(randNum))
                        break;
                }

                array[i] = randNum;
            }
        }

        #endregion
        
        public void QuickSort() => QuickSort(array, 0, array.Length-1);

        private int[] QuickSort(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return arr;

            int pivot = FindPivot(arr, minIndex, maxIndex);

            QuickSort(arr, minIndex, pivot - 1);
            QuickSort(arr, pivot + 1, maxIndex);

            return arr;
        }

        private int FindPivot(int[] arr, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (arr[i] < arr[maxIndex])
                {
                    pivot++;
                    Swap(ref arr[pivot], ref arr[i]);
                }
            }

            pivot++;
            Swap(ref arr[pivot], ref arr[maxIndex]);

            return pivot;
        }

        private void Swap(ref int a, ref int b) => (a, b) = (b, a);

        public override string ToString()
        {
            return String.Format($"{string.Join(", ", array)}");
        }
    }
}
