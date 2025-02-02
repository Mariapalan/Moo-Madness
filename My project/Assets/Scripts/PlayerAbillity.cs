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
        GameObject ability = Instantiate(abilityPrefab, transform.position, Quaternion.identity);
        ability.GetComponent<Rigidbody2D>().velocity = direction * abilitySpeed;

        canUseAbility = false;
        Invoke(nameof(ResetAbility), abilityCooldown);
    }

    void ResetAbility()
    {
        canUseAbility = true;
    }
}
