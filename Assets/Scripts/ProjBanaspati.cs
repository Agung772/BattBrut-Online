using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjBanaspati : MonoBehaviour
{
    Transform target;
    public float speed = 5;
    private void Start()
    {
        FindTarget();
    }
    private void Update()
    {
        if (target != null)
        {
            speed += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector3 directionToTarget = target.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(directionToTarget);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }
    }

    void FindTarget()
    {
        PlayerControllerNetwork[] playerControllerNetworks = FindObjectsOfType<PlayerControllerNetwork>();
        if (playerControllerNetworks.Length == 1) return;
        RandomTarget();
        void RandomTarget()
        {
            int random = Random.Range(0, playerControllerNetworks.Length);
            if (!playerControllerNetworks[random].GetComponent<PhotonView>().IsMine)
            {
                target = playerControllerNetworks[random].transform;
            }
            else
            {
                RandomTarget();
            }
        }

    }
}
