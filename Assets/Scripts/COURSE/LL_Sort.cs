using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LL_Sort : MonoBehaviour
{
    public struct func_res
    {
        public func_res(double _time = 0, ulong _comparisons = 0, ulong _swaps = 0)
        {
            time = _time;
            comparisons = _comparisons;
            swaps = _swaps;
        }

        public double time;
        public ulong comparisons;
        public ulong swaps;
    }
    public abstract func_res Sort(LinkedList<int> list);

    protected void Swap(ref LinkedListNode<int> left, ref LinkedListNode<int> right)
    {

        var list = left.List;

        var newright = list.AddAfter(left, right.Value);
        var newleft = list.AddAfter(right, left.Value);

        list.Remove(left);
        list.Remove(right);

        left = newleft;
        right = newright;
    }
}
