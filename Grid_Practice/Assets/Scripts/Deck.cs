using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deckCards = new List<Card>(); // A list to hold the cards in the player's deck

    public void AddCardToDeck(Card card)
    {
        deckCards.Add(card);
    }

    public void RemoveCardFromDeck(Card card)
    {
        deckCards.Remove(card);
    }
}