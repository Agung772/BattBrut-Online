using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Leaderboard : MonoBehaviour
{
    public static Leaderboard instance;

    public int[] killPlayers;

    public Transform content;
    private void Awake()
    {
        instance = this;
    }

    public void SetLeaderboard()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            GameObject temp = PhotonNetwork.Instantiate(Tags.TextLeaderboard, content.position, content.rotation);

            temp.transform.SetParent(content);
            temp.transform.localScale = Vector3.one;

            TextLeaderboard textLeaderboard = temp.GetComponent<TextLeaderboard>();
            textLeaderboard.nameText.text = PhotonNetwork.PlayerList[i].NickName;
            textLeaderboard.killText.text = "Kill " + PhotonNetwork.PlayerList[i].CustomProperties[Tags.Kill];
        }


    }
}
