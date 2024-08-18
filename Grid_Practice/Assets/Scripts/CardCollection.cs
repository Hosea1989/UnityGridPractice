using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardCollection", menuName = "Card DataBase /Card Collection")]
public class CardCollection : ScriptableObject
{
    public List<Card> ownedCards = new List<Card>();  // List of all cards in the game
}