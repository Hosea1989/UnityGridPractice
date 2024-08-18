using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public int handSize;                     // Number of cards in hand
    public int deckSize;                     // Number of cards in deck
    public CardsPile hand;                   // Reference to the hand pile
    public CardsPile deck;                   // Reference to the deck pile
    public GameObject cardPrefab;            // Prefab for card

    void Start()
    {
        // Shuffle deck at the start
        ShuffleDeck();

        // Draw initial cards into hand
        for (int i = 0; i < handSize; i++)
        {
            DrawCardToHand();
        }
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Cards.Count; i++)
        {
            GameObject temp = deck.Cards[i];
            int randomIndex = Random.Range(i, deck.Cards.Count);
            deck.Cards[i] = deck.Cards[randomIndex];
            deck.Cards[randomIndex] = temp;
        }
    }

    public void DrawCardToHand()
    {
        if (deck.Cards.Count == 0) return;

        GameObject card = deck.Cards[deck.Cards.Count - 1];
        deck.Remove(card);
        hand.Add(card, 0);
        
        // Optionally position the card in the hand pile
        PositionCardInHand(card);
    }

    public void RemoveCardFromHand()
    {
        if (hand.Cards.Count == 0) return;

        GameObject card = hand.Cards[hand.Cards.Count - 1];
        hand.Remove(card);
        deck.Add(card);

        // Optionally position the card back in the deck pile
        PositionCardInDeck(card);
    }

    void PositionCardInHand(GameObject card)
    {
        // Example: Position cards in a row or fan within the hand container
        int cardIndex = hand.Cards.Count - 1;
        card.transform.position = hand.transform.position + new Vector3(cardIndex * 1.5f, 0, 0); // Adjust for 3D positioning
        card.transform.rotation = Quaternion.Euler(0, 0, 0); // Reset rotation if necessary
    }

    void PositionCardInDeck(GameObject card)
    {
        // Position the card within the deck pile
        card.transform.position = deck.transform.position;
        card.transform.rotation = Quaternion.Euler(0, 180, 0); // Possibly rotate to show the card back
    }
}