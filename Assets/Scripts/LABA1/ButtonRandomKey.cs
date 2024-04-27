using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonRandomKey : MonoBehaviour
{
    [SerializeField] private TMP_InputField FieldWithKey;

    public void Randomize()
    {
        long num = ManagerScript.LongRandom(0, ManagerScript.SizeOfArray*10, new System.Random());

        FieldWithKey.text = num.ToString();
    }
}
