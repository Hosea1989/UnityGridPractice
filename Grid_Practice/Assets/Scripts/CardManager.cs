using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();        // The deck of cards
    public CardsPile handPile;                        // Reference to the player's hand
    public GameObject cardPrefab;                     // The 3D card prefab for the game

    void Start()
    {
        ShuffleDeck();
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
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);

            // Instantiate the card in 3D space
            GameObject cardObject = Instantiate(cardPrefab);
            cardObject.GetComponent<Card3D>().SetCardData(drawnCard);

            // Add the card to the hand pile
            handPile.Add(cardObject, false); // Add without animation if preferred
        }
    }
}