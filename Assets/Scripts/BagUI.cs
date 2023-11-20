using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public static BagUI instance;
    public int indexItem;

    public DataProjectile[] dataProjectiles = new DataProjectile[2];
    public Image[] cdUI = new Image[2];
    public Image[] setItemUI = new Image[2];

    [HideInInspector]
    public PlayerShoot playerShoot;
    [HideInInspector]
    public Image cooldownUI;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (dataProjectiles[0] != null)
            {
                indexItem = 0;
                playerShoot.SetProjectile(dataProjectiles[0], cdUI[0]);
            }
            setItemUI[0].gameObject.SetActive(true);
            setItemUI[1].gameObject.SetActive(false);

            cdUI[1].fillAmount = 0;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (dataProjectiles[1] != null)
            {
                indexItem = 1;
                playerShoot.SetProjectile(dataProjectiles[1], cdUI[1]);
            }
            setItemUI[0].gameObject.SetActive(false);
            setItemUI[1].gameObject.SetActive(true);

            cdUI[0].fillAmount = 0;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (dataProjectiles[2] != null)
            {
                indexItem = 2;
                playerShoot.SetProjectile(dataProjectiles[2], cdUI[2]);
            }
            setItemUI[0].gameObject.SetActive(false);
            setItemUI[1].gameObject.SetActive(true);

            cdUI[0].fillAmount = 0;
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (dataProjectiles[3] != null)
            {
                indexItem = 3;
                playerShoot.SetProjectile(dataProjectiles[3], cdUI[3]);
            }
            setItemUI[0].gameObject.SetActive(false);
            setItemUI[1].gameObject.SetActive(true);

            cdUI[0].fillAmount = 0;
        }
    }

    public void SetItem(DataProjectile data)
    {
        dataProjectiles[indexItem] = data;
    }
}
