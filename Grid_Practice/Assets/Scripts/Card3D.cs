using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card3D : MonoBehaviour
{
    private Card cardData;

    public Renderer cardRenderer; // Reference to the renderer that displays the card's artwork
    public TextMesh cardNameText; // Reference to a 3D text component that displays the card's name

    public void SetCardData(Card card)
    {
        cardData = card;
        UpdateCardVisuals();
    }

    void UpdateCardVisuals()
    {
        // Update the visuals of the card based on the cardData
        if (cardRenderer != null && cardData.cardArtwork != null)
        {
            cardRenderer.material.mainTexture = cardData.cardArtwork.texture;
        }

        if (cardNameText != null)
        {
            cardNameText.text = cardData.cardName;
        }

        // You can add additional visual updates here, like displaying cost, health, etc.
    }

    void OnMouseDown()
    {
        // Handle card selection or dragging
        Debug.Log("Card selected: " + cardData.cardName);
    }
}