using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject roadTilePrefab;
    public Transform player;

    public int tilesOnScreen = 5;
    public float tileLength = 30f;

    private float spawnZ = 0f;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z - 35f > spawnZ - (tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(
            roadTilePrefab,
            Vector3.forward * spawnZ,
            Quaternion.identity
        );

        activeTiles.Add(tile);
        spawnZ += tileLength;
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
