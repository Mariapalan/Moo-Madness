using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
    public int playerID; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cow"))
        {
            CaptureCow(other.gameObject);
        }
    }

    private void CaptureCow(GameObject cow)
    {
    
        gameManager.Instance.AddScore(playerID, 1);

        //AudioManager.Instance.PlaySound("cow_captured");

        Destroy(cow);
    }
}

