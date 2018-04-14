using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSorting
{
    class Program
    {
        public static int[] QuickSort(int[] array, int start, int end)//быстрая сортировка
        {
            if (end == start || array.Length == 0) return null;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }
            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) QuickSort(array, start, storeIndex - 1);
            if (storeIndex < end) QuickSort(array, storeIndex + 1, end);
            return array;
        }

        static void Main(string[] args)
        {
            ThreeElem();
            EmptyArr();
            HundredSameElem();
            ThousandElem();
            Console.ReadKey();
        }

        private static void ThreeElem()//три элемента
        {
            int[] array = { 4, 1, 8 };
            array = QuickSort(array, 0, array.Length - 1);
            if (array[2] > array[1] && array[1] > array[0])
                Console.WriteLine("Быстрая сортировка массива из 3 чисел работает корректно");
            else
                Console.WriteLine("Быстрая сортировка массива из 3 чисел не работает");
        }

        private static void EmptyArr()//пустой массив
        {
            int[] emptyArray = { };
            emptyArray = QuickSort(emptyArray, 0, emptyArray.Length - 1);
            if (emptyArray == null)
                Console.WriteLine("Быстрая сортировка пустого массива работает корректно");
            else
                Console.WriteLine("Быстрая сортировка пустого массива не работает");
        }

        private static void HundredSameElem()//сто одинаковых
        {
            bool equal = true;
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i++)
                array[i] = 5;
            QuickSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
                if (array[i] != 5)
                    equal = false;
            if (equal == false)
                Console.WriteLine("Быстрая сортировка массива из 100 одинаковых чисел не работает");
            else
                Console.WriteLine("Быстрая сортировка массива из 100 одинаковых чисел работает корректно");
        }

        private static void ThousandElem()//Тысяча случайных чисел
        {
            bool win = true;
            int j = 100;
            var rnd = new Random();
            int[] array = new int[1000];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0, 999);
            QuickSort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= array[j])
                    win = true;
            }
            j++;
            if (win == true)
                Console.WriteLine("Быстрая сортировка массива из 1000 рандомных чисел работает корректно");
            else
                Console.WriteLine("Быстрая сортировка массива из 1000 рандомных чисел не работает");
        }
    }
}