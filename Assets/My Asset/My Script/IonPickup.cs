using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonPickup : MonoBehaviour
{
    public string ionType; // Example: "Sodium" or "Potassium"
    public int amount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddIon(ionType, amount);
            Destroy(gameObject);
        }
    }
}
