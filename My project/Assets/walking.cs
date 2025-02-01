using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float speed = 200f;

    private Vector2 direction;
    private Rigidbody2D rb;
    private float changeDirectionTime = 1f;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void ChangeDirection()
    {
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0: direction = Vector2.up; break;
            case 1: direction = Vector2.down; break;
            case 2: direction = Vector2.left; break;
            case 3: direction = Vector2.right; break;
        }
    }

    // Reverses direction when colliding with an object
    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction; // Reverse direction
    }

    // Works if the object uses "Is Trigger"
    void OnTriggerEnter2D(Collider2D other)
    {
        direction = -direction; // Reverse direction for trigger collisions
    }
}
