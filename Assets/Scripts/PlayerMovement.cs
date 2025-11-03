using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    private int currentLane = 0;

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position; 
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
    }
}