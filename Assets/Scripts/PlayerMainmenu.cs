using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainmenu : MonoBehaviour
{
    [System.Serializable]
    public enum NameModel
    {
        BadBoy,
        PinkyBoy,
        TheAkik
    }

    public NameModel nameModel;

    public int danceIndex;

    public Animator animator;

    bool use;
    private void Start()
    {

    }

    private void OnMouseEnter()
    {
        if (use) return;
        animator.SetFloat(Tags.AnimasiMove, 1);
    }
    private void OnMouseExit()
    {
        if (use) return;
        animator.SetFloat(Tags.AnimasiMove, 0);
    }

    private void OnMouseDown()
    {
        PlayerMainmenu[] players = FindObjectsOfType<PlayerMainmenu>();
        for (int i = 0; i < players.Length; i++)
        {
            players[i].use = true;
            use = true;
        }
        if (nameModel == NameModel.BadBoy) UIMainmenu.instance.SetPlayerModel(Tags.BadBoy);
        else if (nameModel == NameModel.PinkyBoy) UIMainmenu.instance.SetPlayerModel(Tags.PinkyBoy);
        else if (nameModel == NameModel.TheAkik) UIMainmenu.instance.SetPlayerModel(Tags.TheAkik);

    }
}
