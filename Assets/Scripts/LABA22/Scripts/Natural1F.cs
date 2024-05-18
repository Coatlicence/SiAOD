using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Natural1F : SortScript_LABA22
{
    public override func_res Sort(int[] array)
    {
        func_res res = new();
        Stopwatch sw = new();
        sw.Start();
        int n = array.Length;
        int[] A = new int[n];
        int[] B = new int[n];
        int[] AM = new int[n];
        int[] BM = new int[n];
        bool AB = true;
        int AInd = 0; int BInd = 0; int SerInd = 0;


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

        while (true)
        {

            int Aindex = 0;
            int Bindex = 0;
            int AArrayindex = 0;
            int BArrayindex = 0;
            int AendSer;
            int BendSer;
            AB = true;
            while (Aindex < AInd || Bindex < BInd)
            {
                if (AB)
                {
                    int Btmp = Bindex;
                    while (Btmp < BInd - 1 && B[Btmp] <= B[Btmp + 1])
                    {
                        res.comparisons++;
                        Btmp++;
                    }
                    res.comparisons++;
                    BendSer = Btmp;
                    if (BendSer == BInd) BendSer--;

                    int Atmp = Aindex;
                    while (Atmp < AInd - 1 && (A[Atmp] <= A[Atmp + 1]))
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
                            AM[AArrayindex++] = A[Aindex++];
                        }
                        else
                        {
                            res.swaps++;
                            AM[AArrayindex++] = B[Bindex++];
                        }
                    }
                    while (Bindex <= BendSer)
                    {
                        res.swaps++;
                        AM[AArrayindex++] = B[Bindex++];
                    }
                    while (Aindex <= AendSer)
                    {
                        res.swaps++;
                        AM[AArrayindex++] = A[Aindex++];
                    }
                    AB = false;
                }
                else
                {
                    int Btmp = Bindex;
                    while (Btmp < BInd - 1 && B[Btmp] <= B[Btmp + 1])
                    {
                        res.comparisons++;
                        Btmp++;
                    }
                    res.comparisons++;
                    BendSer = Btmp;
                    if (BendSer == BInd) BendSer--;
                    int Atmp = Aindex;
                    while (Atmp < AInd - 1 && (A[Atmp] <= A[Atmp + 1]))
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
                            BM[BArrayindex++] = A[Aindex++];
                        }
                        else
                        {
                            res.swaps++;
                            BM[BArrayindex++] = B[Bindex++];
                        }
                    }
                    while (Bindex <= BendSer)
                    {
                        res.swaps++;
                        BM[BArrayindex++] = B[Bindex++];
                    }
                    while (Aindex <= AendSer)
                    {
                        res.swaps++;
                        BM[BArrayindex++] = A[Aindex++];
                    }
                    AB = true;
                }

            }
            for (int i = 0; i < AM.Length; i++)
            {
                A[i] = AM[i];
                B[i] = BM[i];
                AM[i] = 0;
                BM[i] = 0;
            }
            AInd = AArrayindex; BInd = BArrayindex;
            if (AInd == 0 || BInd == 0) break;
        }

        for (int i = 0; i < A.Length; i++)
        {
            array[i] = A[i];
        }
        sw.Stop();
        res.time = (ulong)sw.ElapsedMilliseconds;
        return res;
    }
}
