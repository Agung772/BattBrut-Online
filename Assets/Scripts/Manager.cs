using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
}
