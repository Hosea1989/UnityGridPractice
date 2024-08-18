using System;
using System.Collections.Generic;
using UnityEngine;

public class CardsPile : MonoBehaviour
{
    public float height = 0.5f;
    public float width = 1f;
    [Range(0f, 90f)] public float maxCardAngle = 5f;
    public float yPerCard = -0.005f;
    public float zDistance;

    public Transform cardHolderPrefab;

    private readonly List<GameObject> cards = new List<GameObject>();

    public List<GameObject> Cards => new List<GameObject>(cards);

    public event Action<int> OnCountChanged;

    private readonly List<Transform> cardsHolders = new List<Transform>();

    private bool updatePositions;
    private readonly List<GameObject> forceSetPosition = new List<GameObject>();

    public void Add(GameObject card, bool moveAnimation = false) => Add(card, -1, moveAnimation);

    public void Add(GameObject card, int index, bool moveAnimation = false)
    {
        Transform cardHolder = GetCardHolder();

        if (index == -1)
        {
            cards.Add(card);
            cardsHolders.Add(cardHolder);
        }
        else
        {
            cards.Insert(index, card);
            cardsHolders.Insert(index, cardHolder);
        }

        updatePositions = true;

        if (!moveAnimation)
            forceSetPosition.Add(card);

        OnCountChanged?.Invoke(cards.Count);
    }

    public void Remove(GameObject card)
    {
        if (!cards.Contains(card))
            return;

        Transform cardHolder = cardsHolders[cards.IndexOf(card)];
        cardsHolders.Remove(cardHolder);
        Destroy(cardHolder.gameObject);

        cards.Remove(card);
        card.transform.SetParent(null);
        updatePositions = true;

        OnCountChanged?.Invoke(cards.Count);
    }

    Transform GetCardHolder()
    {
        Transform cardHolder = Instantiate(cardHolderPrefab, transform, false);
        return cardHolder;
    }

    void UpdatePositions()
{
    Vector3 targetPosition = new Vector3(4.72f, -37.47f, 41.12f);
    Vector3 targetRotation = new Vector3(86.42f, 267.59f, 87.93f);

    float cardSpacing = 0.75f; // Adjust this for the spacing between the cards
    float cardScale = 0.32f;   // Scale down the cards

    for (int i = 0; i < cards.Count; i++)
    {
        // Calculate the position for each card based on its index
        Vector3 cardPosition = targetPosition + new Vector3((i - (cards.Count - 1) / 2f) * cardSpacing, 0, 0);

        // Set the position and rotation of each card holder
        cardsHolders[i].transform.position = cardPosition;

        // Set the rotation to match the target rotation
        cardsHolders[i].transform.rotation = Quaternion.Euler(targetRotation);

        // Adjust the card itself
        cards[i].transform.SetParent(cardsHolders[i].transform, true);
        cards[i].transform.localPosition = Vector3.zero;
        cards[i].transform.localRotation = Quaternion.identity;
        cards[i].transform.localScale = Vector3.one * cardScale;
    }
}
    void LateUpdate()
    {
        if (updatePositions)
        {
            updatePositions = false;
            UpdatePositions();
        }
    }

    void OnValidate()
    {
        updatePositions = true;
    }
}