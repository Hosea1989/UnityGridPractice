using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject PlayableTile; // Prefab for the regular playable tiles
    public GameObject DomainLeaderTile; // Prefab for the Domain Leader tile
    public GameObject DomainLeader; // Prefab for the Domain Leader character
    public GameObject EnemyDomainLeaderTile; // Prefab for the Enemy Domain Leader tile
    public GameObject EnemyDomainLeader; // Prefab for the Enemy Domain Leader character
    public GameObject mapParent; // Parent object for organizing the grid in the hierarchy
    public int gridWidth = 13;      // Number of tiles in the grid's width
    public int gridHeight = 19;     // Number of tiles in the grid's height
    public float tileSpacing; // Spacing between tiles, calculated based on PlayableTile's size

    private GameObject[,] gridTiles; // Array to store references to the tile GameObjects

    void Start()
    {
        // Calculate tile size based on the PlayableTile prefab
        tileSpacing = PlayableTile.GetComponent<Renderer>().bounds.size.x * 1.0f; // Adjust multiplier if needed

        GenerateGrid(); // Create the grid
    }

    // Method to generate the grid
    void GenerateGrid()
    {
        gridTiles = new GameObject[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 tilePosition = new Vector3(x * tileSpacing, 0, z * tileSpacing);
                GameObject newTile = Instantiate(PlayableTile, tilePosition, Quaternion.identity);

                // Set the parent of the tile to the mapParent for better hierarchy organization
                newTile.transform.SetParent(mapParent.transform);

                // Alternate the color to create a chessboard pattern
                Renderer tileRenderer = newTile.GetComponent<Renderer>();
                if ((x + z) % 2 == 0)
                {
                    tileRenderer.material.color = Color.white; // White tile
                }
                else
                {
                    tileRenderer.material.color = Color.black; // Black tile
                }

                gridTiles[x, z] = newTile; // Store the tile in the array
            }
        }

        // Place Domain Leaders at specific positions
        ReplaceTileWithDomainLeader(6, 1);
        ReplaceTileWithEnemyDomainLeader(6, 17);
    }

    // Method to replace a tile with the Domain Leader tile
    void ReplaceTileWithDomainLeader(int x, int z)
    {
        if (x >= 0 && x < gridWidth && z >= 0 && z < gridHeight)
        {
            // Destroy the existing tile at the given coordinates
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

    // Method to replace a tile with the Enemy Domain Leader tile
    void ReplaceTileWithEnemyDomainLeader(int x, int z)
    {
        if (x >= 0 && x < gridWidth && z >= 0 && z < gridHeight)
        {
            // Destroy the existing tile at the given coordinates
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

    // Method to place a character on the grid
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

    // Draw grid gizmos in the Editor to visualize the grid
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 tilePosition = new Vector3(x * tileSpacing, 0, z * tileSpacing);
                Gizmos.DrawWireCube(tilePosition, new Vector3(tileSpacing, 0.1f, tileSpacing));
            }
        }
    }
}