using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Merge2F : SortScript_LABA22
{
    public override func_res Sort(int[] array)
    {
        func_res res = new();
        Stopwatch time = new();

        time.Start();
        int n = array.Length;
        int[] A = new int[n];
        int[] B = new int[n];

        int SerLen = 1;
        while (SerLen / 2 < array.Length)
        {
            bool AB = true;
            int AInd = 0; 
            int BInd = 0;
            int st = 0;
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
                st += SerLen;
            };

            if (AB)
                for (int j1 = st; j1 < n; j1++)
                {
                    res.swaps++;
                    A[AInd] = array[j1];
                    AInd++;
                }
            
            else            
                for (int j1 = st; j1 < n; j1++)
                {
                    res.swaps++;
                    B[BInd] = array[j1];
                    BInd++;
                }
            
            int step = SerLen;
            int Aindex = 0;
            int Bindex = 0;
            int Arrayindex = 0;
            while (step <= AInd && step <= BInd)
            {
                while ((Aindex < step) && (Bindex < step))
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
                while (Aindex < step)
                {
                    res.swaps++;
                    array[Arrayindex] = A[Aindex];
                    Aindex++; Arrayindex++;
                }
                while (Bindex < step)
                {
                    res.swaps++;
                    array[Arrayindex] = B[Bindex];
                    Bindex++; Arrayindex++;
                }
                step += SerLen;
            }
            while ((Aindex < AInd) && (Bindex < BInd))
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
            while (Aindex < AInd)
            {
                res.swaps++;
                array[Arrayindex] = A[Aindex];
                Aindex++; Arrayindex++;
            }
            while (Bindex < BInd)
            {
                res.swaps++;
                array[Arrayindex] = B[Bindex];
                Bindex++; Arrayindex++;
            }
            step += SerLen;
            SerLen *= 2;
        }
        time.Stop();
        res.time = time.ElapsedMilliseconds;
        return res;
    }
}
