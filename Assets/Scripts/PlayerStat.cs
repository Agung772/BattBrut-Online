using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerStat : MonoBehaviourPun
{
    public float maxHP;
    public float HP;

    [Header("UI")]
    public Image barHP;
    private void Start()
    {
        HP = maxHP;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            HitPlayer(5);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (photonView.IsMine)
            {
                Manager.instance.tester++;
                Debug.Log("Game Manager");
            }

        }

    }

    public void HitPlayer(float damage)
    {
        if (photonView.IsMine)
        {
            HP -= damage;
            Gameplay_UI.instance.barHP.fillAmount = HP / maxHP;
            barHP.transform.localScale = new Vector3(HP / maxHP, 1, 1);
        }
    }

}
