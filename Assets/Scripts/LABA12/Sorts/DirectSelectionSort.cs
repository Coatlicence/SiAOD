using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DirectSelectionSort : SortScript
{
    public override func_res Sort(int[] arr)
    {
        ulong comp = 0;
        ulong swaps = 0;
        var time = new Stopwatch();

        time.Start();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                comp++;
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            (arr[i], arr[min]) = (arr[min], arr[i]);
            swaps++;
        }
        time.Stop();

        func_res res = new(time.Elapsed.TotalMilliseconds, comp, swaps);
        return res;
    }

}
