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

    public PhotonView ownPhotonView;

    public PlayerStat playerStat;
    Rigidbody rb;

    public bool Coll;
    public bool Trig;

    public AudioClip sfxProjectile;
    public bool playOnAwakeSFX;

    bool use;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, destroy);

        if (playOnAwakeSFX) AudioManager.instance.SetSFX(sfxProjectile);
    }

    public void SetPhotonViewPlayer(PhotonView temp)
    {
        if (photonView.IsMine)
        {
            ownPhotonView = temp;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerStat>() && !use && activeDamage)
        {
            Coll = true;
            use = true;
            var playerStat = collision.collider.GetComponent<PlayerStat>();
            //collision.collider.GetComponent<PhotonView>().RPC("HitPlayer", RpcTarget.All, ownPhotonView, damage);
            if (!playOnAwakeSFX) AudioManager.instance.SetSFX(sfxProjectile);
            playerStat.HitPlayer(ownPhotonView, damage);
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
            //other.GetComponent<PhotonView>().RPC("HitPlayer", RpcTarget.All, ownPhotonView, damage);
            //playerStat.HitPlayer(playerStat, damage);
            if (!playOnAwakeSFX) AudioManager.instance.SetSFX(sfxProjectile);
            playerStat.HitPlayer(ownPhotonView, damage);
            if (destroyPlayer) Destroy(gameObject, destroyTimeColl);
        }
    }

    void EnterColl()
    {

    }

}
