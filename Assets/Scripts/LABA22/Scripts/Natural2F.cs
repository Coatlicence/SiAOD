using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Natural2F : SortScript_LABA22
{
    public override func_res Sort(int[] array)
    {
        func_res res = new();
        Stopwatch sw = new();
        sw.Start();

        int n = array.Length;
        int AInd; int BInd; int SerInd;
        while (true)
        {
            int[] A = new int[n];
            int[] B = new int[n];
            bool AB = true;
            AInd = 0; BInd = 0; SerInd = 0;
            while (SerInd < n)
            {
                if (AB)
                {
                    A[AInd++] = array[SerInd++];
                    while (SerInd < n && array[SerInd - 1] <= array[SerInd])
                    {
                        res.comparisons++;
                        res.swaps++;
                        A[AInd++] = array[SerInd++];
                    }
                    res.comparisons++;
                    AB = false;
                }
                else
                {
                    B[BInd++] = array[SerInd++];
                    while (SerInd < n && array[SerInd - 1] <= array[SerInd])
                    {
                        res.comparisons++;
                        res.swaps++;
                        B[BInd++] = array[SerInd++];
                    }
                    res.comparisons++;
                    AB = true;
                }

            };
            if (BInd == 0) break;
            int Aindex = 0;
            int Bindex = 0;
            int Arrayindex = 0;
            int AendSer;
            int BendSer;
            while (Aindex < AInd && Bindex < BInd)
            {
                int Btmp = Bindex;
                while (Btmp < BInd && B[Btmp] <= B[Btmp + 1])
                {
                    res.comparisons++;
                    Btmp++;
                }
                res.comparisons++;
                BendSer = Btmp;
                if (BendSer == BInd) BendSer--;
                int Atmp = Aindex;
                while (Atmp < AInd && (A[Atmp] <= A[Atmp + 1]))
                {
                    res.comparisons++;
                    Atmp++;
                }
                res.comparisons++;
                AendSer = Atmp;
                if (AendSer == AInd) AendSer--;
                while (Aindex <= AendSer && Bindex <= BendSer)
                {
                    res.comparisons++;
                    if (A[Aindex] < B[Bindex])
                    {
                        res.swaps++;
                        array[Arrayindex] = A[Aindex];
                        Aindex++; Arrayindex++;
                    }
                    else
                    {
                        res.swaps++;
                        array[Arrayindex] = B[Bindex];
                        Bindex++; Arrayindex++;
                    }
                }
                while (Bindex <= BendSer)
                {
                    res.swaps++;
                    array[Arrayindex] = B[Bindex];
                    Bindex++; Arrayindex++;
                }
                while (Aindex <= AendSer)
                {
                    res.swaps++;
                    array[Arrayindex++] = A[Aindex++];
                }

            }



            while (Bindex < BInd)
            {
                res.swaps++;
                array[Arrayindex++] = B[Bindex++];

            }
            while (Aindex < AInd)
            {
                res.swaps++;
                array[Arrayindex++] = A[Aindex++];
            }
        }
        sw.Stop();
        res.time = (ulong)sw.ElapsedMilliseconds;
        return res;
    }
}
