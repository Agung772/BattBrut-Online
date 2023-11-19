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



    public PlayerStat playerStat;
    Rigidbody rb;

    bool use;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, destroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerStat>() && !use && activeDamage)
        {
            use = true;
            var playerStat = collision.collider.GetComponent<PlayerStat>();
            playerStat.HitPlayer(playerStat, damage);
            if (destroyPlayer) Destroy(gameObject, destroyTimeColl);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStat>() && !use && activeDamage)
        {
            use = true;
            var playerStat = other.GetComponent<PlayerStat>();
            playerStat.HitPlayer(playerStat, damage);
            if (destroyPlayer) Destroy(gameObject, destroyTimeColl);
        }
    }

    void EnterColl()
    {

    }

}
