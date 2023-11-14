using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 180.0f;

    [SerializeField] float heading = 5;
    Vector3 moveDirection;

    [SerializeField] CharacterController characterController;

    [SerializeField] Animator animator;
    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (characterController.isGrounded)
        {
            // Mendapatkan input dari pemain
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Menghitung pergerakan
            moveDirection = new Vector3(horizontal, 0.0f, vertical);
            moveDirection *= speed;

            // Melompat jika tombol Space ditekan
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            Debug.Log(characterController.velocity.magnitude);
        }

        // Menambahkan efek gravitasi
        moveDirection.y -= gravity * Time.deltaTime;


        // Memindahkan karakter berdasarkan pergerakan yang dihitung
        characterController.Move(moveDirection * Time.deltaTime);


        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float inputXRaw = Input.GetAxisRaw("Horizontal");
        float inputZRaw = Input.GetAxisRaw("Vertical");
        Vector2 v2 = new Vector2(inputXRaw, inputZRaw);
        if (v2.magnitude > 0.3f)
        {
            heading = Mathf.Atan2(inputX, inputZ);
            transform.rotation = Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0);
        }

        //Animation
        float anim = new Vector2(inputX, inputZ).magnitude;
        animator.SetFloat("anim", anim);
    }
}
