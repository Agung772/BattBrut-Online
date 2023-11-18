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
            HP = maxHP;


        }
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
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (photonView.IsMine)
            {
                int kill = Random.Range(0, 100);
                try
                {

                    ExitGames.Client.Photon.Hashtable playerCustomProperties = PhotonNetwork.LocalPlayer.CustomProperties;

                    // Mengatur variabel khusus pemain lokal
                    playerCustomProperties["kill"] = kill;

                    // Memperbarui custom properties pemain lokal
                    PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperties);
                }
                catch
                {
                    PhotonNetwork.LocalPlayer.CustomProperties["kill"] = kill;
                }
            }


        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            if (photonView.IsMine)
            {
                int kill = Random.Range(0, 100);
                try
                {
                    ExitGames.Client.Photon.Hashtable roomCustomProperties = PhotonNetwork.CurrentRoom.CustomProperties;

                    roomCustomProperties["kill"] = kill;
                    PhotonNetwork.CurrentRoom.SetCustomProperties(roomCustomProperties);

                }
                catch
                {
                    PhotonNetwork.CurrentRoom.CustomProperties["kill"] = kill;
                }
            }
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
    public void HitPlayer(float damage)
    {
        if (photonView.IsMine)
        {
            HP -= damage;
            Gameplay_UI.instance.barHP.fillAmount = HP / maxHP;
            barHP.transform.localScale = new Vector3(HP / maxHP, 1, 1);
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
