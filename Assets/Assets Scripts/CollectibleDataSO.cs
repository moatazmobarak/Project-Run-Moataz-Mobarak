using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleData", menuName = "Game Data/Collectible")]
public class CollectibleDataSO : ScriptableObject
{
    public int scoreValue = 10;
    public Color collectibleColor = Color.yellow;
}
