using UnityEngine;

public class PlayerSpawning : MonoBehaviour
{
    public GameObject playerPrefab;        // ← This must be public or have [SerializeField]
    public Transform spawnPoint;

    void Start()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
