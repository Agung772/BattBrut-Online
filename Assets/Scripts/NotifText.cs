using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotifText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void Set(string value)
    {
        text.text = value;
    }
}
