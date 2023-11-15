using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public int tester;
    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
}
