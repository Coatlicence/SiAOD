using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ButtonScriptCalculateCourse : ButtonScrpt_Calculate
{
    LinkedList<int> Unsorted;
    LinkedList<int> Sorted;
    LinkedList<int> PartiallySorted;
    LinkedList<int> ReverseSorted;

    private void Start()
    {
        PerformArrayCreating();
    }

    protected override void PerformArrayCreating()
    {
        // Unsorted //
        Unsorted = new LinkedList<int>();

        for (int i = 0; i < size; i++)
        {
            Unsorted.AddLast(UnityEngine.Random.Range(0, size));
        }

        // Sorted //
        Sorted = new LinkedList<int>();

        Sorted.AddLast(0);
        for (long i = 1; i < size; i++)
        {
            Sorted.AddLast(Sorted.Last.Value + 2);
        }

        // PartiallySorted //
        PartiallySorted = new LinkedList<int>();

        PartiallySorted.AddLast(0);
        for (long i = 1; i < size / 2; i++)
        {
            PartiallySorted.AddLast(PartiallySorted.Last.Value + 1);
        }
        for (long i = size / 2; i < size; i++)
        {
            PartiallySorted.AddLast(UnityEngine.Random.Range(0, size));
        }


        // ReverseSorted //
        ReverseSorted = new LinkedList<int>();

        ReverseSorted.AddFirst(0);
        for (long i = 1; i < size; i++)
        {
            ReverseSorted.AddFirst(ReverseSorted.First.Value + 3);
        }
    }

    private LinkedList<int> DuplicateLL(LinkedList<int> list)
    {
        LinkedList<int> dup = new();

        var node = list.First;

        while (node != null)
        {
            dup.AddLast(node.Value);
            node = node.Next;
        }

        return dup;
    }

    public override void Perform()
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

            var type = TableElement.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text;
            

            // получаем скрипт, который назначен для элемента таблицы
            LL_Sort script = TableElement.GetComponent<LL_Sort>();

            if (!script) continue;

            LL_Sort.func_res res;

            switch (type)
            {
                case "Неупорядочен":
                    var UnsortedDup = DuplicateLL(Unsorted);
                    res = script.Sort(UnsortedDup); // выполняем алгоритм на копии
                    textSorted.text = CheckForSorted(UnsortedDup) ? "Да" : "Нет";
                    break;

                case "Упорядочен":
                    var SortedDup = DuplicateLL(Sorted);
                    res = script.Sort(SortedDup); // выполняем алгоритм на копии
                    textSorted.text = CheckForSorted(SortedDup) ? "Да" : "Нет";
                    break;

                case "Частично":
                    var PartiallySortedDup = DuplicateLL(PartiallySorted);
                    res = script.Sort(PartiallySortedDup); // выполняем алгоритм на копии
                    textSorted.text = CheckForSorted(PartiallySortedDup) ? "Да" : "Нет";
                    break;

                case "Уп. Обратное":
                    var ReverseSortedDup = DuplicateLL(ReverseSorted);
                    res = script.Sort(ReverseSortedDup); // выполняем алгоритм на копии
                    textSorted.text = CheckForSorted(ReverseSortedDup) ? "Да" : "Нет";
                    break;

                default:
                    throw new Exception("Didnt found type");
            }

            textComparisons.text = res.comparisons.ToString();
            textSwaps.text = res.swaps.ToString();
            textTime.text = res.time.ToString() + "мс";
        }
    }

    protected bool CheckForSorted(LinkedList<int> list)
    {
        var node = list.First;

        if (node == null) throw new Exception("list is empty");
        if (node.Next == null) throw new Exception("list.Next is empty");

        while (node != null)
        {
            if (node.Next == null) break;

            if (node.Value > node.Next.Value)
            {
                return false;
            }

            node = node.Next;
        }

        return true;
    }

    public void ButtonScript()
    {
        size = GetSizeOfArrayFromInputfield();
        PerformArrayCreating();
        Perform();
    }
}

