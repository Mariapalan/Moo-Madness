using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementController: MonoBehaviour
{
    public string inputPrefix = "Player1";
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Use the input prefix to get controls dynamically
        moveInput.x = Input.GetAxisRaw(inputPrefix + "_Horizontal");
        moveInput.y = Input.GetAxisRaw(inputPrefix + "_Vertical");

        if (moveInput.magnitude > 1){
            moveInput.Normalize();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}

