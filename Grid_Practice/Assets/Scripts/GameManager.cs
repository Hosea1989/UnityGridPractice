using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardManager cardManager;          // Reference to the CardManager
    public HandUIManager handUIManager;      // Reference to the HandUIManager
    public GridGenerator gridGenerator;          // Reference to the GridManager
    public int currentPlayer = 0;            // Track the current player (if multiplayer)

    void Start()
    {
        // Initialize the game
        InitializeGame();
    }

    void InitializeGame()
    {
        // Shuffle the deck and deal initial hands
        cardManager.ShuffleDeck();
        DealInitialCards();

        // Set up the game state
        currentPlayer = 0;
        StartPlayerTurn();
    }

    void DealInitialCards()
    {
        // Example: Deal 3 cards to the player at the start
        for (int i = 0; i < 3; i++)
        {
            cardManager.DrawCard();
        }
    }

    void StartPlayerTurn()
    {
        // Logic to start a player's turn
        Debug.Log("Player " + currentPlayer + "'s turn starts.");
        // Allow the player to draw a card or take an action
        cardManager.DrawCard();
    }

    public void EndPlayerTurn()
    {
        // End the current player's turn and check game state
        Debug.Log("Player " + currentPlayer + "'s turn ends.");
        currentPlayer = (currentPlayer + 1) % 2; // Example for 2 players
        StartPlayerTurn();
    }
}
