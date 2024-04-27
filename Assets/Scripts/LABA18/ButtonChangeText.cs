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
    }

    public void SetIndex(int i)
    {
        if (i < 0 || i > ManagerLab18._MaxSize) 
            return;
        
        _ElementIndex = i;
    }
}
