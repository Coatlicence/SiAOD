using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class LL_SelectionSortMinMax : LL_Sort
{
    public override func_res Sort(LinkedList<int> list)
    {
        return new();
    }

    /*
    public override func_res Sort(LinkedList<int> list)
    {
        ulong comp = 0;
        ulong swaps = 0;
        var time = new Stopwatch();

        var minnode = list.First;
        var maxnode = list.Last;

        time.Start();
        while (minnode != maxnode)
        {
            var min = minnode;
            var max = maxnode;

            var next = minnode;
            while (next != maxnode.Previous)
            {
                comp++;
                if (next.Value < min.Value) 
                    min = next;

                comp++;
                if (next.Value > max.Value)
                    max = next;

                next = next.Next;
            }

            swaps++;
            (minnode.Value, min.Value) = (min.Value, minnode.Value);
            minnode = minnode.Next;

            swaps++; comp++;
            if (minnode.Value == maxnode.Value) 
                (maxnode.Value, max.Value) = (max.Value, maxnode.Value);
            maxnode = maxnode.Previous;
        }
        time.Stop();

        return new(time.ElapsedMilliseconds, comp, swaps);
    }




    public static int DirectMinMaxSelectionSorting(LinkedList<int> list)
{
    int minindex = 0, maxindex = 0;
    var time = new Stopwatch();
    time.Start();
    for (int j = 0; j < list.Count / 2; j++)
    {
        var min = int.MaxValue; var max = 0;
        var tmp = 0;
        for (int i = j; i < list.Count - j; i++)
        {
            if (min > list[i])
            {
                min = list.GetElement(i).Data;
                minindex = i;
            }
            if (list.GetElement(i).Data > max)
            {
                max = list.GetElement(i).Data;
                maxindex = i;
            }
        }

        tmp = list.GetElement(j).Data;
        if (j == maxindex)
        {
            maxindex = minindex;
        }

        list.GetElement(j).Data = min;
        list.GetElement(minindex).Data = tmp;

        tmp = list.GetElement(list.size - j - 1).Data;
        list.GetElement(list.size - j - 1).Data = max;
        list.GetElement(maxindex).Data = tmp;
    }
    time.Stop();
    return (int)time.ElapsedMilliseconds;
}
    */
}
