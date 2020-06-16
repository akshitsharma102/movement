using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    private float MoveInput;

    private Rigidbody2D rb2d;
    private bool facingRight;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
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

    void flip ()
    {
        facingRight = !facingRight;
        Vector2 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;

    }
}
