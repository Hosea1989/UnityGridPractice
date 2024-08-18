using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragHandler : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z); // Preserve Y position if needed
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Handle dropping the card onto a grid here
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the card is being placed on a valid grid tile
            if (hit.collider.CompareTag("GridTile"))
            {
                // Place the card on the grid
                transform.position = hit.collider.transform.position;
                // Additional logic for placing the card on the grid
            }
            else
            {
                // If not placed on a valid grid, return to hand or other behavior
                // You might want to implement a snapping-back mechanism
            }
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }
}