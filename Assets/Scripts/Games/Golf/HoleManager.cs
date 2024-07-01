using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HoleManager : MonoBehaviour
{
    public GameObject hole;  // Przypisz tutaj obiekt dziurki
    public GameObject ball;  // Przypisz tutaj obiekt pi³ki
    public Tilemap tilemap;  // Przypisz tutaj tilemapê boiska
    public float holeHeightOffset = 0.5f;  // Przesuniêcie wysokoœci dziurki
    public float ballHeightOffset = 0.5f;  // Przesuniêcie wysokoœci pi³ki
    public float moveInterval = 60f;  // Czas w sekundach, co ile dziurka zmienia miejsce

    private List<Vector3> respawnPositions = new List<Vector3>();
    private Vector3 initialBallPosition;

    private void Start()
    {
        InitializeRespawnPositions();
        MoveHoleToRandomPosition();
        initialBallPosition = ball.transform.position;
        StartCoroutine(ChangeHolePosition());
    }

    private void InitializeRespawnPositions()
    {
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                Vector3 worldPos = tilemap.CellToWorld(pos) + tilemap.tileAnchor;
                respawnPositions.Add(worldPos);
            }
        }
    }

    private void MoveHoleToRandomPosition()
    {
        if (respawnPositions.Count > 0)
        {
            Vector3 randomPosition = respawnPositions[Random.Range(0, respawnPositions.Count)];
            hole.transform.position = new Vector3(randomPosition.x, randomPosition.y + holeHeightOffset, randomPosition.z);
            Debug.Log("Hole moved to: " + hole.transform.position);
        }
    }

    private IEnumerator ChangeHolePosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveInterval);
            MoveHoleToRandomPosition();
        }
    }

    private void RespawnBall()
    {
        ball.SetActive(false); // Deaktywuj pi³kê przed resetowaniem pozycji
        ball.transform.position = new Vector3(initialBallPosition.x, initialBallPosition.y + ballHeightOffset, initialBallPosition.z);
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
        }
        ball.SetActive(true); // Aktywuj pi³kê po ustawieniu pozycji
        Debug.Log("Ball respawned at initial position: " + ball.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball entered hole.");
            RespawnBall();
        }
    }
}








