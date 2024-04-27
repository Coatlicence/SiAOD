using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScrpt_Calculate : MonoBehaviour
{
    [SerializeField] 
    protected GameObject content;

    [SerializeField] TMP_InputField ArraySize;

    protected 
    static int DefaultSize = 10000;

    [SerializeField]
    protected int size = DefaultSize;

    protected int[] arr;

    private void Start()
    {
        PerformArrayCreating();
    }
    
    protected virtual bool CheckForSorted(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i + 1])
                return false;
        }

        return true;
    }

    protected int GetSizeOfArrayFromInputfield()
    {
        if (ArraySize == null) return -1;

        int size;

        if (!int.TryParse(ArraySize.text, out size))
        {
            size = -1;
        }

        return size;
    }

    protected virtual void PerformArrayCreating()
    {
        if (GetSizeOfArrayFromInputfield() != -1)
            size = GetSizeOfArrayFromInputfield();

        arr = new int[size];

        UnityEngine.Random.InitState(System.DateTime.UtcNow.Minute);

        for (long i = 0; i < size; i++)
        {
            arr[i] = (UnityEngine.Random.Range(0, size));
        }
    }

    public virtual void Perform()
    {
        for (int i = 0; i < content.transform.childCount; i++) // итерируем элементы таблицы
        {
            var TableElement = content.transform.GetChild(i); 

            var textComparisons = TableElement.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
            textComparisons.text = "Comparisons";
            var textSwaps = TableElement.GetChild(3).GetComponentInChildren<TextMeshProUGUI>();
            textSwaps.text = "Permutations";
            var textTime = TableElement.GetChild(4).GetComponentInChildren<TextMeshProUGUI>();
            textTime.text = "Time";
            var textSorted = TableElement.GetChild(5).GetComponentInChildren<TextMeshProUGUI>();
            textSorted.text = "Нет";

            Toggle toggle = TableElement.GetChild(0).GetComponent<Toggle>(); // получаем галочку

            if (toggle.isOn)
            {
                // получаем скрипт, который назначен для элемента таблицы
                SortScript script = TableElement.GetComponent<SortScript>(); 

                if (!script) continue;

                // создание копии массива
                int[] carr = new int[arr.Length];
                Array.Copy(arr, carr, arr.Length);

                SortScript.func_res res;
                res = script.Sort(carr); // выполняем алгоритм на копии

                textComparisons.text = res.comparisons.ToString();
                textSwaps.text = res.swaps.ToString();
                textTime.text = res.time.ToString() + "мс";
                textSorted.text = CheckForSorted(carr) ? "Да" : "Нет";
            }
        }
    }

}
