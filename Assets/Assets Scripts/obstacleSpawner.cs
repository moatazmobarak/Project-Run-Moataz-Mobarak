using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;

    public float spawnDistance = 30f;
    public float spawnInterval = 2f;

    public float[] lanes = { -3f, 0f, 3f };

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = spawnDistance;
    }

    void Update()
    {
        if (player.position.z + spawnDistance > nextSpawnZ)
        {
            SpawnObstacle();
            nextSpawnZ += spawnInterval * 10f;
        }
    }

    void SpawnObstacle()
    {
        float laneX = lanes[Random.Range(0, lanes.Length)];
        Vector3 spawnPos = new Vector3(laneX, -1f, nextSpawnZ);

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
