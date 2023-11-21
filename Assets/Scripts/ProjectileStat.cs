using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStat : MonoBehaviourPun
{
    public bool activeDamage;
    public float damage;
    public float speed;
    public float destroy;
    public float destroyTimeColl;

    public bool destroyPlayer;

    public string ownNamePlayer;

    public PlayerStat playerStat;
    Rigidbody rb;

    public bool Coll;
    public bool Trig;

    bool use;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, destroy);
    }

    [PunRPC]
    public void SetNamePlayer(string namePlayer)
    {
        if (photonView.IsMine)
        {
            ownNamePlayer = namePlayer;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerStat>() && !use && activeDamage)
        {
            Coll = true;
            use = true;
            var playerStat = collision.collider.GetComponent<PlayerStat>();
            collision.collider.GetComponent<PhotonView>().RPC("HitPlayer", RpcTarget.All, ownNamePlayer, damage);
            //playerStat.HitPlayer(playerStat, damage);
            if (destroyPlayer) Destroy(gameObject, destroyTimeColl);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStat>() && !use && activeDamage)
        {
            Trig = true;
            use = true;
            var playerStat = other.GetComponent<PlayerStat>();
            other.GetComponent<PhotonView>().RPC("HitPlayer", RpcTarget.All, ownNamePlayer, damage);
            //playerStat.HitPlayer(playerStat, damage);
            if (destroyPlayer) Destroy(gameObject, destroyTimeColl);
        }
    }

    void EnterColl()
    {

    }

}
