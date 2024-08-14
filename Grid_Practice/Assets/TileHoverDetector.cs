using UnityEngine;
using TMPro;

public class TileHoverDetector : MonoBehaviour
{
    public TileInfoCard tileInfoCard; // Reference to the TileInfoCard script

    private Renderer lastRenderer;  // To keep track of the last hovered tile's renderer
    private Color originalColor;    // To store the original color

    void Update()
    {
        DetectTileHover();
    }

    void DetectTileHover()
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a collider
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            Renderer renderer = hitObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                // If we're hovering over a different tile, reset the last tile's color
                if (lastRenderer != null && lastRenderer != renderer)
                {
                    lastRenderer.material.color = originalColor;
                }

                // Store the original color of the new tile
                if (renderer != lastRenderer)
                {
                    originalColor = renderer.material.color;
                }

                // Change the tile's color to indicate hovering
                renderer.material.color = Color.black;

                // Update lastRenderer to the current tile
                lastRenderer = renderer;

                // Determine the type of tile and update the info card
                string tileType = "Normal Tile";
                if (hitObject.CompareTag("PlayableTile"))
                {
                    tileType = "Playable Tile";
                }
                else if (hitObject.CompareTag("EnemyDomainLeader"))
                {
                    tileType = "Enemy Domain Leader";
                }
                else if (hitObject.CompareTag("PlayerDomainLeader"))
                {
                    tileType = "Player Domain Leader";
                }

                // Update the info card with the tile type and position
                tileInfoCard.UpdateInfoCard(tileType, hitObject.transform.position);
            }
        }
        else
        {
            // If the raycast doesn't hit anything, reset the last hovered tile's color
            if (lastRenderer != null)
            {
                lastRenderer.material.color = originalColor;
                lastRenderer = null;
            }

            // Hide the info card
            tileInfoCard.HideInfoCard();
        }
    }
}