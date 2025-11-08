using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float moveSpeed = 2f; // Adjust this value in the Inspector
    public float distanceToTurn = 2.0f;

    // We need a variable to track the current movement direction.
    // '1' for forward, '-1' for backward.
    private int moveDirection = 1;
    private float distanceTraveled = 0.0f;

    void Start()
    {
        //Time.timeScale = 1;
    }

    void Update()
    {
        // The distance calculation remains the same
        float moveDistance = moveSpeed * Time.deltaTime;
        distanceTraveled += moveDistance;

        // Move the object based on the current moveDirection
        // If moveDirection is 1, it moves forward. If -1, it moves backward.
        transform.Translate(Vector3.forward * moveDistance * moveDirection);

        if (distanceTraveled >= distanceToTurn)
        {
            // Reset the tracking variable
            distanceTraveled = 0.0f;

            // CHANGE 1: Flip the direction multiplier from 1 to -1 or vice versa
            moveDirection *= -1;
        }
    }
}
