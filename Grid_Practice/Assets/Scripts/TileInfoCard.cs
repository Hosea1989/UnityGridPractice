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
        // Convert the location from Vector3 (float) to Vector3Int (int)
        Vector3Int locationInt = new Vector3Int(
            Mathf.RoundToInt(location.x),
            Mathf.RoundToInt(location.y),
            Mathf.RoundToInt(location.z)
        );

        // Update the text with the provided tile type and integer location
        tileTypeText.text = tileType;
        locationText.text = locationInt.ToString(); // Converts Vector3Int to a string

        // Show the info card
        infoCardPanel.SetActive(true);
    }

    public void HideInfoCard()
    {
        // Hide the info card
        infoCardPanel.SetActive(false);
    }
}