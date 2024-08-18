using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CardDatabase", menuName = "Card Database")]
public class CardDatabase : ScriptableObject
{
    public List<Card> allCards = new List<Card>(); // A list to hold all unique cards in the game

    public Card GetCardByName(string cardName)
    {
        return allCards.Find(card => card.cardName == cardName);
    }

    public Card GetCardByID(int id)
    {
        return allCards[id];
    }
}