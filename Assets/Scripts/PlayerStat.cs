using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerStat : MonoBehaviourPun
{
    public float maxHP;
    public float HP;

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

    }

    public void HitPlayer(float damage)
    {
        if (photonView.IsMine)
        {
            HP -= damage;
            Gameplay_UI.instance.barHP.fillAmount = HP / maxHP;
        }
    }

}
