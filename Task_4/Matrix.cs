using System;

namespace Task_4
{
    public enum StartDirection
    {
        Right,
        Down
    }

    public class Matrix
    {
        public int[] FindBiggestSequence(int[] arr)
        {
            int[] sequence = new int[arr.Length];
            int j = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i-1] == arr[i])
                {
                    sequence[j] = arr[i-1];
                    j++;
                    sequence[j] = arr[i];
                }
            }

            Array.Resize(ref sequence, j+1);

            if (sequence.Length <= 1)
                throw new Exception("there are no identical numbers to find sequence!");

            return sequence;
        }

        private enum CurrentDirection { RightUp, LeftDown, Down, Right, Start};

        public int[,] SnakeMatrix(StartDirection startDir, int[,] arr)
        {
            if (arr.Length == 0)
                throw new ArgumentNullException();
            if (arr.GetLength(0) != arr.GetLength(1))
                throw new FormatException("please, enter square matrix!");

            CurrentDirection currDir = CurrentDirection.Start;
            int length = arr.GetLength(1);
            int x = 0;
            int y = 0;

            for (int i = 0; i < length * length; i++)
            {
                arr[x, y] = i+1;

                switch (currDir)
                {
                    case CurrentDirection.Start:

                        if (x == 0 && y == 0)
                        {
                            switch (startDir)
                            {
                                case StartDirection.Right:
                                    x++;
                                    currDir = CurrentDirection.LeftDown;
                                    break;

                                case StartDirection.Down:
                                    y++;
                                    currDir = CurrentDirection.RightUp;
                                    break;
                            }

                        }
                        break;

                    case CurrentDirection.RightUp:

                        y--;
                        x++;

                        if (x == length - 1) currDir = CurrentDirection.Down;
                        if (y == 0 && x < length - 1) currDir = CurrentDirection.Right;

                        break;

                    case CurrentDirection.LeftDown:

                        x--;
                        y++;

                        if (x == 0 && y < length - 1) currDir = CurrentDirection.Down;
                        if (y == length - 1) currDir = CurrentDirection.Right;

                        break;

                    case CurrentDirection.Down:

                        y++;

                        if (x == 0 && y != 0) currDir = CurrentDirection.RightUp;
                        if (x == length - 1) currDir = CurrentDirection.LeftDown;
                        if (x == length - 1 && y == length - 1)
                            break;

                        break;

                    case CurrentDirection.Right:

                        x++;

                        if (x < length - 1) currDir = CurrentDirection.RightUp;
                        if (x == length - 1) currDir = CurrentDirection.LeftDown;
                        if (x == length - 1 && y == length - 1)

                            break;
                        break;
                }
            }
            return arr;
        }

    }
}