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
    public ButtonChangeText text;

    public void Change()
    {
        if (_Index == -1) return;

        if (int.TryParse(_To.text, out int num))
        {
            ManagerLab18.Set(_Index, num);
            ManagerLab18.Up(_Index);
            ManagerLab18.Down(_Index);

            UpdateTextFromText(_Index);

            text.UpdateText();
        }
    }

    public void UpdateTextFromText(int i)
    {
        if (i > ManagerLab18._MaxSize || i < 0)
            return;

        _Index = i;

        var val = ManagerLab18._Arr[_Index].ToString();

        if (val == "0") val = "";

        _From.text = val;
    }
}
