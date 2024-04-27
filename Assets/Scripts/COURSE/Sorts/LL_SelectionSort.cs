using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LL_SelectionSort : LL_Sort
{
    public override func_res Sort(LinkedList<int> list)
    {
        ulong comp = 0;
        ulong swaps = 0;
        var time = new Stopwatch();


        var node = list.First;

        time.Start();
        while (node != null)
        {
            var min = node;
            var next = node.Next;
            while (next != null)
            {
                comp++;
                if (next.Value < min.Value)
                {
                    min = next;
                }
                next = next.Next;
            }

            swaps++;
            (node.Value, min.Value) = (min.Value, node.Value);

            node = node.Next;
        }
        time.Stop();

        return new(time.ElapsedMilliseconds, comp, swaps);
    }

}
