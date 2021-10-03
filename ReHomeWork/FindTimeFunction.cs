using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;

namespace ReHomeWork
{
    class FindTimeFunction
    {

        public static void FindTime<T>(T[] array, Action<T[], int> f, List<int> time, int count)
        {
            T[] newArray = new T[array.Length];
            Array.Copy(array, newArray, array.Length);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(newArray, count);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}", ts.Ticks);
            Console.WriteLine(elapsedTime);

            time.Add(Convert.ToInt32(elapsedTime));
        }
        public static void CreateArray(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < 2000; i++)
            {
                array[i] = rnd.Next(1, 9);
            }
        }
        public static void СonstantFunction(int[] array, int count)
        {

        }

        public static void SumOfElements(int[] array, int count)
        {
            BigInteger sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum = sum + array[i];
            }
        }

        public static void СompositionfElements(int[] array, int count)
        {
            BigInteger сomposition = 1;
            for (int i = 0; i < count; i++)
            {
                сomposition = сomposition * (BigInteger)array[i];
            }
        }
        public static void GornerMethod(int[] array, int count)
        {
            BigInteger num = 1;
            for (int i = 0; i < count; i++)
            {
                num = num + (BigInteger)Math.Pow(1.2, count - i);
            }
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void BubbleSort(int[] array, int count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (array[i] > array[j])
                    {
                        Swap(array, i, j);
                    }
                }
            }
        }

        static void QuickSwap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    QuickSwap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            QuickSwap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        public static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static void QuickSort(int[] array, int count)
        {
            int[] newArray = new int[array.Length];
            Array.Copy(array, newArray, array.Length);

            QuickSort(newArray, 0, count);
        }

        public static void Pow(int[] array, int count)
        {
            int num = FindNumForPow(array);

            BigInteger pow = 1;
            for (int i = 0; i < count; i++)
            {
                pow *= num;
            }
        }
        public static void RecPow(int[] array, int count)
        {
            int num = FindNumForPow(array);
            RecPow(num, count);
        }
        public static BigInteger RecPow(int num, int count)
        {
            BigInteger h;

            if (count == 0)
            {
                return 1;
            }
            else
            {
                h = RecPow(num, count / 2);
                if (count % 2 == 1)
                {
                    return h * h * num;
                }
                else
                {
                    return h * h;
                }
            }
        }
        public static void QuickPow(int[] array, int count)
        {
            BigInteger num = FindNumForPow(array);
            int k = count;
            BigInteger f = 0;

            if (k % 2 == 1)
            {
                f = num;
            }
            else f = 1;

            while (k != 0)
            {
                k = k / 2;
                num *= num;

                if (k % 2 == 1)
                {
                    f = f * num;
                }
            }
        }

        public static int FindNumForPow(int[] array)
        {
            int index = 2;
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] != 1)
                {
                    index = j;
                    break;
                }
            }

            return array[index];
        }

        public static void QuickPowTwo(int[] array, int count)
        {
            BigInteger num = FindNumForPow(array);
            BigInteger f = 1;
            int k = count;

            while (k != 0)
            {
                if (k % 2 == 0)
                {
                    num *= num;
                    k = k / 2;
                }
                else
                {
                    f *= num;
                    k--;
                }
            }
        }
    }
}
