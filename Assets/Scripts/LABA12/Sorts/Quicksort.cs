using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Quicksort : SortScript
{
    public override func_res Sort(int[] array)
    {
        Stopwatch time = new();

        time.Start();
        var res = Quicksort_(array, 0, array.Length); 
        time.Stop();

        res.time = time.ElapsedMilliseconds;

        return res;
    }

    static public func_res Quicksort_(int[] array, int startindex, int endindex)
    {
        if (startindex >= endindex)
        {
            func_res res = new() { comparisons = 1 };
            return res;
        }

        int index = startindex;
        ulong comparisons = 0;
        ulong swaps = 0;
        for (int i = startindex + 1; i < endindex; i++)
        {
            comparisons += 2;
            if (array[i] < array[index])
            {
                swaps += 2;

                (array[i], array[index + 1]) = (array[index + 1], array[i]);

                (array[index], array[index + 1]) = (array[index + 1], array[index]);

                index++;
            }
        }

        func_res rez1 = Quicksort_(array, startindex, index);
        func_res rez2 = Quicksort_(array, index + 1, endindex);

        return new func_res(0, comparisons + rez1.comparisons + rez2.comparisons, swaps + rez1.swaps + rez2.swaps);
    }
}
