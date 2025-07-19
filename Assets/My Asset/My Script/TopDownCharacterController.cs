using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public bool facingRight = true; // Track facing direction
        public float speed;

        public Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            // Support both keyboard and controller input
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(x, y);

            // Optional override to make keyboard more responsive if pressed
            if (Input.GetKey(KeyCode.A)) dir.x = -1;
            if (Input.GetKey(KeyCode.D)) dir.x = 1;
            if (Input.GetKey(KeyCode.W)) dir.y = 1;
            if (Input.GetKey(KeyCode.S)) dir.y = -1;

            // Determine direction for animation (same logic as before)
            if (dir.magnitude > 0.01f)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                {
                    animator.SetInteger("Direction", dir.x > 0 ? 2 : 3); // Right / Left
                }
                else
                {
                    animator.SetInteger("Direction", dir.y > 0 ? 1 : 0); // Up / Down
                }
            }

            if (x > 0)
            {
                facingRight = true;
            }
            else if (x < 0)
            {
                facingRight = false;
            }   

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0.01f);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
