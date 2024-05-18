using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLab18 : MonoBehaviour
{
    public static readonly int _MaxSize = 15;

    public static readonly int[] _Arr = new int[_MaxSize];

    [SerializeField] private GameObject Array;
    [SerializeField] private GameObject Tree;

    public void CreateArray()
    {
        for (int i = 0; i < _MaxSize; i++) 
        {
            _Arr[i] = Random.Range(10, 99);

            var el = Array.transform.GetChild(i).GetComponent<ButtonChangeText>();

            el.SetIndex(i);
        }

        Print();
    }

    private void Print()
    {
        int first_pos = _Arr.Length / 2;
        int col = first_pos;
        int row = 0;
        int elements_in_row = 1;
        for (int i = 0; i < _Arr.Length; i++)
        {
            if (_Arr[i] == 0)
            {
                var el = Tree.transform.GetChild(row).GetChild(col).GetComponent<ButtonChangeText>();
                el.SetIndex(-1);
                el.UpdateText();
            }
            else {
                var el = Tree.transform.GetChild(row).GetChild(col).GetComponent<ButtonChangeText>();
                el.SetIndex(col);
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
        for (int i = 0; i < _Arr.Length; i++)
        {
            _Arr[i] = 0;
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


}
