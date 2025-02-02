using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public string inputPrefix = "Player1";
    public GameObject abilityPrefab;
    public float abilitySpeed = 7f;
    public float abilityCooldown = 2f;
    private bool canUseAbility = true;
    private PlayerMovementController playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        if (Input.GetButtonDown(inputPrefix + "_Ability") && canUseAbility)
        {
            UseAbility();
        }
    }

    void UseAbility()
    {
        Vector2 direction = playerMovement.GetLastDirection();

        if (direction == Vector2.zero)
        {
            Debug.LogWarning("Direction is zero, check player movement.");
        }
        GameObject ability = Instantiate(abilityPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rbAbility = ability.GetComponentInChildren<Rigidbody2D>();
        if (rbAbility != null)
        {
            rbAbility.velocity = direction * abilitySpeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D not found on the flashbang's capsule child.");
        }
        canUseAbility = false;
        Invoke(nameof(ResetAbility), abilityCooldown);
    }

    void ResetAbility()
    {
        canUseAbility = true;
    }
}
