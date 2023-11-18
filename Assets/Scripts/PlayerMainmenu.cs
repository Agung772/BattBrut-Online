using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainmenu : MonoBehaviour
{
    public int danceIndex;

    public Animator animator;

    private void Start()
    {
        animator.SetTrigger(Tags.Dance + danceIndex);
    }
}
