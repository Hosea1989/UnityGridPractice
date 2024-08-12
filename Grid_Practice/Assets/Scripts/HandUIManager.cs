using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUIManager : MonoBehaviour
{
    public GameObject cardUIPrefab;
    public Transform handUIParent;
    private List<GameObject> cardUIElements = new List<GameObject>();

    public void AddCardToHand(Card card)
    {
        GameObject cardUI = Instantiate(cardUIPrefab, handUIParent);
        cardUI.transform.Find("CardNameText").GetComponent<UnityEngine.UI.Text>().text = card.cardName;
        cardUI.transform.Find("CardArtworkImage").GetComponent<UnityEngine.UI.Image>().sprite = card.cardArtwork;
        cardUI.transform.Find("CardCostText").GetComponent<UnityEngine.UI.Text>().text = card.cost.ToString();
        cardUIElements.Add(cardUI);
    }

    public void RemoveCardFromHand(int cardIndex)
    {
        if (cardIndex >= 0 && cardIndex < cardUIElements.Count)
        {
            Destroy(cardUIElements[cardIndex]);
            cardUIElements.RemoveAt(cardIndex);
        }
        else
        {
            Debug.LogWarning("Attempted to remove a card at an invalid index: " + cardIndex);
        }
    }
}
