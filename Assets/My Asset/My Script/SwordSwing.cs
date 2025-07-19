using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    public GameObject swordObject;
    public float swingSpeed = 360f; // Degrees per second
    public float swingDuration = 0.3f;

    private bool isSwinging = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isSwinging)
        {
            StartCoroutine(Swing());
        }
    }

    IEnumerator Swing()
    {
        isSwinging = true;
        swordObject.SetActive(true);

        float elapsed = 0f;
        while (elapsed < swingDuration)
        {
            swordObject.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(-90, 90, elapsed / swingDuration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        swordObject.SetActive(false);
        swordObject.transform.localRotation = Quaternion.identity;
        isSwinging = false;
    }
}
