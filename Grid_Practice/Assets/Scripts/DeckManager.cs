using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>(); // The deck of cards
    public Transform deckPosition; // Position of the deck in 3D space
    public GameObject cardPrefab; // The 3D card prefab
    public HandContainer handContainer; // Reference to the HandContainer
    public Color gizmoColor = Color.blue; // Color for the gizmo in the editor
    public float gizmoSize = 0.5f; // Size of the gizmo

    void Start()
    {
        ShuffleDeck();
        DrawInitialHand();
    }

    public void ShuffleDeck()
    {
        // Shuffle the deck logic
    }

    public void DrawCard()
    {
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);

            // Instantiate the card in 3D space
            GameObject cardObject = Instantiate(cardPrefab, deckPosition.position, Quaternion.identity);
            cardObject.GetComponent<Card3D>().SetCardData(drawnCard);

            // Add the card to the hand
            handContainer.AddCardToHand(cardObject);
        }
    }

    void DrawInitialHand()
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }

    void OnDrawGizmos()
    {
        if (deckPosition != null)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(deckPosition.position, Vector3.one * gizmoSize);
        }
    }
}