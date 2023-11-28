using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerModels : MonoBehaviourPun
{
    public PlayerModel badBoy;
    public PlayerModel pinkyBoy;
    public PlayerModel theAkik;

    private void Start()
    {

    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyUp(KeyCode.Alpha9))
            {
                Set(Tags.TheAkik);
            }

        }
    }

    void Set(string nameModel)
    {
        Animator animator = GetComponentInParent<Animator>();

        badBoy.model3D.SetActive(false);
        pinkyBoy.model3D.SetActive(false);
        theAkik.model3D.SetActive(false);

        if (nameModel == Tags.BadBoy)
        {
            badBoy.model3D.SetActive(true);

            animator.runtimeAnimatorController = badBoy.animatorController;
            animator.avatar = badBoy.avatar;
        }
        else if (nameModel == Tags.PinkyBoy)
        {
            pinkyBoy.model3D.SetActive(true);

            animator.runtimeAnimatorController = pinkyBoy.animatorController;
            animator.avatar = pinkyBoy.avatar;
        }
        else if (nameModel == Tags.TheAkik)
        {
            theAkik.model3D.SetActive(true);

            animator.runtimeAnimatorController = theAkik.animatorController;
            animator.avatar = theAkik.avatar;
        }
    }

}

[System.Serializable]

public class PlayerModel
{
    public GameObject model3D;
    public AnimatorController animatorController;
    public Avatar avatar;
}
