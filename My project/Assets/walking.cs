using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float speed = 200f;
    public AudioClip cowSound;

    public bool isLassoed;
    private Vector2 direction;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private float changeDirectionTime = 1f;
    private float timer;

    private float mooTimer;
    private float nextMooTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0;
        audioSource.volume = 0.7f;

        ChangeDirection();
        mooTimer = Random.Range(0f, 3f);  // Randomize initial moo
        SetNextMooTime(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        mooTimer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0f;
        }

        if (mooTimer >= nextMooTime && MooManager.Instance.CanMoo() && !audioSource.isPlaying)
        {
            PlayCowSound();
            SetNextMooTime();
            MooManager.Instance.TriggerMooCooldown();
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

    void PlayCowSound()
    {
        if (audioSource != null && cowSound != null)
        {
            audioSource.PlayOneShot(cowSound);
            Debug.Log("Moo from " + gameObject.name);
        }
    }

    void SetNextMooTime(bool initialDelay = false)
    {
        mooTimer = 0f;
        nextMooTime = initialDelay ? Random.Range(10f, 15f) : Random.Range(12f, 20f);
    }
}
