using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerShoot : MonoBehaviourPun
{
    [SerializeField] float speedShoot;
    public GameObject projectilePrefab;
    GameObject projectileNetwork;
    [SerializeField] Transform pointShoot;

    EventButton shootButton;
    PlayerControllerNetwork playerControllerNetwork;

    private void Start()
    {
        playerControllerNetwork = GetComponent<PlayerControllerNetwork>();
        shootButton = Gameplay_UI.instance.shootButton;
    }
    private void Update()
    {
        if (playerControllerNetwork.isControlled)
        {
            //PlayerShoot
            if (Input.GetKey(KeyCode.E) || shootButton.pressed)
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate("PMG", pointShoot.transform.position, pointShoot.transform.rotation);
        }
        else
        {
            Instantiate(Resources.Load("PMG"), pointShoot.transform.position, pointShoot.transform.rotation);
        }

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
