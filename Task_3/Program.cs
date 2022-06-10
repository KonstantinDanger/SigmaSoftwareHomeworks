using System;

namespace Task_3
{
    public class ClientClass
    {
        static void Main()
        {
            #region 1st subtask        
            Vector vector = new Vector(10);
            vector.InitShuffle();
            Console.WriteLine(vector);

            Vector vector1 = new Vector();
            int num = 1441;
            Console.WriteLine($"The number \"{num}\" is a palindrome: " + vector1.IsPalindrome(num));

            Vector vector2 = new Vector();
            int num1 = new Random().Next(1, 999);
            Console.WriteLine($"The number \"{num1}\" is a palindrome: " + vector2.IsPalindrome(num1));

            Console.WriteLine();
            #endregion

            #region 2nd subtask
            int[] arr = new int[] { 1, 4, 6, 5, 71, 123 };
            int[] arr1 = arr;

            for (int i = 0; i < arr.Length; i++)
                Console.Write(vector.ReverseElements(arr)[i] + ",");
            Console.WriteLine();

            Array.Reverse(arr1);
            for (int i = 0; i < arr1.Length; i++)
                Console.Write(arr1[i] + ",");
            #endregion

            #region 3rd subtask
            Console.WriteLine("\n");
            Matrix matrix = new Matrix();
            int[] arr2 = new int[] { 1, 5, 7, 23, 76, 85, 85, 85, 6, 45 };
            int[] sequence = matrix.FindBiggestSequence(arr2);

            Console.WriteLine("biggest number sequence: ");
            for (int i = 0; i < sequence.Length; i++)
                Console.Write(sequence[i] + ",");
            Console.WriteLine("\n");
            #endregion

            #region 4th subtask

            int[,] matrixArr = new int[3,3];
            int[,] resMatrix;

            Matrix matrix1 = new Matrix();
            resMatrix = matrix1.SnakeMatrix(StartDirection.Down, matrixArr);
            string space;

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    if (resMatrix[j, i] < 10) 
                        space = "  ";
                    else 
                        space = " ";
                    
                    Console.Write(space + resMatrix[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            resMatrix = matrix1.SnakeMatrix(StartDirection.Right, matrixArr);
            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    if (resMatrix[j, i] < 10)
                        space = "  ";
                    else
                        space = " ";

                    Console.Write(space + resMatrix[j, i]);
                }
                Console.WriteLine();
            }

            #endregion
        }
    }
}