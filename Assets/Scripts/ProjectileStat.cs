using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStat : MonoBehaviour
{
    public float damage;
    public float speed;
    public float destroy;
    public float efectTimeDelay;
    public bool destroyCollision;

    public bool isKinematic;
    public bool isKinematicCollision;

    [Header("Efect")]
    public ParticleSystem efectSentuhan;
    public ParticleSystem projectile;
    public ParticleSystem efectSpawn;
    public ParticleSystem efectDelay;

    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.isKinematic = isKinematic;

        if (efectSpawn != null) efectSpawn.Play();

        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, destroy);

        Invoke("EfectDelay", efectTimeDelay);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerStat>())
        {
            var playerStat = collision.collider.GetComponent<PlayerStat>();
            playerStat.HitPlayer(damage);
            Destroy(gameObject);
        }

        if (efectSentuhan != null) efectSentuhan.Play();
        if (projectile != null) projectile.Stop();

        rigidbody.isKinematic = isKinematicCollision;

        if (destroyCollision)
        {
            Destroy(gameObject, 2f);
   
        }
    }

    void EfectDelay()
    {
        if (efectDelay != null) efectDelay.Play();
        rigidbody.isKinematic = true;
    }
}
