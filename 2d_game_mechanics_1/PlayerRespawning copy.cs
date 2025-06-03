using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // Assign in Inspector
    private Vector3 initialPosition;

    private void Start()
    {
        if (respawnPoint != null)
            initialPosition = respawnPoint.position;
        else
            initialPosition = transform.position;
    }

    public void Respawn()
    {
        transform.position = initialPosition;
        // Reset velocity if using Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    // Example trigger for falling off the level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Respawn();
        }
    }
}
