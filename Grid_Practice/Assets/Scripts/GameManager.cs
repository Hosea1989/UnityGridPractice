using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardManager cardManager;          // Reference to the CardManager
    public GridGenerator gridGenerator;      // Reference to the GridGenerator
    public int currentPlayer = 0;            // Track the current player (if multiplayer)

    public CardCollection playerCollection;  // Reference to the player's card collection
    public Deck playerDeck;                  // Reference to the player's deck

    void Start()
    {
        // Initialize the game
        InitializeGame();
    }

    void InitializeGame()
    {
        // Load the deck from the player's collection
        LoadDeckFromCollection();

        // Shuffle the deck and deal initial hands
        cardManager.ShuffleDeck();
        DealInitialCards();

        // Set up the game state
        currentPlayer = 0;
        StartPlayerTurn();
    }

    void LoadDeckFromCollection()
    {
        // Clear any existing cards in the deck
        playerDeck.deckCards.Clear();

        // Add cards from the collection to the deck
        // This could be based on saved data, user selection, etc.
        // For now, let's just add a fixed number of cards from the collection to the deck
        for (int i = 0; i < 20; i++)  // Adjust this number based on deck size
        {
            if (i < playerCollection.ownedCards.Count)
            {
                playerDeck.AddCardToDeck(playerCollection.ownedCards[i]);
            }
        }

        // Update the CardManager's deck reference
        cardManager.deck = playerDeck.deckCards;
    }

    void DealInitialCards()
    {
        // Adjusted: Deal 4 cards to the player at the start
        for (int i = 0; i < 4; i++)
        {
            cardManager.DrawCard();
        }
    }

    void StartPlayerTurn()
    {
        // Logic to start a player's turn
        Debug.Log("Player " + (currentPlayer + 1) + "'s turn starts.");

        // Draw a card at the start of the turn
        cardManager.DrawCard();

        // Additional turn logic can go here (e.g., rolling dice, playing cards, etc.)
    }

    public void EndPlayerTurn()
    {
        // End the current player's turn and check game state
        Debug.Log("Player " + currentPlayer + "'s turn ends.");
        currentPlayer = (currentPlayer + 1) % 2; // Example for 2 players

        // Start the next player's turn
        StartPlayerTurn();
    }
}