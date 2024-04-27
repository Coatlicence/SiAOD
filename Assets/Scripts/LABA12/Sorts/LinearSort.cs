using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LinearSort : SortScript
{
    public override func_res Sort(int[] array)
    {
        ulong comparisons = 0;
        ulong swap = 0;
        int[] tmpArray = new int[array.Length];

        var time = new Stopwatch();
        time.Start();

        for (int i = 0; i < array.Length; i++)
        {
            comparisons++;
            swap++;
            tmpArray[array[i]]++;
        }

        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < tmpArray[i]; j++)
            {
                swap++;
                array[index] = i;
                index++;
            }
        }
        time.Stop();
        return new func_res(time.ElapsedMilliseconds, comparisons, swap);
    }
}
