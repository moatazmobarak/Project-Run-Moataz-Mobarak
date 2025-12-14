using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleDataSO collectibleData;

    void Start()
    {
        GetComponent<Renderer>().material.color = collectibleData.collectibleColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(collectibleData.scoreValue);
            Destroy(gameObject);
        }
    }
}
