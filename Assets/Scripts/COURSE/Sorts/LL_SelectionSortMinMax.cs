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
        ulong comp = 0;
        ulong swaps = 0;
        var time = new Stopwatch();

        var node = list.First;
        var lastnode = list.Last;

        time.Start();
        
        while (node != null)
        {
            var currentnode = node.Next;
            var minnode = node;
            var maxnode = lastnode;

            while (currentnode != null)
            {
                comp += 2;
                if (currentnode.Value < minnode.Value) minnode = currentnode;
                if (currentnode.Value > maxnode.Value) maxnode = currentnode;

                currentnode = currentnode.Next;
            }

            swaps += 2;
            (node.Value, minnode.Value)     = (minnode.Value, node.Value);
            (lastnode.Value, maxnode.Value) = (maxnode.Value, lastnode.Value);

            node = node.Next;
            lastnode = lastnode.Previous;
        }

        time.Stop();

        return new(time.ElapsedMilliseconds, comp, swaps);
    }
}
