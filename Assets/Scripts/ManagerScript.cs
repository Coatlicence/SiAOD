using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    [SerializeField] TMP_InputField FieldWithUnorderedKey;

    public static long SizeOfArray = 10000000;

    public long[] UnorderedArray;   
    public long[] OrderedArray;

    void Start()
    {
        FieldWithUnorderedKey.text = LongRandom(0, SizeOfArray*10, new System.Random()).ToString();

        StartCoroutine(CreateArrays());
    }

    void FillUnorderedArray()
    {
        UnorderedArray = new long[SizeOfArray];

        for (long i = 0; i < SizeOfArray; i++)
        {
            UnorderedArray[i] = LongRandom(0, SizeOfArray*10, new System.Random());
        }
    }

    void FillOrderedArray()
    {
        OrderedArray = new long[SizeOfArray];

        OrderedArray[0] = 0;

        for (long i = 1; i < SizeOfArray; i++)
        {
            OrderedArray[i] = OrderedArray[i - 1] + 5;
        }
    }

    IEnumerator CreateArrays()
    {
        yield return new WaitForSeconds(1);

        //FillUnorderedArray();
        FillOrderedArray();

        yield break;
    }

    public static long LongRandom(long min, long max, System.Random rand)
    {
        long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
        result <<= 32;
        result |= (long)rand.Next((Int32)min, (Int32)max);
        return result;
    }
}


