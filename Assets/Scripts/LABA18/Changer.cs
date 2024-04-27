using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Changer : MonoBehaviour
{
    public TMP_Text _From;
    public TMP_InputField _To;

    int _Index;

    public void Change()
    {
        if (_Index == -1) return;

        if (int.TryParse(_To.text, out int num))
        {
            ManagerLab18.Set(_Index, num);

            UpdateTextFromText(_Index);

        }
    }

    public void UpdateTextFromText(int i)
    {
        if (i > ManagerLab18._MaxSize)
            throw new System.Exception();

        _Index = i;

        _From.text = ManagerLab18._Arr[_Index].ToString();
    }
}
