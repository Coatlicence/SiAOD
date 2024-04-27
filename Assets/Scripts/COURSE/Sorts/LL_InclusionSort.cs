using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LL_InclusionSort : LL_Sort
{
    public override func_res Sort(LinkedList<int> list)
    {
        var time = new Stopwatch();
        ulong comp = 0;
        ulong swap = 0;

        time.Start();
        var node = list.First.Next;
        while (node != null)
        {
            var toChange = node;
            var value = node.Value;

            comp += 3;
            while ((toChange != list.First) && (toChange.Previous.Value > value))
            {
                //toChange.Value = toChange.Previous.Value;

                (toChange.Value, toChange.Previous.Value) = (toChange.Previous.Value, toChange.Value);

                swap++;

                toChange = toChange.Previous;
            }
            toChange.Value = value;

            node = node.Next;
        }
        time.Stop();

        return new(time.ElapsedMilliseconds, comp, swap);
    }
}
