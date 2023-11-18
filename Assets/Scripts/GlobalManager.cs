using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GlobalManager : MonoBehaviourPunCallbacks
{
    public static GlobalManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer == PhotonNetwork.LocalPlayer)
        {
            // Ini adalah perubahan pada properti pemain lokal

        }
        Leaderboard.instance.SetLeaderboard();
        UIManager.instance.SetNotifText("Ada perubahan variabel player OnPlayerPropertiesUpdate");
    }
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        UIManager.instance.SetNotifText("Ada perubahan variabel room");
    }

    public void SetVariabelRoom(string name, string variabel, float value)
    {
        try
        {
            ExitGames.Client.Photon.Hashtable roomCustomProperties = PhotonNetwork.CurrentRoom.CustomProperties;

            roomCustomProperties[name + variabel] = value;
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomCustomProperties);
        }
        catch
        {
            PhotonNetwork.CurrentRoom.CustomProperties[name + variabel] = value;
        }

    }
}
