
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ManagerLab18 : MonoBehaviour
{
    public static readonly int _MaxSize = 15;

    public static int[] _Arr = new int[_MaxSize];
    public static int[] _Rezults = new int[_MaxSize];
    private static int sizeArray = 0;
    private static int sizeRezults = 0;

    [SerializeField] private GameObject Array;
    [SerializeField] private GameObject Tree;
    [SerializeField] private GameObject Rezults;
    [SerializeField] private TMP_InputField In;

    public void CreateArray()
    {
        Clear();
        sizeArray = 0;
        for (int i = 0; i < _MaxSize; i++) 
        {
            _Arr[i] = Random.Range(10, 99);
            Up(i);
            sizeArray++;
        }
        for (int i = 0; i < _MaxSize; i++)
        {
            var el = Array.transform.GetChild(i).GetComponent<ButtonChangeText>();

            el.SetIndex(i);
        }

            Print();
    }
    private void Add(int pos,int val)
    {
        _Arr[pos] = val;
        sizeArray++;
        Up(pos);
    }
    private void Print()
    {
        int first_pos = _Arr.Length / 2;
        int col = first_pos;
        int row = 0;
        int elements_in_row = 1;
        for (int i = 0; i < sizeArray; i++)
        {
            if (_Arr[i] == 0)
            {
                var el = Tree.transform.GetChild(row).GetChild(col).GetComponent<ButtonChangeText>();
                el.SetIndex(-1);
                el.UpdateText();
            }
            else {
                var el = Tree.transform.GetChild(row).GetChild(col).GetComponent<ButtonChangeText>();
                el.SetIndex(i);
                el.UpdateText();
            }
            int step = first_pos * 2;
            if (col != first_pos) col += step;
            else col = first_pos;
            elements_in_row--;
            if (elements_in_row == 0)
            {
                row++;
                first_pos = _Arr.Length / (int)System.Math.Pow(2, row + 1) + 1;
                col = first_pos - 1;
                elements_in_row = (int)System.Math.Pow(2, row);
            }
        }

    }

    public void Clear()
    {
        sizeRezults = 0;
        sizeArray = 0;
        for (int i = 0; i < _Arr.Length; i++)
        {
            _Arr[i] = 0;
        }
        for (int i = 0; i < _Rezults.Length; i++)
        {
            _Rezults[i] = 0;
        }
    }

    public void AddToArray(int value)
    {
        if (_Arr.Length == _MaxSize) return;

        _Arr[_Arr.Length] = value;
    }

    public static void Set(int i, int val)
    {
        _Arr[i] = val;
    }

    public static void Up(int indexOfElement)
    {
        int i = indexOfElement;
        while (_Arr[i] > _Arr[(i - 1) / 2])
        {
            int tmp = _Arr[(i - 1) / 2];
            _Arr[(i - 1) / 2] = _Arr[i];
            _Arr[i] = tmp;
            i = (i - 1) / 2;
        }
    }
    public void ExtractMax()
    {

        if (sizeArray == 0)
        {
            Debug.Log("Масиив пуст");
            return;
        }
        if (sizeRezults == _MaxSize)
        {
            Debug.Log("Массив-результат полон");
            return;
        }
        _Rezults[sizeRezults++] = _Arr[0];
        Delete(0);
        Print();
    }
    int Delete(int i)
    {
        _Arr[i] = _Arr[sizeArray - 1];
        _Arr[sizeArray - 1] = 0;
        Down(i);
        sizeArray--;
        return i;
    }
    public static void Down(int index)
    {
        while (2 * index + 1 <= _MaxSize)
        {

            int j = 2 * index + 1;
            if (j < _MaxSize && _Arr[j] < _Arr[j + 1]) j++;
            if ((_Arr[index] >= _Arr[j])) break;
            (_Arr[index], _Arr[j]) = (_Arr[j], _Arr[index]);
            index = j;
        }
    }
    public void PasteNew()
    {
        
        if (sizeArray == _MaxSize)
        {
            Debug.Log("Массив полон");
            return;
        }
        Add(sizeArray, int.Parse(In.text));
        Print();
    }
}
