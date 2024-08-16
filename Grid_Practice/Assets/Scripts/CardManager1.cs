using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();  // The deck of cards
    public int maxHandSize = 5;  // Maximum number of cards in hand
    public GameObject cardPrefab;  // The 3D card prefab for the game
    public Transform handTransform;  // Reference to the HandContainer's Transform

    void Start()
    {
        ShuffleDeck();
        DrawInitialHand();
    }

    // Make sure this method is public so it can be accessed by other classes
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

    void DrawInitialHand()
    {
        for (int i = 0; i < maxHandSize; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);

            GameObject cardObject = Instantiate(cardPrefab);
            cardObject.GetComponent<Card3D>().SetCardData(drawnCard);

            cardObject.transform.SetParent(handTransform);
            // Add positioning logic if needed
        }
    }
}