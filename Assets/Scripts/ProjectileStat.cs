using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStat : MonoBehaviour
{
    public bool activeDamage;
    public float damage;
    public float speed;
    public float destroy;

    public bool destroyPlayer;


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
            playerStat.HitPlayer(damage);
            if (destroyPlayer) Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStat>() && !use && activeDamage)
        {
            use = true;
            var playerStat = other.GetComponent<PlayerStat>();
            playerStat.HitPlayer(damage);
            if (destroyPlayer) Destroy(gameObject);
        }
    }


}
