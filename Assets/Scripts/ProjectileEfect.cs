using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEfect : MonoBehaviour
{
    public bool destroyCollision;
    public float destroyTimeCollision = 2;
    public bool isKinematicCollision;
    [Header("Efect")]
    public ParticleSystem efectSentuhan;
    public ParticleSystem projectile;
    public bool animatorEnter;

    Rigidbody rb;

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
        if (rb == null) rb = GetComponent<Rigidbody>();

        if (efectSentuhan != null) efectSentuhan.Play();
        if (projectile != null) projectile.Stop();
        if (animatorEnter) GetComponent<Animator>().SetTrigger("Enter");

        rb.isKinematic = isKinematicCollision;

        if (destroyCollision)
        {
            Destroy(gameObject, destroyTimeCollision);
        }
    }
}
