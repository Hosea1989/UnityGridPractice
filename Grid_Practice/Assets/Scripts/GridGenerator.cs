using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject PlayableTile; // Field to hold the tile prefab
    public int gridWidth = 10;      // Width of the grid
    public int gridHeight = 10;     // Height of the grid
    public float tileSpacing = 1.1f; // Spacing between tiles

    void Start()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Vector3 tilePosition = new Vector3(x * tileSpacing, 0, z * tileSpacing);
                Instantiate(PlayableTile, tilePosition, Quaternion.identity);
            }
        }
    }
}
