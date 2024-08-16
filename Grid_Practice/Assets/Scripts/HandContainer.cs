using UnityEngine;
using System.Collections.Generic;

public class HandContainer : MonoBehaviour
{
    public List<GameObject> handCards = new List<GameObject>(); // List of card GameObjects in hand
    public float cardSpacing = 1.5f; // Spacing between cards in the hand
    public Transform handTransform; // Parent transform to organize the hand

    public Color gizmoColor = Color.green;  // Color of the Gizmo
    public Vector3 gizmoSize = new Vector3(1.5f, 2, 0.1f); // Size of the Gizmo for each card

    void Start()
    {
        if (handTransform == null)
        {
            handTransform = this.transform; // Set the handTransform to this object if not set
        }
        ArrangeHand();
    }

    // Adds a card to the hand
    public void AddCardToHand(GameObject card)
    {
        handCards.Add(card);
        card.transform.SetParent(handTransform); // Set the parent to the HandContainer
        ArrangeHand(); // Re-arrange the hand after adding a card
    }

    // Arranges the cards in the hand in a row or fan
    public void ArrangeHand()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            // Position cards in a row or other arrangement
            handCards[i].transform.localPosition = new Vector3(i * cardSpacing, 0, 0); // Adjust spacing as needed
            handCards[i].transform.localRotation = Quaternion.Euler(0, 0, 0); // Adjust rotation as needed
        }
    }

    // Removes a card from the hand
    public void RemoveCardFromHand(GameObject card)
    {
        handCards.Remove(card);
        ArrangeHand(); // Re-arrange the hand after removing a card
    }

    // Draws Gizmos in the Scene view to visualize the hand container
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        for (int i = 0; i < handCards.Count + 1; i++) // +1 to show where the next card would go
        {
            Vector3 gizmoPosition = transform.position + new Vector3(i * cardSpacing, 0, 0);
            Gizmos.DrawWireCube(gizmoPosition, gizmoSize);
        }
    }
}