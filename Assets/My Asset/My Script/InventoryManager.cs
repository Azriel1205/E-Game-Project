using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Dictionary<string, int> ionInventory = new Dictionary<string, int>();

    public TextMeshProUGUI sodiumText;
    public TextMeshProUGUI potassiumText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        // Initialize ions with 0 count
        ionInventory.Add("Sodium", 0);
        ionInventory.Add("Potassium", 0);

        UpdateUI();
    }

    public void AddIon(string ionName, int amount)
    {
        if (ionInventory.ContainsKey(ionName))
        {
            ionInventory[ionName] += amount;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        sodiumText.text = "Sodium: " + ionInventory["Sodium"];
        potassiumText.text = "Potassium: " + ionInventory["Potassium"];
    }
}
