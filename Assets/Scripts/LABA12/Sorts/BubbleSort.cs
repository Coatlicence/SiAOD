using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BubbleSort : SortScript
{
    public override func_res Sort(int[] arr)
    {
        ulong comp = 0;
        ulong swaps = 0;
        var time = new Stopwatch();

        bool swapped;
        time.Start();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                comp++;
                if (arr[j] > arr[j + 1])
                {
                    (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                    swapped = true;
                    swaps++;
                }
            }
            if (!swapped) break;
        }
        time.Stop();

        func_res res = new(time.Elapsed.TotalMilliseconds, comp, swaps);
        return res;
    }
}
