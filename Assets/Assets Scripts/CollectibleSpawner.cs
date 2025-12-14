using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public Transform player;

    public float spawnDistance = 25f;
    public float spawnInterval = 15f;
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
            SpawnCollectible();
            nextSpawnZ += spawnInterval;
        }
    }

    void SpawnCollectible()
    {
        float laneX = lanes[Random.Range(0, lanes.Length)];
        Vector3 spawnPos = new Vector3(laneX, 1f, nextSpawnZ);

        Instantiate(collectiblePrefab, spawnPos, Quaternion.identity);
    }
}
