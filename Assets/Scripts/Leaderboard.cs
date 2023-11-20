using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using System;

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
        if (content.childCount != 0)
        {
            for (int i = 0; i < content.childCount; i++)
            {
                PhotonNetwork.Destroy(content.GetChild(i).gameObject);
            }
        }

        killPlayers = new int[PhotonNetwork.PlayerList.Length];

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            GameObject temp = PhotonNetwork.Instantiate(Tags.TextLeaderboard, content.position, content.rotation);

            temp.transform.SetParent(content);
            temp.transform.localScale = Vector3.one;

            TextLeaderboard textLeaderboard = temp.GetComponent<TextLeaderboard>();
            textLeaderboard.nameText.text = PhotonNetwork.PlayerList[i].NickName;
            textLeaderboard.killText.text = "Kill " + PhotonNetwork.PlayerList[i].CustomProperties[Tags.Kill];
            killPlayers[i] = (int)PhotonNetwork.PlayerList[i].CustomProperties[Tags.Kill];
        }

        Transform[] children = content.Cast<Transform>().ToArray();

        Array.Sort(killPlayers, (a, b) => b.CompareTo(a));

        for (int i = 0; i < children.Length; i++)
        {
            for (int j = 0; j < children.Length; j++)
            {
                int kill = 0;
                int.TryParse(children[j].GetComponent<TextLeaderboard>().killText.text, out kill);
                if (killPlayers[i] == kill)
                {
                    children[j].SetAsFirstSibling();
                }
            }
        }

    }
}
