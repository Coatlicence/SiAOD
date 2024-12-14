using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HeapSort : SortScript
{
    public override func_res Sort(int[] array)
    {
        int length = array.Length;
        ulong comparisons = 0;
        ulong swaps = 0;
        var sw = new Stopwatch();

        sw.Start();
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            func_res tmp = FixDown(array, length, i);
            comparisons += tmp.comparisons;
            swaps += tmp.swaps;
        }
        for (int i = length - 1; i > 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            func_res tmp = FixDown(array, i, 0);
            comparisons += tmp.comparisons;
            swaps += tmp.swaps;
        }

        sw.Stop();
        return new func_res(sw.ElapsedMilliseconds, comparisons, swaps);

    }

    static func_res FixDown(int[] array, int length, int i)
    {
        ulong comparisons = 0;
        ulong swaps = 0;
        while (2 * i + 1 < length)
        {
            int j = 2 * i + 1;
            if (j + 1 < length && array[j] < array[j + 1]) 
                j++;

            comparisons += 2;
            
            if (array[i] >= array[j]) break;
            (array[i], array[j]) = (array[j], array[i]);
            swaps++;
            i = j;
        }
        return new func_res(0, comparisons, swaps);
    }
}
