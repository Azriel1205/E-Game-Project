using System.Collections;
using System.Collections.Generic;
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public TopDownCharacterController playerController;
    public GameObject attackArea;
    public float attackDuration = 0.2f;

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            Vector3 attackPos = Vector3.zero;
            float angle = 0f;

            switch (playerController.animator.GetInteger("Direction"))
            {
                case 0: // Down
                    attackPos = new Vector3(0, -0.6f, 0);
                    angle = 225f;
                    break;
                case 1: // Up
                    attackPos = new Vector3(0, 1.5f, 0);
                    angle = 45f;
                    break;
                case 2: // Right
                    attackPos = new Vector3(1, 0.2f, 0);
                    angle = 315f;
                    break;
                case 3: // Left
                    attackPos = new Vector3(-1, 0.2f, 0);
                    angle = 135f;
                    break;
            }

            attackArea.transform.localPosition = attackPos;

            attackArea.transform.rotation = Quaternion.Euler(0, 0, angle);
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        attackArea.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackArea.SetActive(false);
        isAttacking = false;
    }
}