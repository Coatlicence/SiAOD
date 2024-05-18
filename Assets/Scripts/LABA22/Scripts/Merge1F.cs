using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Merge1F : SortScript_LABA22
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
        int AInd = 0; int BInd = 0;
        int st = 0;
        int SerLen = 1;

        while (st + SerLen < n)
        {
            if (AB)
            {
                for (int j1 = st; j1 < st + SerLen; j1++)
                {
                    res.swaps++;
                    A[AInd] = array[j1];
                    AInd++;
                }
                AB = false;
            }
            else
            {
                for (int j1 = st; j1 < st + SerLen; j1++)
                {
                    res.swaps++;
                    B[BInd] = array[j1];
                    BInd++;
                }
                AB = true;
            }
            st = st + SerLen;

        };
        if (AB)
        {
            for (int j1 = st; j1 < n; j1++)
            {
                res.swaps++;
                A[AInd] = array[j1];
                AInd++;
            }
        }
        else
        {
            for (int j1 = st; j1 < n; j1++)
            {
                res.swaps++;
                B[BInd] = array[j1];
                BInd++;
            }
        }
        int ALIndex = AInd; int BLIndex = BInd;
        while (SerLen < array.Length)
        {
            int step = SerLen;
            int Aindex = 0;
            int Bindex = 0;
            int AMindex = 0;
            int BMindex = 0;
            AB = true;
            while (step <= ALIndex && step <= BLIndex)
            {
                if (AB)
                {
                    while ((Aindex < step) && (Bindex < step))
                    {
                        res.comparisons++;
                        if (A[Aindex] < B[Bindex])
                        {
                            res.swaps++;
                            AM[AMindex] = A[Aindex];
                            Aindex++; AMindex++;
                        }
                        else
                        {
                            res.swaps++;
                            AM[AMindex] = B[Bindex];
                            Bindex++; AMindex++;
                        }
                    }
                    while (Aindex < step)
                    {
                        res.swaps++;
                        AM[AMindex] = A[Aindex];
                        Aindex++; AMindex++;
                    }
                    while (Bindex < step)
                    {
                        res.swaps++;
                        AM[AMindex] = B[Bindex];
                        Bindex++; AMindex++;
                    }
                    step = step + SerLen;

                    AB = false;
                }
                else
                {
                    while ((Aindex < step) && (Bindex < step))
                    {
                        res.comparisons++;
                        if (A[Aindex] < B[Bindex])
                        {
                            res.swaps++;
                            BM[BMindex] = A[Aindex];
                            Aindex++; BMindex++;
                        }
                        else
                        {
                            res.swaps++;
                            BM[BMindex] = B[Bindex];
                            Bindex++; BMindex++;
                        }
                    }
                    while (Aindex < step)
                    {
                        res.swaps++;
                        BM[BMindex] = A[Aindex];
                        Aindex++; BMindex++;
                    }
                    while (Bindex < step)
                    {
                        res.swaps++;
                        BM[BMindex] = B[Bindex];
                        Bindex++; BMindex++;
                    }
                    step = step + SerLen;
                    AB = true;
                }

            }
            if (AB)
            {
                while ((Aindex < ALIndex) && (Bindex < BLIndex))
                {
                    res.comparisons++;
                    if (A[Aindex] < B[Bindex])
                    {
                        res.swaps++;
                        AM[AMindex] = A[Aindex];
                        Aindex++; AMindex++;
                    }
                    else
                    {
                        res.swaps++;
                        AM[AMindex] = B[Bindex];
                        Bindex++; AMindex++;
                    }
                }
                while (Aindex < ALIndex)
                {
                    res.swaps++;
                    AM[AMindex] = A[Aindex];
                    Aindex++; AMindex++;
                }
                while (Bindex < BLIndex)
                {
                    res.swaps++;
                    AM[AMindex] = B[Bindex];
                    Bindex++; AMindex++;
                }

            }
            else
            {
                while ((Aindex < ALIndex) && (Bindex < BLIndex))
                {
                    res.comparisons++;
                    if (A[Aindex] < B[Bindex])
                    {
                        res.swaps++;
                        BM[BMindex] = A[Aindex];
                        Aindex++; BMindex++;
                    }
                    else
                    {
                        res.swaps++;
                        BM[BMindex] = B[Bindex];
                        Bindex++; BMindex++;
                    }
                }
                while (Aindex < ALIndex)
                {
                    res.swaps++;
                    BM[BMindex] = A[Aindex];
                    Aindex++; BMindex++;
                }
                while (Bindex < BLIndex)
                {
                    res.swaps++;
                    BM[BMindex] = B[Bindex];
                    Bindex++; BMindex++;
                }


            }
            ALIndex = AMindex;
            BLIndex = BMindex;
            SerLen = SerLen * 2;
            (A, AM) = (AM, A);
            (B, BM) = (BM, B);
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
