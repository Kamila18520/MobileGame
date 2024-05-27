using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public GameObject holePrefab;
    public float spawnInterval = 1f;
    public Vector2 minSpawnPosition;
    public Vector2 maxSpawnPosition;

    private void Start()
    {
        InvokeRepeating("SpawnHole", 0f, spawnInterval);
    }

    private void SpawnHole()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y)
        );
        Instantiate(holePrefab, spawnPosition, Quaternion.identity);
    }
}

