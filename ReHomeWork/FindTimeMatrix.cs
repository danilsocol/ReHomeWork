using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;

namespace ReHomeWork
{
    class FindTimeMatrix
    {
        public static void FindTime(Action<int[][,], int> f, List<int> time, int count)
        {
            int[][,] matrix = new int[2][,];
            matrix[0] = CreateMatrix(count);
            matrix[1] = CreateMatrix(count);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(matrix, count);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}", ts.Ticks);
            Console.WriteLine(elapsedTime);

            time.Add(Convert.ToInt32(elapsedTime));
        }

        public static int[,] CreateMatrix(int count)
        {
            int[,] matrix = new int[count, count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = rnd.Next(1, 9);
                }
            }
            return matrix;
        }

        public static void CompositionMatrix(int[][,] array, int count)
        {
            int[,] C = new int[count, count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    for (int k = 0; k < count; k++)
                    {
                        C[i, j] += array[0][i, k] * array[1][k, j];
                    }
                }
            }
        }
    }
}
