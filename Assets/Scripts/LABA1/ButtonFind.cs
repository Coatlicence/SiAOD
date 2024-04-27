using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using TMPro;
using UnityEngine;

public class ButtonFind : MonoBehaviour
{
    [SerializeField] ManagerScript manager;

    [SerializeField] TMP_InputField FieldWithKey;

    [SerializeField] TMP_InputField SuboptimalTimer;
    [SerializeField] TMP_InputField SuboptimalIndex;

    [SerializeField] TMP_InputField OptimalTimer;
    [SerializeField] TMP_InputField OptimalIndex;

    Stopwatch tm = new();

    public void FindInUnordered()
    {
        ScriptSuboptimal(manager.UnorderedArray);
    }

    public void FindInOrdered()
    {
        ScriptOptimal(manager.OrderedArray);
    }

    private void ScriptSuboptimal(long[] array)
    {
        // suboptimal search
        long key = SuboptimalSearch(long.Parse(FieldWithKey.text), array);

        SuboptimalIndex.text = key.ToString();
        SuboptimalTimer.text = tm.Elapsed.Milliseconds.ToString() + " миллисекунд"; ;
        tm.Reset();

        // optimal search
        key = OptimalSearchUnoredered(long.Parse(FieldWithKey.text), array);

        OptimalIndex.text = key.ToString();
        OptimalTimer.text = tm.Elapsed.Milliseconds.ToString() + " миллисекунд"; ;
        tm.Reset();
    }

    private void ScriptOptimal(long[] array)
    {
        // suboptimal search
        long key = OptimalSearchUnoredered(long.Parse(FieldWithKey.text), array);

        SuboptimalIndex.text = key.ToString();
        SuboptimalTimer.text = tm.Elapsed.Milliseconds.ToString() + " миллисекунд";
        tm.Reset();

        // optimal search
        key = OptimalSearchOrdered(long.Parse(FieldWithKey.text), array);

        OptimalIndex.text = key.ToString();
        OptimalTimer.text = tm.Elapsed.Milliseconds.ToString() + " миллисекунд";
        tm.Reset();
    }

    private long SuboptimalSearch(long key, long[] array)
    {
        tm.Start();
        for (long i = 0; i < array.LongLength; i++)
        {
            if (array[i] == key)
            {
                tm.Stop();
                return i;
            }
        }

        tm.Stop();
        return -1;
    }

    private long OptimalSearchUnoredered(long key, long[] array)
    {
        array[array.LongLength - 1] = key;

        long i = 0;

        tm.Start();
        while (key != array[i])
        {
            i++;
        }
        tm.Stop();

        array[array.LongLength - 1] = 0;

        if (i == array.LongLength - 1)
            return -1;
        else
            return i;

    }

    private long OptimalSearchOrdered(long key, long[] array)
    {
        array[array.LongLength - 1] = key + 1;

        long i = 0;

        tm.Start();
        while (key > array[i])
        {
            i++;
        }
        tm.Stop();

        array[array.LongLength - 1] = 0;

        if (key == array[i])
            return i;
        else
            return -1;

    }

}
