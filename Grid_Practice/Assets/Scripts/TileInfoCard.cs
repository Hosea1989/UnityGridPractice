using UnityEngine;
using TMPro;

public class TileInfoCard : MonoBehaviour
{
    public GameObject infoCardPanel;    // Reference to the Info Card Panel
    public TextMeshProUGUI tileTypeText; // Reference to the TextMeshPro component for TileType
    public TextMeshProUGUI locationText; // Reference to the TextMeshPro component for Location

    void Start()
    {
        infoCardPanel.SetActive(false);  // Hide the info card at the start
    }

    public void UpdateInfoCard(string tileType, Vector3 location)
    {
        // Update the text with the provided tile type and location
        tileTypeText.text = tileType;
        locationText.text = location.ToString();

        // Show the info card
        infoCardPanel.SetActive(true);
    }

    public void HideInfoCard()
    {
        // Hide the info card
        infoCardPanel.SetActive(false);
    }
}