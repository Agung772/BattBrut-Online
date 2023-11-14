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
    void Start()
    {
        if (PhotonNetwork.IsConnected == false)
        {
            SceneManager.LoadScene("LobbyScene");
            return;
        }
        PlayerControllerNetwork.RefreshInstance(ref localPlayerNetwork,
        playerNetworkPrefab);
    }
    // Update is called once per frame
    void Update()
    {
    }
}