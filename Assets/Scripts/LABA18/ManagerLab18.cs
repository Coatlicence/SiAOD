using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLab18 : MonoBehaviour
{
    public static readonly int _MaxSize = 15;

    public static readonly int[] _Arr = new int[_MaxSize];

    [SerializeField] private GameObject Array;

    [SerializeField] private GameObject Tree;

    struct TreeElement
    {
        ButtonChangeText left;
        ButtonChangeText right;
    }

    TreeElement root = new TreeElement();

    public void CreateArray()
    {
        for (int i = 0; i < _MaxSize; i++) 
        {
            _Arr[i] = Random.Range(10, 99);

            var el = Array.transform.GetChild(i).GetComponent<ButtonChangeText>();

            el.SetIndex(i);
            el.Change();
        }

        Print();
    }

    private void Print()
    {

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
