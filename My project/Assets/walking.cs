using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float speed = 200f;
    public AudioClip cowSound; // 🎵 Cow sound clip

    private Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource; // 🎵 AudioSource for playing the sound
    private float changeDirectionTime = 1f;
    private float timer;

    // 🎵 Mooing variables
    private float mooTimer;
    private float nextMooTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        ChangeDirection();

        // 🎵 Set the first random moo time between 3 to 7 seconds
        SetNextMooTime();
    }

    void Update()
    {
        timer += Time.deltaTime;
        mooTimer += Time.deltaTime; // 🎵 Track time for mooing

        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0f;
        }

        // 🎵 Moo at random intervals
        if (mooTimer >= nextMooTime)
        {
            PlayCowSound();
            SetNextMooTime();
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

    void ImmediateDirectionChange()
    {
        timer = 0f;
        ChangeDirection();
    }

    void RotateSprite()
    {
        if (direction == Vector2.up)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (direction == Vector2.down)
            transform.rotation = Quaternion.Euler(0, 0, -90);
        else if (direction == Vector2.left)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (direction == Vector2.right)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // 🎵 Plays the cow sound
    void PlayCowSound()
    {
        if (audioSource != null && cowSound != null)
        {
            audioSource.PlayOneShot(cowSound);
        }
    }

    // 🎵 Sets the next random moo time between 3 to 7 seconds
    void SetNextMooTime()
    {
        mooTimer = 0f;
        nextMooTime = Random.Range(3f, 7f); // Random time interval
    }
}
