using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;

    float jumpHeight = 4.0f;
    float movementSpeed = 4.0f;
    float osX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Horizontal
        osX = Input.GetAxisRaw("Horizontal");
        // Debug.Log(osX);
        rb2d.velocity = new Vector2(osX * movementSpeed, rb2d.velocity.y); //4.0f -> movementSpeed

        if (Input.GetButton("Jump")) // Input.GetKeyDown("space")
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector3(0, 2, 0);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight); // 0 -> rb2d.velocity.x
            //Debug.Log("spacja kliknieta");
        }

        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if (osX > 0 || osX < 0) // osX > 0 bieg w prawo; osX < 0 bieg w lewo
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
