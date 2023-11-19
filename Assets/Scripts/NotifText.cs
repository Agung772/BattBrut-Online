using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotifText : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        Destroy(gameObject, 2);
    }
    public void Set(string value)
    {
        text.text = value;
    }
}
