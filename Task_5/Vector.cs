namespace Task_5
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

        #region random

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

        #region quick sort

        public void QuickSort(int[] arr = null)
        {
            using (StreamReader reader = new StreamReader("elements.txt"))
            {
                string[] str = reader.ReadToEnd().Split(" ");

                if (str.Length == 0)
                    throw new ArgumentNullException();

                int[] numbers = Array.ConvertAll(str, s => int.Parse(s));

                if (arr == null)
                {
                    array = numbers;
                }
                else if (arr.Length == numbers.Length / 2)
                {
                    array = arr;
                }
                else throw new ArgumentException();
                    
                QuickSort(array, 0, array.Length - 1);
            }
        }

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

        #endregion

        #region pyramid sort
        public void PyramidSort() => SortHeap(array, array.Length);

        private void SortHeap(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                CreateHeap(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);

                CreateHeap(arr, i, 0);
            }
        }

        private void CreateHeap(int[] arr, int n, int i)
        {
            int root = i;

            int left = i * 2 + 1;
            int right = i * 2 + 2;

            if (left < n && arr[left] > arr[root])
                root = left;

            if (right < n && arr[right] > arr[root])
                root = right;

            if(root != i)
            {
                Swap(ref arr[root], ref arr[i]);
                CreateHeap(arr, n, root);
            }

        }

        #endregion

        public override string ToString()
        {
            return String.Format($"{string.Join(", ", array)}");
        }
    }
}
