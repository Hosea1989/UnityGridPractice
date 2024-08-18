using UnityEngine;

public class Card3D : MonoBehaviour
{
    private Card cardData;

    public SpriteRenderer cardFrontRenderer; // Reference to the front renderer
    public SpriteRenderer cardBackRenderer;  // Reference to the back renderer

    public void SetCardData(Card card)
    {
        cardData = card;
        UpdateCardVisuals();
    }

    void UpdateCardVisuals()
    {
        // Update the front renderer with the card's artwork
        if (cardFrontRenderer != null && cardData.cardArtwork != null)
        {
            cardFrontRenderer.sprite = cardData.cardArtwork;
        }

        // Optionally update the back renderer if needed (e.g., to show a default back)
        // cardBackRenderer.sprite = yourBackSprite; 
    }

    void OnMouseDown()
    {
        // Handle card selection or dragging
        Debug.Log("Card selected: " + cardData.cardName);
    }
}