using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : MonoBehaviour
{
    public static BagUI instance;
    public int index;

    public DataProjectile[] dataProjectiles = new DataProjectile[2];
    public Image[] cdUI = new Image[2];

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
                playerShoot.SetProjectile(dataProjectiles[0], cdUI[0]);
            }

        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (dataProjectiles[1] != null)
            {
                playerShoot.SetProjectile(dataProjectiles[1], cdUI[1]);
            }
        }
    }


}
