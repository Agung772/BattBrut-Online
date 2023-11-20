using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Transform panel;
    [SerializeField] Transform spawnNotif;
    [SerializeField] GameObject notifTextPrefab;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void SetNotifText(string value)
    {
        if (spawnNotif.childCount != 0) 
        {
            for (int i = 0; i < spawnNotif.childCount; i++)
            {
                Destroy(spawnNotif.GetChild(i).gameObject);
            }

        } 

        GameObject temp = Instantiate(notifTextPrefab, spawnNotif);
        temp.GetComponent<NotifText>().Set(value);
        Destroy(temp, 3);
    }
}
