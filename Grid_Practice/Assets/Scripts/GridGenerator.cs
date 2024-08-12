using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject PlayableTile; // Field to hold the tile prefab
    public GameObject DomainLeaderTile; // Field to hold the Domain Leader tile prefab
    public GameObject DomainLeader; // Field to hold the Domain Leader character prefab
    public GameObject EnemyDomainLeaderTile; // Field to hold the Enemy Domain Leader tile prefab
    public GameObject EnemyDomainLeader; // Field to hold the Enemy Domain Leader character prefab
    public GameObject mapParent; // Reference to the map parent object
    public int gridWidth = 13;      // Width of the grid
    public int gridHeight = 19;     // Height of the grid
    public float tileSpacing = 1.1f; // Spacing between tiles

    private GameObject[,] gridTiles; // Array to store the tile GameObjects

    void Start()
    {
        gridTiles = new GameObject[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 tilePosition = new Vector3(x * tileSpacing, 0, z * tileSpacing);
                GameObject newTile = Instantiate(PlayableTile, tilePosition, Quaternion.identity);

                // Set the parent of the tile to the mapParent
                newTile.transform.SetParent(mapParent.transform);

                gridTiles[x, z] = newTile; // Store the tile in the array
            }
        }

        // Replace the tile at coordinates (6, 1) with the Domain Leader tile
        ReplaceTileWithDomainLeader(6, 1);

        // Replace the tile at coordinates (6, 18) with the Enemy Domain Leader tile
        ReplaceTileWithEnemyDomainLeader(6, 17);
    }

    void ReplaceTileWithDomainLeader(int x, int z)
    {
        if (x >= 0 && x < gridWidth && z >= 0 && z < gridHeight)
        {
            // Destroy the existing tile
            Destroy(gridTiles[x, z]);

            // Instantiate the Domain Leader tile at the same position
            Vector3 tilePosition = new Vector3(x * tileSpacing, 0, z * tileSpacing);
            GameObject leaderTile = Instantiate(DomainLeaderTile, tilePosition, Quaternion.identity);

            // Set the parent of the tile to the mapParent
            leaderTile.transform.SetParent(mapParent.transform);

            // Instantiate the Domain Leader character on top of the new tile
            Instantiate(DomainLeader, tilePosition, Quaternion.identity);

            // Store the new tile in the array
            gridTiles[x, z] = leaderTile;
        }
        else
        {
            Debug.LogError("Coordinates out of bounds.");
        }
    }

    void ReplaceTileWithEnemyDomainLeader(int x, int z)
    {
        if (x >= 0 && x < gridWidth && z >= 0 && z < gridHeight)
        {
            // Destroy the existing tile
            Destroy(gridTiles[x, z]);

            // Instantiate the Enemy Domain Leader tile at the same position
            Vector3 tilePosition = new Vector3(x * tileSpacing, 0, z * tileSpacing);
            GameObject enemyLeaderTile = Instantiate(EnemyDomainLeaderTile, tilePosition, Quaternion.identity);

            // Set the parent of the tile to the mapParent
            enemyLeaderTile.transform.SetParent(mapParent.transform);

            // Instantiate the Enemy Domain Leader character on top of the new tile
            Instantiate(EnemyDomainLeader, tilePosition, Quaternion.identity);

            // Store the new tile in the array
            gridTiles[x, z] = enemyLeaderTile;
        }
        else
        {
            Debug.LogError("Coordinates out of bounds.");
        }
    }

    public bool PlaceCharacter(GameObject characterPrefab, Vector2Int gridPosition)
{
    int x = gridPosition.x;
    int z = gridPosition.y;

    if (x >= 0 && x < gridWidth && z >= 0 && z < gridHeight)
    {
        // Convert the grid position to world position
        Vector3 worldPosition = new Vector3(x * tileSpacing, 0, z * tileSpacing);

        // Instantiate the character at the world position
        GameObject character = Instantiate(characterPrefab, worldPosition, Quaternion.identity);

        // Set the parent to the mapParent if needed
        character.transform.SetParent(mapParent.transform);

        // Optionally, mark this tile as occupied or handle it in your game logic
        return true; // Character placed successfully
    }
    else
    {
        Debug.LogError("Grid position out of bounds.");
        return false; // Failed to place character
    }
}

}
