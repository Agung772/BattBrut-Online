using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
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
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            HitPlayer(photonView.name, 5);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (photonView.IsMine)
            {
                Manager.instance.tester++;
                Debug.Log("Game Manager");
            }

        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            KillingPlayer();
        }
    }

    void SetName()
    {
        PhotonView photonView = GetComponent<PhotonView>();
        nameText.text = photonView.Controller.NickName;
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {

        }
    }
    [PunRPC]
    public void HitPlayer(string namePlayer,float damage)
    {
        if (photonView.IsMine && HP > 0)
        {
            Debug.Log("Darah saat ini : " + HP);
            HP -= damage;
            Gameplay_UI.instance.barHP.fillAmount = HP / maxHP;
            barHP.transform.localScale = new Vector3(HP / maxHP, 1, 1);
            name = namePlayer;

            if (HP <= 0)
            {

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
