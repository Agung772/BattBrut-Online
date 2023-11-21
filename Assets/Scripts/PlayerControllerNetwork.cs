using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControllerNetwork : MonoBehaviourPun
{
    CinemachineVirtualCamera cinemachineFreeLook;
    public bool isControlled = true;

    EventButton jumpButton;
    public float turnSmoothTime = 0.1f;
    public float movementSpeedMax = 4f;
    public float onRun;
    float movementSpeed = 4f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundDistance = 0.25f;
    public float maxFallZone = -100f;
    public LayerMask groundMask;
    public GameObject groundCheck;
    CharacterController characterController;

    public Animator animator;

    PlayerShoot playerShoot;

    GameObject cam;
    Vector3 move;
    public Vector3 velocity;
    float turnSmoothVelocity;
    float canJump = 0f;
    float canDash= 1f;
    [HideInInspector]
    public float horizontal;
    float vertical;
    bool isGrounded;
    bool onGrounded;

    public int maxJump;
    int countJump;


    [HideInInspector]
    public float currentTransformY;
    void Awake()
    {
        if (photonView.IsMine == false && isControlled == true)
        {
            isControlled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (isControlled)
        {
            cinemachineFreeLook = FindObjectOfType<CinemachineVirtualCamera>();
            cinemachineFreeLook.Follow = gameObject.transform;
            cinemachineFreeLook.LookAt = gameObject.transform;
            cam = GameObject.FindGameObjectWithTag("MainCamera");

            movementSpeed = movementSpeedMax;

            jumpButton = Gameplay_UI.instance.jumpButton;
            playerShoot = GetComponent<PlayerShoot>();
        }
        characterController = GetComponent<CharacterController>();

        characterController.enabled = false;
        characterController.transform.position = Vector3.up;
        characterController.enabled = true;
    } // Update is called once per frame
    void Update()
    {
        if (isControlled)
        {
            if (characterController.transform.position.y < maxFallZone)
            {
                characterController.enabled = false;
                characterController.transform.position = SpawnPoint.FindObjectOfType<SpawnPoint>().transform.position;
                characterController.enabled = true;
            }
            currentTransformY = GetComponent<Transform>().transform.eulerAngles.y;
            horizontal = Input.GetAxisRaw("Horizontal");
            //vertical = Input.GetAxisRaw("Vertical") + joystick.Vertical;
            vertical = 0;
            isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }
            move = new Vector3(horizontal, 0f, vertical).normalized;
            if (move.magnitude >= 0.1f)
            {
                //float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
            }
            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

            //if ((Input.GetKey(KeyCode.Space) || jumpButton.pressed) && isGrounded && Time.time > canJump)
            if ((Input.GetKey(KeyCode.Space) || jumpButton.pressed) && Time.time > canJump && countJump > 0 )
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                canJump = Time.time + 0.3f;
                Debug.Log("Jump");

                isGrounded = false;
                onGrounded = false;
                animator.SetBool(Tags.Ground, false);
                countJump--;

                //Animation

                if (countJump == 1)
                {
                    animator.SetTrigger(Tags.Jump);
                }
                else if (countJump == 0)
                {
                    animator.SetTrigger(Tags.DoubleJump);
                }
            }
            if (isGrounded && !onGrounded && Time.time > canJump)
            {
                onGrounded = true;
                countJump = maxJump;
                animator.SetBool(Tags.Ground, true);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = movementSpeedMax * 2.5f;
                onRun = 0.5f;
            }
            else
            {
                movementSpeed = movementSpeedMax;
                onRun = 0;
            }

            CheckDoubleClick(KeyCode.A, ref lastClickTimeKey1);
            CheckDoubleClick(KeyCode.D, ref lastClickTimeKey2);            
            CheckDoubleClick(KeyCode.LeftArrow, ref lastClickTimeKey1);
            CheckDoubleClick(KeyCode.RightArrow, ref lastClickTimeKey2);

            if (velocity.x > 0.5f) velocity.x += gravity * Time.deltaTime;
            else if (velocity.x < -0.5f) velocity.x -= gravity * Time.deltaTime;
            else velocity.x = 0;

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);

            //Freeze Z
            var postion = transform.position;
            transform.position = new Vector3(postion.x, postion.y, 0);

            //Animation
            float anim = new Vector2(horizontal, vertical).magnitude;
            animator.SetFloat(Tags.AnimasiMove, (anim / 2) + onRun);
        }


    }
    public float doubleClickDelay = 0.5f; // Sesuaikan dengan kebutuhan Anda

    private float lastClickTimeKey1;
    private float lastClickTimeKey2;
    private void CheckDoubleClick(KeyCode targetKey, ref float lastClickTime)
    {
        if (Input.GetKeyDown(targetKey))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickDelay)
            {
                if (targetKey == KeyCode.A || targetKey == KeyCode.LeftArrow)
                {
                    if (horizontal > 0) velocity.x = 10;
                    else if (horizontal < 0) velocity.x = -10;

                    canDash = Time.time + 1;
                    Debug.Log("Dash");
                    animator.SetTrigger(Tags.Dash);
                }
                else if (targetKey == KeyCode.D || targetKey == KeyCode.RightArrow)
                {
                    if (horizontal > 0) velocity.x = 10;
                    else if (horizontal < 0) velocity.x = -10;

                    canDash = Time.time + 1;
                    Debug.Log("Dash");
                    animator.SetTrigger(Tags.Dash);
                }
                lastClickTime = -1f; 
            }
            else
            {
                lastClickTime = Time.time;
            }
        }
    }
    public static void RefreshInstance(ref PlayerControllerNetwork playerControllerNetwork, 
        PlayerControllerNetwork prefab)
    {
        var position = Vector3.zero;
        var rotation = Quaternion.Euler(0, 90, 0);
        if (playerControllerNetwork != null)
        {
            position = playerControllerNetwork.transform.position;
            rotation = playerControllerNetwork.transform.rotation;
            PhotonNetwork.Destroy(playerControllerNetwork.gameObject);
        }
        playerControllerNetwork = PhotonNetwork.Instantiate(prefab.gameObject.name, position,
        rotation).GetComponent<PlayerControllerNetwork>();
    }
}