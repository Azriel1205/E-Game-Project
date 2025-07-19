using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public float knockbackForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(Vector2 fromPosition)
    {
        currentHealth--;
        Debug.Log("Player took damage! Current health: " + currentHealth);

        Vector2 knockbackDir = (transform.position - (Vector3)fromPosition).normalized;
        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);

        if (currentHealth <= 0)
        {
            Debug.Log("Player Dead");
            // Add your death logic here
        }
    }
}
