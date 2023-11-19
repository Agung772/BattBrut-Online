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

        StartCoroutine(Delayed());
        IEnumerator Delayed()
        {
            yield return new WaitForSeconds(0.1f);

        }
    }
}
