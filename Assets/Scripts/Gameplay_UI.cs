using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay_UI : MonoBehaviour
{
    public static Gameplay_UI instance;

    public Image barHP;

    public EventButton shootButton;

    private void Awake()
    {
        instance = this;
    }
}
