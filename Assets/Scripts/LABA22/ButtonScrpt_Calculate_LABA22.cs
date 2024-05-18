using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScrpt_Calculate_LABA22 : MonoBehaviour
{
    [SerializeField] 
    protected GameObject content;

    [SerializeField] 
    protected TMP_InputField ArraySize;

    [SerializeField] 
    protected TMP_InputField OpPercent;

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
        if (!ArraySize) 
            return -1;

        if (int.TryParse(ArraySize.text, out int size))
        {
            return size;
        }

        return -1;
    }

    protected virtual void PerformArrayCreating()
    {
        if (GetSizeOfArrayFromInputfield() != -1)
            size = GetSizeOfArrayFromInputfield();

        arr = new int[size];

        UnityEngine.Random.InitState(DateTime.UtcNow.Minute);

        for (long i = 0; i < size; i++)
        {
            arr[i] = UnityEngine.Random.Range(0, size);
        }
    }

    public virtual void Perform()
    {
        if (GetSizeOfArrayFromInputfield() != arr.Length)
            PerformArrayCreating();

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
                var script = TableElement.GetComponent<SortScript_LABA22>(); 

                if (!script) continue;

                // создание копии массива
                int[] carr = new int[arr.Length];
                Array.Copy(arr, carr, arr.Length);

                var res = script.Sort(carr); // выполняем алгоритм на копии

                textComparisons.text = res.comparisons.ToString();
                textSwaps.text  = res.swaps.ToString();
                textTime.text   = res.time.ToString() + "мс";
                textSorted.text = CheckForSorted(carr) ? "Да" : "Нет";
            }
        }
    }

}
