using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainmenu : MonoBehaviour
{
    public string nameModel;

    public int danceIndex;

    public Animator animator;

    bool use;
    private void Start()
    {
        animator.SetTrigger(Tags.Dance + danceIndex);
    }

    private void OnMouseEnter()
    {

    }
    private void OnMouseExit()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
}
