using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStat : MonoBehaviour
{
    public float damage;
    public float speed;

    public bool isKinematic;

    [Header("Efect")]
    public ParticleSystem efectSentuhan;
    public ParticleSystem projectile;
    public ParticleSystem efectSpawn;

    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.isKinematic = isKinematic;

        if (efectSpawn != null) efectSpawn.Play();

        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3);
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
        Destroy(gameObject, 2f);

        rigidbody.isKinematic = true;
    }
}
