using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarChange : MonoBehaviour
{
    public Image fillImage;
    public PuzzleManager manager;
    public string ionType = "Sodium";

    public float chargeSpeed = 0.5f;
    public float dischargeSpeed = 0.5f;

    private int ionCount = 0;
    private float currentCharge = 0f;

    public int IonCount => ionCount;  // Expose this to manager

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ionType)) ionCount++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(ionType)) ionCount = Mathf.Max(ionCount - 1, 0);
    }

    private void Update()
    {
        int requiredThreshold = (ionType == "Sodium") ? manager.requiredSodium : manager.requiredPotassium;
        float targetCharge = Mathf.Clamp01((float)ionCount / requiredThreshold);

        currentCharge = Mathf.MoveTowards(currentCharge, targetCharge, 
            (currentCharge < targetCharge ? chargeSpeed : dischargeSpeed) * Time.deltaTime);

        if (fillImage != null) fillImage.fillAmount = currentCharge;
    }
}
