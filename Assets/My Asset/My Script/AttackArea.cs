using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SlimeEnemy slime = collision.GetComponent<SlimeEnemy>();
        if (slime != null)
        {
            slime.TakeDamage(1);
        }
    }
}
