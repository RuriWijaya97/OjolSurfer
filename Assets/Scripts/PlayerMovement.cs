using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement System")]
    public float moveSpeed = 5f;
    public float moveSpeedClamp = 40f;
    public float incrementSpeed = 1.0005f;
    public float jumpForce = 5f;
    int currentJump;
    const int maxJump = 2;

    [Header ("Pindah Sisi")]
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    private int currentLane = 0;

    [Header ("Physics")]
    private Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 targetPosition;
    CapsuleCollider cc;
    
    [Header ("Pause")] public GameObject PauseMenu;
    
    [Header("Animator")] public Animator animator;

    [Header ("Menghitung Jarak")]
    int distanceRun;
    public int distancePlayer;
    public Transform playerTransform;
    [Header("")] public GameManager GM;

    void Start()
    {
        //Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        targetPosition = transform.position;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }
       
    void Update()
    {
        AddDistance();
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Input Kiri
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLane(-1);
        }

        // Input Kanan
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLane(1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(OjolSliding());
        }

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * laneSwitchSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || maxJump > currentJump))
        {
            StartCoroutine(Jumping());
        }

        if (moveSpeed < moveSpeedClamp)
        {
            moveSpeed += incrementSpeed;
            currentJump = 0;
        }
    }
    private void ChangeLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, -1, 1);
        targetPosition = new Vector3(targetPosition.x, targetPosition.y, currentLane * laneDistance);
    }

    private IEnumerator OjolSliding()
    {
        animator.SetBool("Sliding", true);
        cc.center = new Vector3(-0.03322732f, -0.5102046f, 0.1f);
        cc.height = 0.8387966f;
        yield return new WaitForSeconds(1.3f);
        animator.SetBool("Sliding", false);
        cc.center = new Vector3(-1.28f, -0.07137185f, 0.01278728f);
        cc.height = 1.716462f;
    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.tag == "Obstacle" || transform.parent != null)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            Debug.Log("Game Over! Kena Rintangan.");
        }

        if (Other.gameObject.tag == "Ground")
        {
            animator.SetBool("Jump", false);
            isGrounded = true;
            Debug.Log(isGrounded);
        }
    }

    IEnumerator Jumping()
    {
        animator.SetBool("Jump", true);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        currentJump++;
        yield return new WaitForSeconds(1f);
        animator.SetBool("Jump", false);
        isGrounded = true;
        Debug.Log(isGrounded);

    }

    public void AddDistance()
    {
        distanceRun = (int)playerTransform.position.x;
        distancePlayer = Mathf.Abs(distanceRun);
        GM.DistanceUpdate(distancePlayer);
    }
}