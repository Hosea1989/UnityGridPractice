using UnityEngine;
using UnityEditor;

public class CardCreator : EditorWindow
{
    private string cardNamePrefix = "Card_";
    private int numberOfCards = 10;
    private int minAttackPower = 1;
    private int maxAttackPower = 10;
    private int minDefensePower = 1;
    private int maxDefensePower = 10;

    [MenuItem("Custom Tools/Card Creator")]
    public static void ShowWindow()
    {
        GetWindow<CardCreator>("Card Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Card Generator", EditorStyles.boldLabel);

        cardNamePrefix = EditorGUILayout.TextField("Card Name Prefix", cardNamePrefix);
        numberOfCards = EditorGUILayout.IntField("Number of Cards", numberOfCards);
        minAttackPower = EditorGUILayout.IntField("Min Attack Power", minAttackPower);
        maxAttackPower = EditorGUILayout.IntField("Max Attack Power", maxAttackPower);
        minDefensePower = EditorGUILayout.IntField("Min Defense Power", minDefensePower);
        maxDefensePower = EditorGUILayout.IntField("Max Defense Power", maxDefensePower);

        if (GUILayout.Button("Create Cards"))
        {
            CreateCards();
        }
    }

    private void CreateCards()
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            Card newCard = CreateInstance<Card>();
            newCard.cardName = cardNamePrefix + i;
            newCard.damage = Random.Range(minAttackPower, maxAttackPower);
            newCard.health = Random.Range(minDefensePower, maxDefensePower);

            string path = $"Assets/Cards/{newCard.cardName}.asset";
            AssetDatabase.CreateAsset(newCard, path);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}