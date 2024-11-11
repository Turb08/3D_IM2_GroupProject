using System;
using UnityEngine;
using UnityEngine.UI; // For UI elements like Slider

public class SpriteMovement : MonoBehaviour
{
    // Declare necessary variables at the class level
    private UnityEngine.Vector3 movementDirection;
    public float currentStamina = 100f;
    public float maxStamina = 100f;
    public float staminaDrainRate = 5f;
    public float staminaRegenRate = 2f;
    public float noMovementTime = 30f;
    private float timeSinceLastMovement = 0f;

    public Slider staminaBar; // Make sure to assign this in the Unity Inspector

    void Update()
    {
        // Handle movement with arrow keys
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }

        movementDirection = new UnityEngine.Vector3(moveX, moveY, 0f);

        // Set base movement speed
        float speed = 5f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f; // Double the speed when Shift is pressed
        }

        transform.Translate(movementDirection * Time.deltaTime * speed); // Move the object

        // Check if the player is holding Shift and moving
        bool isMoving = moveX != 0 || moveY != 0;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && isMoving;

        if (isSprinting)
        {
            // Drain stamina
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Max(currentStamina, 0); // Ensure it doesn’t go below zero
            timeSinceLastMovement = 0f; // Reset the idle timer

            UnityEngine.Debug.Log("Draining stamina. Current stamina: " + currentStamina);
        }
        else
        {
            timeSinceLastMovement += Time.deltaTime;
        }

        // Regenerate stamina if idle for the specified time
        if (timeSinceLastMovement >= noMovementTime)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina); // Ensure it doesn’t exceed max value
            UnityEngine.Debug.Log("Regenerating stamina. Current stamina: " + currentStamina);
        }

        // Update the stamina bar
        if (staminaBar != null)
        {
            staminaBar.value = currentStamina;
        }
    }
}
