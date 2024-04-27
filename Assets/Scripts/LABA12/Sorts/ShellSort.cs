using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShellSort : SortScript
{
    public override func_res Sort(int[] arr)
    {
        ulong comparisons = 0;
        ulong swap = 0;

        var time = new Stopwatch();
        time.Start();
        int j;

        int step = 1;
        while (step <= arr.Length / 3)
        {
            step = 3 * step + 1;
        }


        while (step > 0)
        {
            for (int i = 0; i < (arr.Length - step); i++)
            {
                j = i;
                int tmp = arr[j + step];
                while ((j >= 0) && (arr[j] > tmp))
                {
                    comparisons++;
                    arr[j + step] = arr[j];
                    j -= step;
                    swap++;
                }
                arr[j + step] = tmp;

                comparisons++;
            }
            step = (step - 1) / 3;
        }

        time.Stop();
        return new func_res(time.ElapsedMilliseconds, comparisons, swap);
    }
}
