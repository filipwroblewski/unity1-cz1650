using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float jumpHeight = 4.0f;
    //float movementSpeed = 4.0f;
    Rigidbody2D rb2d;
    float osX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal
        osX = Input.GetAxisRaw("Horizontal");
        Debug.Log(osX);
        rb2d.velocity = new Vector2(osX * 4.0f, rb2d.velocity.y);



        if (Input.GetButton("Jump")) // Input.GetKeyDown("space")
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector3(0, 2, 0);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight); // 0 -> rb2d.velocity.x
            //Debug.Log("spacja kliknieta");
        }
    }
}
