using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ButtonScripts : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextSquare;
    [SerializeField] TextMeshProUGUI TextVolume;

    [SerializeField] TMP_InputField Length;
    [SerializeField] TMP_InputField Width;
    [SerializeField] TMP_InputField Height;

    public bool CheckoutFields()
    {

        if (int.Parse(Length.text) < 1)
            return false;

        if (int.Parse(Width.text) < 1)
            return false;

        if (int.Parse(Height.text) < 1)
            return false;

        return true;
    }

    public void CalculateSquare()
    {
        if (!CheckoutFields())
        {
            TextSquare.text = "Error";
        };

        float length = float.Parse(Length.text);
        float width = float.Parse(Width.text);
        float height = float.Parse(Height.text);

        float square = 2 * (length * width + length * height + width * height);

        TextSquare.text = "ֿכמשאהü: " + square.ToString();
    }

    public void CalculateVolume()
    {
        if (!CheckoutFields())
        {
            TextVolume.text = "Error";
        };

        float length = float.Parse(Length.text);
        float width = float.Parse(Width.text);
        float height = float.Parse(Height.text);

        float volume = length * width * height;

        TextVolume.text = "־בüול: " + volume.ToString();
    }

}
