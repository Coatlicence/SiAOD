using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ArrayListUpdate : MonoBehaviour
{
    [SerializeField] GameObject content;

    public void UpdateList()
    {
        for (int i = 0; i < content.transform.childCount; i++) 
        {
            var text = content.transform.GetChild(i).GetComponentInChildren<TMP_Text>();

            var elementIndex = content.transform.GetChild(i).GetComponent<ButtonChangeText>();

            text.text = ManagerLab18._Arr[i].ToString();

            elementIndex.SetIndex(i);

            if (text.text == "0") text.text = "";
        }
    }
}
