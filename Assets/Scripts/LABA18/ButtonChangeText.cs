using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonChangeText : MonoBehaviour
{
    [SerializeField] Changer _ButtonChangePrior;
    [SerializeField] private int _ElementIndex;

    public void Change()
    {
        _ButtonChangePrior.UpdateTextFromText(_ElementIndex);
        _ButtonChangePrior.text = this;
    }

    public void SetIndex(int i)
    {
        if (i < 0 || i > ManagerLab18._MaxSize) 
            return;
        
        _ElementIndex = i;

        UpdateText();

        //Change();
    }

    public void UpdateText()
    {
        if (_ElementIndex < 0) return;

        var text = transform.GetComponentInChildren<TMP_Text>();

        var val = ManagerLab18._Arr[_ElementIndex].ToString();

        if (val == "0") val = "";

        text.text = val;
    }


}
