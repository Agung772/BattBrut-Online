using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay_UI : MonoBehaviour
{
    public static Gameplay_UI instance;

    public Image barHP;

    public EventButton shootButton;
    public EventButton jumpButton;

    public GameObject deathUI;

    private void Awake()
    {
        instance = this;
    }

    public void SetDeathUI(bool value)
    {
        if (value)
        {
            deathUI.SetActive(true);
            deathUI.GetComponent<Animator>().Play("Start");
        }
        else
        {
            deathUI.SetActive(false);
            deathUI.GetComponent<Animator>().Play("Exit");
        }
    }
}
