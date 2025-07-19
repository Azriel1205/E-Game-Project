using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public Camera mainCamera;

    public string joystickHorizontal = "Horizontal";
    public string joystickVertical = "Vertical";

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 aimDirection = GetAimDirection();

        if (aimDirection == Vector2.zero)
        {
            return; // No aim direction, do not shoot
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = aimDirection * projectileSpeed;

        projectile.transform.right = aimDirection; // Makes sprite face direction (if needed)
    }

    Vector2 GetAimDirection()
    {
        float joystickX = Input.GetAxis(joystickHorizontal);
        float joystickY = Input.GetAxis(joystickVertical);

        Vector2 joystickDir = new Vector2(joystickX, joystickY).normalized;

        if (joystickDir.magnitude > 0.1f)
        {
            return joystickDir.normalized;
        }

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDir = (mousePos - firePoint.position);
        return mouseDir.normalized;
    }
}