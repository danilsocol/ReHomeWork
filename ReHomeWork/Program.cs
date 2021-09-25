using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;

namespace ReHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[2000];

            FindTimeFunction.CreateArray(array);

            OutputDataFunction(array, FindTimeFunction.СonstantFunction, "СonstantFunction");
            OutputDataFunction(array, FindTimeFunction.SumOfElements, "SumOfElements");
            OutputDataFunction(array, FindTimeFunction.СompositionfElements, "СompositionfElements");
            OutputDataFunction(array, FindTimeFunction.GornerMethod, "GornerMethod");
            OutputDataFunction(array, FindTimeFunction.BubbleSort, "BubbleSort");
            OutputDataFunction(array, FindTimeFunction.QuickSort, "QuickSort");
            OutputDataFunction(array, FindTimeFunction.Pow, "Pow");
            OutputDataFunction(array, FindTimeFunction.RecPow, "RecPow");
            OutputDataFunction(array, FindTimeFunction.QuickPow, "QuickPow");
            OutputDataFunction(array, FindTimeFunction.QuickPowTwo, "QuickPowTwo");

            OutputDataFunction(array, FindTimeTreeSort.TreeSort, "TreeSort");

            OutputDataMatrix(FindTimeMatrix.CompositionMatrix, "CompositionMatrix");
        }

        static void OutputDataFunction<T>(T[] array, Action<T[], int> f, string nameAction)
        {
            List<int> time = new List<int>();

            using (StreamWriter file = new StreamWriter("Time.txt", true))
            {
                file.Write($"{nameAction};;");

                for (int j = 0; j < 2000; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        FindTimeFunction.FindTime(array, f, time, j);
                    }
                    int average = FindAverage(time);

                    file.Write($"{average};");
                    time.Clear();
                }

                file.WriteLine();
                file.Close();
            }
        }

        static void OutputDataMatrix(Action<int[][,], int> f, string nameAction)
        {
            List<int> time = new List<int>();

            using (StreamWriter file = new StreamWriter("Time.txt", true))
            {
                file.Write($"{nameAction};;");

                for (int j = 0; j < 200; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                      
                       FindTimeMatrix.FindTime(f, time, j + i);
                       
                    }
                    int average = FindAverage(time);

                    file.Write($"{average};");
                    time.Clear();
                }

                file.WriteLine();
                file.Close();
            }
        }

        static int FindAverage(List<int> time) 
        {
            int sum = 0;
            for (int i = 0; i < time.Count; i++)
            {
                sum += time[i];
            }
            return sum / time.Count;
        }
    }
}
