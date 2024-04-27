using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
//using static UnityEditor.PlayerSettings;


public class LABA5_ButtonSearch : MonoBehaviour
{
    Stopwatch tm = new();

    [SerializeField] ManagerScript manager;
    [SerializeField] TMP_InputField keyfield;

    // A
    [SerializeField] TMP_InputField SuB_Time;
    [SerializeField] TMP_InputField SuB_Index;

    // B
    [SerializeField] TMP_InputField OB_Time;
    [SerializeField] TMP_InputField OB_Index;

    // C
    [SerializeField] TMP_InputField IB_Time;
    [SerializeField] TMP_InputField IB_Index;

    // D
    [SerializeField] TMP_InputField SeB_Time;
    [SerializeField] TMP_InputField SeB_Index;

    // 4LABA
    [SerializeField] TMP_InputField OSO_Time;
    [SerializeField] TMP_InputField OSO_Index;


    public void Find()
    {
        // A
        tm.Reset();
        long key = SuboptimalBinary(manager.OrderedArray, long.Parse(keyfield.text));

        SuB_Index.text = key.ToString();
        SuB_Time.text = tm.Elapsed.Ticks.ToString() + " �����";
        tm.Reset();

        // B
        key = OptimalBinary(manager.OrderedArray, long.Parse(keyfield.text));

        OB_Index.text = key.ToString();
        OB_Time.text = tm.Elapsed.Ticks.ToString() + " �����";
        tm.Reset();

        // C
        key = InterpolationalBinary(manager.OrderedArray, long.Parse(keyfield.text));

        IB_Index.text = key.ToString();
        IB_Time.text = tm.Elapsed.Ticks.ToString() + " �����";
        tm.Reset();

        // D
        key = SequentialBinary(manager.OrderedArray, long.Parse(keyfield.text));

        SeB_Index.text = key.ToString();
        SeB_Time.text = tm.Elapsed.Ticks.ToString() + " �����";
        tm.Reset();

        // LABA4
        key = OptimalSearchOrdered(long.Parse(keyfield.text), manager.OrderedArray);

        OSO_Index.text = key.ToString();
        OSO_Time.text = tm.Elapsed.Ticks.ToString() + " �����";
        tm.Reset();

    }

    private long SuboptimalBinary(long[] arr, long key) // A
    {
        long i = 0;

        tm.Start();

        long R = arr.LongLength - 1;
        long L = 0;
        i = (L + R) / 2;
        while (R >= L)
        {
            if (key == arr[i])
                break;

            i = (L + R) / 2;

            if (key < arr[i])
                R = i - 1;
            else
                L = i + 1;
        }

        tm.Stop();

        if (key == arr[i])
            return i;
        else
            return -1;
    }

    private long OptimalBinary(long[] arr, long key) // B
    {
        long R = arr.LongLength - 1;
        long L = 0;
        long i;

        tm.Start();
        while (R > L)
        {
            i = (L + R) / 2;

            if (key <= arr[i])
            {
                R = i;
            }
            else
            {
                L = i + 1;
            }
        }
        tm.Stop();

        if (key == arr[R])
        {
            return R;
        }
        else
        {
            return -1;
        }
    
    }

    private long InterpolationalBinary(long[] arr, long key) // C
    {
        long L = 0;
        long R = arr.LongLength - 1;
        long i = 0;

        tm.Start();
        while ((arr[L] < key) && (arr[R] > key))
        {
            i = L + (int)((double)(R - L) / (arr[R] - arr[L]) * (key - arr[L]));

            if (arr[i] == key)
                break;

            if (key < arr[i])
                R = i - 1;
            else
                L = i + 1;

        }
        tm.Stop();

        if (key == arr[L])
        {
            return L;
        }
        else if (key == arr[R])
        {
            return R;
        }

        if (arr[i] == key) 
            return i;
        else 
            return -1;
    }

    private long SequentialBinary(long[] arr, long key) // D
    {
        long L = 0;
        long R = arr.LongLength / 2;

        tm.Start();
        while (R > 0)
        {
            while ((L + R < arr.LongLength) && (arr[L + R] <= key)) 
                L += R;
            
            R /= 2;
        }
        tm.Stop();

        if (arr[L] == key) 
            return L;
        else 
            return -1;

    }
    private long OptimalSearchOrdered(long key, long[] array)
    {
        if (key > array[array.LongLength - 1]) return -1;

        long i = 0;

        tm.Start();
        while (key > array[i])
        {
            i++;
        }
        tm.Stop();

        if (key == array[i])
            return i;
        else
            return -1;
    }
}
