using UnityEngine;
using System.Collections.Generic; // Required for List

public class Player : MonoBehaviour
{
    // Variables with different data types
    private Vector2 velocity = new Vector2(); // Private access level
    public float speed = 5f; // Public access level
    private List<string> movementKeys = new List<string> {"Horizontal", "Vertical"};

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        PrintActiveKeys();
    }

    // Function to handle movement
    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        velocity = new Vector2(moveX, moveY).normalized * speed;
        rb.linearVelocity = velocity;
    }

    // Custom function that prints active movement keys
    private void PrintActiveKeys()
    {
        foreach (string key in movementKeys) // Demonstrating loop usage
        {
            if (Input.GetAxis(key) != 0)
            {
                Debug.Log("Key pressed: " + key);
            }
        }
    }
}
