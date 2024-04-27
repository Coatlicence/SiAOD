using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class InclusionSort : SortScript
{
    public override func_res Sort(int[] arr)
    {
        Stopwatch time = new Stopwatch();
        ulong comparisons = 0;
        ulong swaps = 0;

        time.Start();
        // барьер
        int min = arr[0];
        int toChange = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            comparisons++;
            if (arr[i] < min)
            {
                min = arr[i];
                toChange = i;
            }
        }
        swaps++;
        (arr[0], arr[toChange]) = (arr[toChange], arr[0]);

        // сортировка
        for (int i = 1; i < arr.Length; i++)
        {
            int value = arr[i];
            int index = i;
            while ((arr[index - 1] > value))
            {
                comparisons++;
                swaps++;
                arr[index] = arr[index - 1];
                index--;
            }
            comparisons++;
            swaps++;
            arr[index] = value;
        }
        return new func_res(time.ElapsedMilliseconds, comparisons, swaps);
    }
}
