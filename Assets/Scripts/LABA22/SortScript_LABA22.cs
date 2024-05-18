using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortScript_LABA22 : MonoBehaviour
{
    public struct func_res
    {
        public func_res(double _time = 0, ulong _comparisons = 0, ulong _swaps = 0)
        {
            time            = _time;
            comparisons     = _comparisons;
            swaps           = _swaps;
        }

        public double   time;
        public ulong    comparisons;
        public ulong    swaps;
    }
    public abstract func_res Sort(int[] arr); 
}
