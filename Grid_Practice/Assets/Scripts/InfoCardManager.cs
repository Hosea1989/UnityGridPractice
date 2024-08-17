using UnityEngine;
using UnityEngine.UI;

public class InfoCardManager : MonoBehaviour
{
    public GameObject infoCard;       // Reference to the info card UI Panel
    public Text infoText;             // Reference to the Text component displaying the tile information
    public Text locationText;         // Reference to the Text component displaying the tile location

    void Start()
    {
        // Initially hide the info card
        infoCard.SetActive(false);
    }

    public void ShowInfo(string info, Vector2Int location)
    {
        // Update the text with tile information
        infoText.text = info;
        locationText.text = location.x + ", " + location.y;

        // Show the info card
        infoCard.SetActive(true);
    }

    public void HideInfo()
    {
        // Hide the info card
        infoCard.SetActive(false);
    }
}