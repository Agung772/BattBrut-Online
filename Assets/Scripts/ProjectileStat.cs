using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStat : MonoBehaviour
{
    public float damage;
    public float speed;
    public float destroy;
    public bool destroyCollision;
    public bool destroyPlayer;

    public bool isKinematic;
    public bool isKinematicCollision;

    [Header("Efect")]
    public ParticleSystem efectSentuhan;
    public ParticleSystem projectile;
    public ParticleSystem efectSpawn;

    new Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.isKinematic = isKinematic;

        if (efectSpawn != null) efectSpawn.Play();

        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, destroy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerStat>())
        {
            var playerStat = collision.collider.GetComponent<PlayerStat>();
            playerStat.HitPlayer(damage);
            if (destroyPlayer) Destroy(gameObject);
        }

        EnterColl();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStat>())
        {
            var playerStat = other.GetComponent<PlayerStat>();
            playerStat.HitPlayer(damage);
            if (destroyPlayer) Destroy(gameObject);
        }

        EnterColl();
    }

    void EnterColl()
    {
        if (efectSentuhan != null) efectSentuhan.Play();
        if (projectile != null) projectile.Stop();

        rigidbody.isKinematic = isKinematicCollision;

        if (destroyCollision)
        {
            Destroy(gameObject, 2f);

        }
    }

}
