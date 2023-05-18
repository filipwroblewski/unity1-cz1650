using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer sprite;
    BoxCollider2D coll;

    
    enum MovementState { 
        idle, 
        running, 
        jumping, 
        falling 
    }
    

    [SerializeField] LayerMask layerToJump;

    [SerializeField] float jumpHeight = 4.0f;
    [SerializeField] float movementSpeed = 4.0f;
    float osX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // ruch prawo lewo
        osX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(osX * movementSpeed, rb2d.velocity.y);

        // skok
        if (Input.GetButton("Jump") && isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
        }

        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        MovementState state;

        if (osX > 0) // osX > 0 bieg w prawo
        {
            state = MovementState.running; //anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (osX < 0) // osX < 0 bieg w lewo
        {
            state = MovementState.running; //anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle; // anim.SetBool("running", false);
        }

        if (rb2d.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }else if(rb2d.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    bool isGrounded()
    {
        bool result = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, layerToJump);
        
        return result;
    }

}
