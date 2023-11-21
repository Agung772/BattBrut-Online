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

    public Transform[] children;

    public Transform content;
    public GameObject textLeaderboartPrefab;

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
                Destroy(content.GetChild(i).gameObject);
            }
        }

        killPlayers = new int[PhotonNetwork.PlayerList.Length];

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            GameObject temp = Instantiate(textLeaderboartPrefab, content.position, content.rotation);

            temp.transform.SetParent(content);
            temp.transform.localScale = Vector3.one;

            TextLeaderboard textLeaderboard = temp.GetComponent<TextLeaderboard>();
            textLeaderboard.Set(PhotonNetwork.PlayerList[i].NickName, (int)PhotonNetwork.PlayerList[i].CustomProperties[Tags.Kill]);

            killPlayers[i] = (int)PhotonNetwork.PlayerList[i].CustomProperties[Tags.Kill];
        }

        StartCoroutine(Delayed());
        IEnumerator Delayed()
        {
            yield return new WaitForSeconds(0.01f);
            children = new Transform[content.childCount];
            for (int h = 0; h < children.Length; h++)
            {
                children[h] = content.GetChild(h).transform;
            }
            //children = content.Cast<Transform>().ToArray();

            Array.Sort(killPlayers, (a, b) => b.CompareTo(a));

            for (int i = 0; i < children.Length; i++)
            {
                for (int j = 0; j < children.Length; j++)
                {
                    int kill = children[j].GetComponent<TextLeaderboard>().killPlayer;

                    if (killPlayers[i] == kill) //kill[j]
                    {
                        children[j].SetAsLastSibling();
                    }
                }
            }
        }



    }
}
