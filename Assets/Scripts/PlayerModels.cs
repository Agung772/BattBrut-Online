using Photon.Pun;
using UnityEngine;


public class PlayerModels : MonoBehaviourPun
{
    public static PlayerModels instance;

    public PlayerModel badBoy;
    public PlayerModel pinkyBoy;
    public PlayerModel theAkik;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }

    public void SetModelPlayer()
    {
        PhotonView photonView = transform.parent.GetComponent<PhotonView>();
        string tempPlayerModel = (string)photonView.Controller.CustomProperties[Tags.PlayerModel];
        if (tempPlayerModel == Tags.BadBoy)
        {
            Set(Tags.BadBoy);
        }
        else if (tempPlayerModel == Tags.PinkyBoy)
        {
            Set(Tags.PinkyBoy);
        }
        else if (tempPlayerModel == Tags.TheAkik)
        {
            Set(Tags.TheAkik);
        }
        else
        {
            Debug.LogWarning("Tidak ada data model!");
            Set(Tags.PinkyBoy);
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
            transform.parent.GetComponent<PlayerShoot>().pointShoot = badBoy.pointShoot;
            Destroy(badBoy.animator);
        }
        else if (nameModel == Tags.PinkyBoy)
        {
            pinkyBoy.model3D.SetActive(true);

            animator.runtimeAnimatorController = pinkyBoy.animator.runtimeAnimatorController;
            animator.avatar = pinkyBoy.animator.avatar;
            transform.parent.GetComponent<PlayerShoot>().pointShoot = pinkyBoy.pointShoot;
            Destroy(pinkyBoy.animator);
        }
        else if (nameModel == Tags.TheAkik)
        {
            theAkik.model3D.SetActive(true);

            animator.runtimeAnimatorController = theAkik.animator.runtimeAnimatorController;
            animator.avatar = theAkik.animator.avatar;
            transform.parent.GetComponent<PlayerShoot>().pointShoot = theAkik.pointShoot;
            Destroy(theAkik.animator);
        }
        else
        {
            pinkyBoy.model3D.SetActive(true);

            animator.runtimeAnimatorController = pinkyBoy.animator.runtimeAnimatorController;
            animator.avatar = pinkyBoy.animator.avatar;
            transform.parent.GetComponent<PlayerShoot>().pointShoot = pinkyBoy.pointShoot;
            Destroy(pinkyBoy.animator);
        }
    }

}

[System.Serializable]

public class PlayerModel
{
    public GameObject model3D;
    public Animator animator;
    public Transform pointShoot;
}
