using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class UIMainmenu : MonoBehaviourPun
{
    public static UIMainmenu instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetPlayerModel(string nameModel)
    {


        if (nameModel == Tags.BadBoy || nameModel == Tags.PinkyBoy || nameModel == Tags.TheAkik)
        {
            try
            {
                ExitGames.Client.Photon.Hashtable playerCustomProperties = PhotonNetwork.LocalPlayer.CustomProperties;

                playerCustomProperties[Tags.PlayerModel] = nameModel;
                PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperties);

            }
            catch
            {
                PhotonNetwork.LocalPlayer.CustomProperties[Tags.PlayerModel] = nameModel;
            }
        }
        else
        {
            Debug.LogError("Ada yang typo di input player model");
        }
    }
}
