using UnityEngine;

public class OjolMainMenuAnim : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value in the Inspector to control speed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float distanceToTurn = 10.0f;

    // Private variable to track the total distance traveled so far
    private float distanceTraveled = 0.0f;

    void Start()
    {

        Time.timeScale = 1;
    }
    void Update()
    {
        float moveDistance = moveSpeed * Time.deltaTime;
        distanceTraveled += moveDistance;
        // Move the object forward along its local Z-axis
        transform.Translate(Vector3.forward * moveDistance);

        if (distanceTraveled >= distanceToTurn)
        {
            // Reset the tracking variable so it can travel the distance again
            distanceTraveled = 0.0f;

            // Rotate the object 180 degrees around the Y-axis (vertical axis)
            transform.Rotate(0, 180, 0);

            // Optional: You can also use transform.Rotate(Vector3.up * 180)
        }
    }
}
