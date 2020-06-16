using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed, jumpforce;
    private float MoveInput;


    private Rigidbody2D rb2d;


    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool facingRight;
    private bool grounded;

    public Vector3 range;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
        CheckCollissionForJump();
    }

    void Movement()
    {
        MoveInput = Input.GetAxisRaw("Horizontal") * runSpeed;
        rb2d.velocity = new Vector2(MoveInput, rb2d.velocity.y);

        if(MoveInput > 0 && facingRight || MoveInput < 0 && !facingRight)
        {
            flip();
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
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(groundCheck.position, range);
    }

    void flip ()
    {
        facingRight = !facingRight;
        Vector2 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;

    }
}
