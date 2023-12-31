﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerStat : MonoBehaviourPunCallbacks
{
    public float maxHP;
    public float HP;
    public string name;

    public int kill;

    [Header("UI")]
    public RectTransform canvas;
    public Image barHP;
    public TextMeshProUGUI nameText;

    PlayerControllerNetwork player;
    private void Start()
    {
        if (photonView.IsMine)
        {
            player = GetComponent<PlayerControllerNetwork>();


            KillingPlayer();
        }
        HP = maxHP;
        SetName();
    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            SetBarUI();

            if (Input.GetKeyUp(KeyCode.K))
            {
                kill++;
                KillingPlayer();
            }
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

    void SetName()
    {
        PhotonView photonView = GetComponent<PhotonView>();
        nameText.text = photonView.Controller.NickName;
    }

    public void HitPlayer(PhotonView ownPhotonView,float damage)
    {
        if (photonView.IsMine && HP > 0)
        {
            Debug.Log("Darah saat ini : " + HP);
            HP -= damage;
            Gameplay_UI.instance.barHP.fillAmount = HP / maxHP;
            barHP.transform.localScale = new Vector3(HP / maxHP, 1, 1);


            if (HP <= 0 && player.canMove)
            {
                StartCoroutine(Delayed());
                IEnumerator Delayed()
                {
                    player.canMove = false;

                    //ownPhotonView.GetComponent<PlayerStat>().kill++;
                    //ownPhotonView.Controller.CustomProperties[Tags.Kill] = ownPhotonView.GetComponent<PlayerStat>().kill;

                    KillingPlayer();
                    Gameplay_UI.instance.SetDeathUI(true);
                    yield return new WaitForSeconds(2);

                    HP = 100;
                    Gameplay_UI.instance.barHP.fillAmount = HP / maxHP;
                    barHP.transform.localScale = new Vector3(HP / maxHP, 1, 1);
                    player.RespawnPlayer();
                    yield return new WaitForSeconds(1);
                    Gameplay_UI.instance.SetDeathUI(false);
                    yield return new WaitForSeconds(1);

                    player.canMove = true;


                }
            }
        }
    }

    public void KillingPlayer()
    {
        try
        {
            ExitGames.Client.Photon.Hashtable playerCustomProperties = PhotonNetwork.LocalPlayer.CustomProperties;

            playerCustomProperties[Tags.Kill] = kill;
            PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperties);

        }
        catch
        {
            PhotonNetwork.LocalPlayer.CustomProperties[Tags.Kill] = kill;
        }
    }

    void SetBarUI()
    {
        if (player.horizontal > 0)
        {
            canvas.localRotation = Quaternion.Euler(0, -90, 0);
        }
        else if (player.horizontal < 0)
        {
            canvas.localRotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
