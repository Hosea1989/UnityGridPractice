using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;                       // Name of the card
    public Sprite cardArtwork;                    // Artwork displayed on the card
    public GameObject characterPrefab;            // The prefab to instantiate when the card is played
    public int cost;                              // Cost of playing the card
    public List<Vector2Int> placementPattern;     // Offsets for placement pattern on the grid
    public int damage;                            // Damage value
    public int health;                            // Health value

    // Define a custom pattern for this card
    public void SetPattern(List<Vector2Int> pattern)
    {
        placementPattern = pattern;
    }

    // Example method to get the card's placement pattern
    public List<Vector2Int> GetPlacementPattern()
    {
        return placementPattern;
    }

    // Example method to apply damage to the card
    public void ApplyDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0) health = 0; // Ensure health doesn't drop below 0
    }

    // Example method to check if the card is still alive
    public bool IsAlive()
    {
        return health > 0;
    }
}
