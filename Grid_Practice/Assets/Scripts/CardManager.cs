using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();        // The deck of cards
    public List<Card> hand = new List<Card>();        // The player's current hand
    public int maxHandSize = 5;                       // Maximum number of cards in hand
    public HandUIManager handUIManager;               // Reference to the HandUIManager
    public GridGenerator gridGenerator;               // Reference to the GridGenerator

    void Start()
    {
        // Example: Shuffle the deck at the start of the game
        ShuffleDeck();

        // Draw initial cards (e.g., 3 cards)
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void DrawCard()
    {
        if (deck.Count > 0 && hand.Count < maxHandSize)
        {
            // Draw the top card from the deck
            Card drawnCard = deck[0];
            deck.RemoveAt(0);

            // Add the card to the player's hand
            hand.Add(drawnCard);

            // Update the UI
            handUIManager.AddCardToHand(drawnCard);
        }
    }

   public void PlayCard(int cardIndex, Vector2Int gridPosition)
   {
    if (cardIndex >= 0 && cardIndex < hand.Count)
    {
        Card cardToPlay = hand[cardIndex];

        // Implement the logic to play the card on the grid using GridGenerator
        bool success = gridGenerator.PlaceCharacter(cardToPlay.characterPrefab, gridPosition);

        if (success)
        {
            // Remove the card from the hand
            hand.RemoveAt(cardIndex);

            // Update the UI (e.g., remove the card from the hand UI)
            handUIManager.RemoveCardFromHand(cardIndex);
        }
        else
        {
            Debug.Log("Failed to place the character. Check if the position is valid.");
        }
    }
}
}
