using Photon.Pun;


using UnityEngine;


public class PlayerModels : MonoBehaviourPun
{
    public PlayerModel badBoy;
    public PlayerModel pinkyBoy;
    public PlayerModel theAkik;

    private void Start()
    {
        if (photonView.IsMine)
        {
            if (PhotonNetwork.LocalPlayer.CustomProperties[Tags.PlayerModel] == Tags.BadBoy)
            {
                Set(Tags.BadBoy);
            }
            else if (PhotonNetwork.LocalPlayer.CustomProperties[Tags.PlayerModel] == Tags.PinkyBoy)
            {
                Set(Tags.PinkyBoy);
            }
            else if (PhotonNetwork.LocalPlayer.CustomProperties[Tags.PlayerModel] == Tags.TheAkik)
            {
                Set(Tags.TheAkik);
            }
            else
            {
                Debug.LogWarning("Tidak ada data model!");
            }
        }
    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyUp(KeyCode.Alpha9))
            {
                Set(Tags.BadBoy);
            }
            if (Input.GetKeyUp(KeyCode.Alpha8))
            {
                Set(Tags.PinkyBoy);
            }
            if (Input.GetKeyUp(KeyCode.Alpha7))
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

            animator.runtimeAnimatorController = badBoy.animator.runtimeAnimatorController;
            animator.avatar = badBoy.animator.avatar;
            Destroy(badBoy.animator);
        }
        else if (nameModel == Tags.PinkyBoy)
        {
            pinkyBoy.model3D.SetActive(true);

            animator.runtimeAnimatorController = pinkyBoy.animator.runtimeAnimatorController;
            animator.avatar = pinkyBoy.animator.avatar;
            Destroy(pinkyBoy.animator);
        }
        else if (nameModel == Tags.TheAkik)
        {
            theAkik.model3D.SetActive(true);

            animator.runtimeAnimatorController = theAkik.animator.runtimeAnimatorController;
            animator.avatar = theAkik.animator.avatar;
            Destroy(theAkik.animator);
        }
    }

}

[System.Serializable]

public class PlayerModel
{
    public GameObject model3D;
    public Animator animator;
}
