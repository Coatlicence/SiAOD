using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ArrayListUpdate : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject tree;


    int[] _Arr = ManagerLab18._Arr;

    public void UpdateList()
    {
        for (int i = 0; i < content.transform.childCount; i++) 
        {
            var text = content.transform.GetChild(i).GetComponentInChildren<TMP_Text>();

            var elementIndex = content.transform.GetChild(i).GetComponent<ButtonChangeText>();

            text.text = ManagerLab18._Arr[i].ToString();

            elementIndex.SetIndex(i);
        }

        for (int i = 0; i < tree.transform.childCount; i++)
            for (int j = 0; j < tree.transform.GetChild(i).childCount; j++)
            {
                var el = tree.transform.GetChild(i).GetChild(j).GetComponent<ButtonChangeText>();
                el.UpdateText();

            }
    }
}
