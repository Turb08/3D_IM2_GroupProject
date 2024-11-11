using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the cube
    public GameObject sphere; // Reference to the sphere
    private bool sphereDisappeared = false; // Track if the sphere has already disappeared

    // Position of the sphere (center of the perimeter)
    public Vector3 spherePosition = new Vector3(0f, 0f, 0f); // You can set this to wherever the sphere is in your scene
    // The radius of the perimeter (distance within which the sphere will disappear)
    public float perimeterRadius = 4f;

    void Update()
    {
        // Get input from the arrow keys (left, right, up, down) or WASD keys
        float horizontal = Input.GetAxis("Horizontal"); // Left/Right arrows or A/D keys
        float vertical = Input.GetAxis("Vertical");     // Up/Down arrows or W/S keys

        // Create a movement vector based on the input
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        // Apply the movement to the cube
        transform.Translate(movement);

        // Check if the cube is within the perimeter (distance to the sphere's center)
        if (!sphereDisappeared)
        {
            // Calculate the distance between the cube and the center of the sphere
            float distanceToSphere = Vector3.Distance(transform.position, spherePosition);

            // If the cube is within the perimeter (i.e., distance is less than or equal to the perimeter radius), hide the sphere
            if (distanceToSphere <= perimeterRadius && sphere != null)
            {
                sphere.SetActive(false); // Hide the sphere
                sphereDisappeared = true; // Mark the sphere as disappeared
            }
        }
    }
}
