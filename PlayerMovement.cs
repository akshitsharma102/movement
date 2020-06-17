using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed, jumpforce;
    private float MoveInput;


    private Rigidbody2D rb2d;
    private Animator anim;


    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool facingRight;
    private bool grounded;

    public Vector3 range;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();
        CheckCollissionForJump();
    }

    void Movement()
    {
        MoveInput = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (anim.GetBool("Punch")) MoveInput = 0;

        anim.SetFloat("Speed", Mathf.Abs(MoveInput));

        rb2d.velocity = new Vector2(MoveInput, rb2d.velocity.y);

        if(MoveInput > 0 && facingRight || MoveInput < 0 && !facingRight)
        {
            flip();
        }
        if(rb2d.velocity.y < 0)
        {
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }
    }

    void CheckCollissionForJump()
    {
        Collider2D bottomHit = Physics2D.OverlapBox(groundCheck.position, range, 0, groundLayer);

        if(bottomHit != null)
        {
            if(bottomHit.gameObject.tag == "ground" && Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
                anim.SetBool("Jump", true);
            }
            else
            {
                anim.SetBool("Jump", false);
            }
        }
    }


    void flip ()
    {
        facingRight = !facingRight;
        Vector2 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;

    }
}
