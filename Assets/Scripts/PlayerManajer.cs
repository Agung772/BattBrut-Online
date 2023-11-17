using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
public class PlayerManajer : MonoBehaviour
{
    public PlayerControllerNetwork playerNetworkPrefab;
    [HideInInspector]
    public PlayerControllerNetwork localPlayerNetwork;
    private void Awake()
    {
        if (PhotonNetwork.IsConnected == false)
        {
            SceneManager.LoadScene("LobbyScene");
            return;
        }
    }
    void Start()
    {
        PlayerControllerNetwork.RefreshInstance(ref localPlayerNetwork,
        playerNetworkPrefab);
    }
}