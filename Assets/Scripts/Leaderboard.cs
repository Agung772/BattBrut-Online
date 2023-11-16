using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Leaderboard : MonoBehaviour
{
    public Transform content;
    private void Start()
    {
        //PhotonNetwork.Instantiate(Tags.TextLeaderboard, content.position, content.rotation);

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            GameObject temp = PhotonNetwork.Instantiate(Tags.TextLeaderboard, content.position, content.rotation);

            temp.transform.SetParent(content);
            temp.transform.localScale = Vector3.one;

            TextLeaderboard textLeaderboard = temp.GetComponent<TextLeaderboard>();
            textLeaderboard.nameText.text = PhotonNetwork.PlayerList[i].NickName;
        }

    }
}
