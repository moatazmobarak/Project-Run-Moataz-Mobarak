using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleDataSO collectibleData;
    public GameObject pickupEffect;

    void Start()
    {
        GetComponent<Renderer>().material.color = collectibleData.collectibleColor;
    }

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        ScoreManager.instance.AddScore(1);

        if (pickupEffect)
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}

}
