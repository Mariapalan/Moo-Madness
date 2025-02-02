using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public string inputPrefix = "Player1";
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.right; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw(inputPrefix + "_Horizontal");
        moveInput.y = Input.GetAxisRaw(inputPrefix + "_Vertical");

        if (moveInput.magnitude > 1)
        {
            moveInput.Normalize();
        }

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public Vector2 GetLastDirection()
    {
        return lastMoveDirection;
    }
}
