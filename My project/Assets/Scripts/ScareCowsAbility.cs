using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCowsAbility : MonoBehaviour
{
    public float scareRadius = 1f;
    public float scareForce = 5f;
    public LayerMask cowLayer = 1 << 6; 
    public float lifespan = 2f;

    private Rigidbody2D rb; // Rigidbody2D of the flashbang

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on flashbang.");
        }

        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        // Continuously scare cows as the flashbang moves
        ScareCows();
    }

    void ScareCows()
    {
        // OverlapCircleAll checks for cows in the scare radius
        Collider2D[] cows = Physics2D.OverlapCircleAll(transform.position, scareRadius, cowLayer);

        foreach (Collider2D cow in cows)
        {
            Rigidbody2D cowRb = cow.GetComponent<Rigidbody2D>();
            if (cowRb != null)
            {
                // Calculate the direction to push the cow away
                Vector2 direction = (cow.transform.position - transform.position).normalized;
                cowRb.AddForce(direction * scareForce, ForceMode2D.Impulse); // Apply a force to scare the cows
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the flashbang when it collides with the fence
        if (other.CompareTag("Fence"))
        {
            Destroy(gameObject); // Destroy ability on fence hit
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the scare radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scareRadius);
    }
}
