using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveSpeedClamp = 40f;
    public float incrementSpeed = 1.0005f;
    public float jumpForce = 5f;
    int currentJump;
    const int maxJump = 2;
    
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    private int currentLane = 0;

    private Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position; 
    }

    void Update()
    {
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

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * laneSwitchSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || maxJump > currentJump))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            currentJump++;
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

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.tag == "Obstacle" || transform.parent != null)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over! Kena Rintangan.");
        }

        if (Other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}