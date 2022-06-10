using System;

namespace Task_3
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
            int randNum = 0;

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

        public bool IsPalindrome(long number = default)
        {
            if (number == default)
                throw new ArgumentNullException();

            long numLenght = number.ToString().Length;
            string reverseNum = "";
            long reverse;
            long j = 1;
            long k = 0;

            for (long i = 0; i < numLenght; i++)
            {
                reverseNum += (number % (long)Math.Pow(10, j+i) / (long)Math.Pow(10, k+i)).ToString();
            }

            reverse = long.Parse(reverseNum.ToString());

            if (number == reverse)
                return true;

            return false;
        }

        public int[] ReverseElements(int[] array)
        {
            int[] reversedArr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reversedArr[i] = array[array.Length - i - 1];
            }

            return reversedArr;
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < array.Length; i++)
            {
                str += array[i] + " ";
            }

            return String.Format(str + "\n");
        }
    }
}
