using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float speed = 200f;

    public bool isLassoed;
    private Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float changeDirectionTime = 1f;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        RotateSprite();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            ImmediateDirectionChange();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fence"))
        {
            ImmediateDirectionChange();
        }
    }

    // Instantly change direction upon collision
    void ImmediateDirectionChange()
    {
        timer = 0f; // Reset the timer for smooth behavior
        ChangeDirection(); // Pick a new direction immediately
    }

    // Rotates the sprite based on movement direction
    void RotateSprite()
    {
        if (direction == Vector2.up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);  // Face Up
        }
        else if (direction == Vector2.down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90); // Face Down
        }
        else if (direction == Vector2.left)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180); // Face Left
        }
        else if (direction == Vector2.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);   // Face Right
        }
    }
}
