using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : MonoBehaviour
{
    private Rigidbody2D mybody;
    public float moveSpeed;
    public float minX, maxX;
    public float distance;
    public int direction;

    private bool patrol;

    private Transform playerpos;
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        playerpos = GameObject.Find("Player").transform;
    }

    void Start()
    {
        maxX = transform.position.x + (distance / 2);
        minX = maxX - distance;

        if (Random.value > 0.5) distance = 1;
        else distance = -1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerpos.position) <= 1.5f) patrol = false;
        else patrol = true;
    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case -1:
                if (transform.position.x > minX)
                    mybody.velocity = new Vector2(-moveSpeed, mybody.velocity.y);
                else
                    direction = 1;
                break;
            case 1:
                if (transform.position.x < maxX)
                    mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
                else
                    direction = -1;
                break;
        }
    }
}
