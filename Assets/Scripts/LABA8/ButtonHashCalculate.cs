using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHashCalculate : MonoBehaviour
{
    [Header("LABA8-9")]
    [SerializeField] TMP_InputField MethodDivision;
    [SerializeField] TMP_InputField MethodOfMiddleSquare;
    [SerializeField] TMP_InputField MethodOfClotting;
    [SerializeField] TMP_InputField MethodMultiplication;

    [SerializeField] TMP_InputField RepeatsCount;

    private List<int>[] HashTable = new List<int>[1000];
    private int[] ArrayWithRandomInt = new int[1000];

    [Header("LABA10")]
    [SerializeField] TMP_InputField AdressTime;
    [SerializeField] TMP_InputField AdressComparisons;
    [SerializeField] TMP_InputField AdressFound;

    [Header("LABA11")]
    [SerializeField] TMP_InputField ChainTime;
    [SerializeField] TMP_InputField ChainComparisons;
    [SerializeField] TMP_InputField ChainFound;
    //int key = 45678;

    // LABA 8-9
    public void Calculate()
    {
        //MethodDivision.text = (Division(key)).ToString();
        //MethodOfMiddleSquare.text = (MiddleSquare(key)).ToString();
        //MethodOfClotting.text = (Clotting(key)).ToString();
        //MethodMultiplication.text = (Multiplication(key)).ToString();

        M = int.Parse(RepeatsCount.text);

        int IsBestDivision = 0, IsBestMidSquare = 0, IsBestClotting = 0, IsBestMultilication = 0;
        for (int i = 0; i < M; i++)
        {
            int DivisionCollCount       = GetCountOfCollisions(new(Division));
            int MidSquareCollCount      = GetCountOfCollisions(new(MiddleSquare));
            int ClottingCollCount       = GetCountOfCollisions(new(Clotting));
            int MultiplicationCollCount = GetCountOfCollisions(new(Multiplication));

            int min = Math.Min( 
                               Math.Min(DivisionCollCount, MidSquareCollCount), 
                               Math.Min(ClottingCollCount, MultiplicationCollCount)
                               );

            if (DivisionCollCount == min)       IsBestDivision++;
            if (MidSquareCollCount == min)      IsBestMidSquare++;
            if (ClottingCollCount == min)       IsBestClotting++;
            if (MultiplicationCollCount == min) IsBestMultilication++;
            
        }
        MethodDivision.text         = Convert.ToString(IsBestDivision);
        MethodOfMiddleSquare.text   = Convert.ToString(IsBestMidSquare);
        MethodOfClotting.text       = Convert.ToString(IsBestClotting);
        MethodMultiplication.text   = Convert.ToString(IsBestMultilication);
    }

    private delegate int CheckHashCreationMethod(int key);

    private int GetCountOfCollisions(CheckHashCreationMethod method)
    {
        // Preparing
        Array.Clear(HashTable, 0, HashTable.Length);

        for (int i = 0; i < ArrayWithRandomInt.Length; i++)
        {
            ArrayWithRandomInt[i] = UnityEngine.Random.Range(0, 100000);
        }

        // Counting
        int CollCount = 0;
        for (int i = 0; i < ArrayWithRandomInt.Length; i++)
        {
            int index = method(ArrayWithRandomInt[i]);
            if (HashTable[index] == null)
            {
                HashTable[index] = new List<int>();
            }
            else
            {
                CollCount++;
            }
            HashTable[index].Add(ArrayWithRandomInt[i]);
        }
        return CollCount;
    }



    // LABA 10-11
    private static int M = 10000;
    public int[] M1 = new int[M];
    public int[] M2 = new int[M];
    public int[] MOA = new int[M];
    public List<int>[] MC = new List<int>[10000];

    public void LABA1011()
    {
        M = 10000;

        var time = new Stopwatch();
        int comparisons = 0;
        int found = 0;
        System.Random rnd = new System.Random();

        Array.Clear(MOA, 0, MOA.Length);
        for (int i = 0; i < M1.Length; i++)
        {
            M1[i] = rnd.Next(0, 10000);
        }
        for (int i = 0; i < M2.Length; i++)
        {
            M2[i] = rnd.Next(0, 20000);
        }

        for (int i = 0; i < M1.Length; i++)
        {
            int j = Multiplication(M1[i]);
            while (MOA[j] != 0)
            {
                j = (j + 1) % (M1.Length);
            }
            MOA[j] = M1[i];
        }

        time.Start();
        for (int i = 0; i < M2.Length; i++)
        {
            int j = Multiplication(M2[i]);
            int tmp = j - 1;
            if (j == 0)
            {
                tmp = M2.Length - 1;
            }
            while (j != tmp)
            {
                comparisons++;
                if (M2[i] == MOA[j])
                {
                    found++;
                    break;
                }
                j = (j + 1) % M2.Length;
            }
        }
        time.Stop();
        AdressTime.text = Convert.ToString(time.ElapsedMilliseconds);
        AdressComparisons.text = Convert.ToString((double)comparisons / M2.Length);
        AdressFound.text = Convert.ToString(found);


        comparisons = 0;
        found = 0;
        var time2 = new Stopwatch();
        Array.Clear(MC, 0, MC.Length);

        for (int i = 0; i < M1.Length; i++)
        {
            int j = Multiplication(M1[i]);
            if (MC[j] == null)
            {
                MC[j] = new List<int>();
            }
            MC[j].Add(M1[i]);
        }
        time2.Start();
        for (int i = 0; i < M2.Length; i++)
        {
            int j = Multiplication(M2[i]);
            comparisons++;
            if (MC[j] != null)
            {
                foreach (var elem in MC[j])
                {
                    comparisons++;
                    if (elem.Equals(M2[i]))
                    {
                        found++;
                        break;
                    }
                }
            }
        }
        time2.Stop();
        ChainTime.text = Convert.ToString(time2.ElapsedMilliseconds);
        ChainComparisons.text = Convert.ToString((double)comparisons / M2.Length);
        ChainFound.text = Convert.ToString(found);
    }

    int Division(int key)
    {
        return key % 997;
    }
    int MiddleSquare(int key)
    {
        int keyLength = (int)(Math.Log10(M - 1) + 1);
        long SquaredKey = (long)key^2;
        if (SquaredKey < M)
        {
            return (int)SquaredKey;
        }
        int LengthOfSquaredKey = Convert.ToInt32(Math.Log10(SquaredKey) + 1);

        LengthOfSquaredKey = (LengthOfSquaredKey - keyLength) / 2;

        SquaredKey = SquaredKey / Convert.ToInt32(Math.Pow(10, LengthOfSquaredKey));
        return (int)(SquaredKey % Convert.ToInt32(Math.Pow(10, keyLength)));
    }
    int Clotting(int key)
    {
        int sum = 0;
        int HashLength = 3;
        int lengthConst = (int)Math.Pow(10, HashLength);

        while (key > 0)
        {
            sum += key % lengthConst;
            key /= lengthConst;
        }
        return sum % lengthConst;
    }
    int Multiplication(int key)
    {
        double A = (Math.Sqrt(5) - 1) / 2;

        return (int)(M * (A * key % 1));
    }
}