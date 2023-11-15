using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEfect : MonoBehaviour
{
    public bool destroyCollision;
    public bool isKinematicCollision;
    [Header("Efect")]
    public ParticleSystem efectSentuhan;
    public ParticleSystem projectile;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnterColl();
    }
    private void OnTriggerEnter(Collider other)
    {
        EnterColl();
    }
    void EnterColl()
    {
        if (efectSentuhan != null) efectSentuhan.Play();
        if (projectile != null) projectile.Stop();

        rb.isKinematic = isKinematicCollision;

        if (destroyCollision)
        {
            Destroy(gameObject, 2f);

        }
    }
}
