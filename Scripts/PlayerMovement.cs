using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer sprite;

    [SerializeField] float jumpHeight = 4.0f;
    [SerializeField] float movementSpeed = 4.0f;
    float osX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Horizontal
        osX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(osX * movementSpeed, rb2d.velocity.y);

        if (Input.GetButton("Jump"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
        }

        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if (osX > 0) // osX > 0 bieg w prawo
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (osX < 0) // osX < 0 bieg w lewo
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
