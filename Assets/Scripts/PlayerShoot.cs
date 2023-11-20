using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class PlayerShoot : MonoBehaviourPun
{
    [SerializeField] float speedShoot;
    public DataProjectile dataProjectile;
    [SerializeField] Transform pointShoot;

    EventButton shootButton;
    PlayerControllerNetwork playerControllerNetwork;

    private void Start()
    {
        if (photonView.IsMine)
        {
            playerControllerNetwork = GetComponent<PlayerControllerNetwork>();
            shootButton = Gameplay_UI.instance.shootButton;
            BagUI.instance.playerShoot = this;
        }

    }
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.E) || shootButton.pressed)
            {
                //Shoot();
                //GetComponent<PhotonView>().RPC("Shoot", RpcTarget.All);

                Debug.LogError("Shoot nya si : " + photonView.Controller.NickName);

                if (dataProjectile != null)
                {
                    photonView.RPC("Shoot", RpcTarget.All);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            photonView.RPC("Tester", RpcTarget.All);
        }
        //PlayerShoot

    }
    [PunRPC]
    public void Tester()
    {
        Debug.LogError("Tester");
    }

    Image cooldownUI;
    bool cooldown;
    float cooldownTime;


    [PunRPC]
    public void Shoot()
    {
        if (dataProjectile != null)
        {
            if (cooldown) return;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                cooldown = true;

                GameObject projectile = PhotonNetwork.Instantiate(dataProjectile.projectilePrefab.name, pointShoot.transform.position, pointShoot.transform.rotation);
                //projectile.GetComponent<ProjectileStat>().playerStat = GetComponent<PlayerStat>();
                //projectile.GetComponent<PhotonView>().RPC("SetNamePlayer", RpcTarget.AllBuffered, PhotonNetwork.NickName);
                projectile.GetComponent<ProjectileStat>().SetNamePlayer(PhotonNetwork.NickName);
                yield return new WaitForSeconds(dataProjectile.cooldownTime);
                cooldown = false;
            }

            StartCoroutine(CoroutineUI());
            IEnumerator CoroutineUI()
            {
                cooldownTime = dataProjectile.cooldownTime;
                while (cooldownTime >= 0)
                {
                    cooldownTime -= Time.deltaTime;
                    cooldownUI.fillAmount = cooldownTime / dataProjectile.cooldownTime;
                    yield return null;
                }
            }
        }
        else
        {
            UIManager.instance.SetNotifText("Tidak ada Item!");
            Debug.LogError("Tidak diketahui " + photonView.IsMine, gameObject);
        }

    }

    public void SetProjectile(DataProjectile data, Image ui)
    {
        dataProjectile = data;
        cooldownUI = ui;


    }

    public static void RefreshInstance(ref PlayerControllerNetwork playerControllerNetwork,
    PlayerControllerNetwork prefab)
    {
        var position = Vector3.zero;
        var rotation = Quaternion.identity;
        if (playerControllerNetwork != null)
        {
            position = playerControllerNetwork.transform.position;
            rotation = playerControllerNetwork.transform.rotation;
            PhotonNetwork.Destroy(playerControllerNetwork.gameObject);
        }
        playerControllerNetwork = PhotonNetwork.Instantiate(prefab.gameObject.name, position,
        rotation).GetComponent<PlayerControllerNetwork>();
    }
}
