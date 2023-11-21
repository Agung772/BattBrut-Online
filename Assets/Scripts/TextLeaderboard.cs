using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLeaderboard : MonoBehaviour
{
    public int killPlayer;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI killText;

    public void Set(string name, int kill)
    {
        nameText.text = name;
        killPlayer = kill;
        killText.text = "Kill " + kill;
    }
}
