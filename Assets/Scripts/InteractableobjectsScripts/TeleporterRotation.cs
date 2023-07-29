using UnityEngine;

public class TeleporterRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // The rotation speed in degrees per second
    public float timeBetweenMovements = 0.3f; // The time between each movement in seconds

    private float timeElapsed = 0f;
    private float currentAngle = 0f;

    private void Update()
    {
        // Increment the time elapsed
        timeElapsed += Time.deltaTime;

        // Check if it's time to perform the next movement
        if (timeElapsed >= timeBetweenMovements)
        {
            // Calculate the amount of rotation needed to rotate by 30 degrees
            float rotationAmount = rotationSpeed * timeBetweenMovements;

            // Increment the current angle by the rotation amount
            currentAngle += rotationAmount;

            // Apply the rotation to the object around the z-axis
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

            // Reset the timer
            timeElapsed = 0f;
        }
    }
}
