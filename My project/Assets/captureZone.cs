using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaptureZone : MonoBehaviour
{
    public int playerID; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cow"))
        {
            Debug.Log("COW ENTERS ZONE 1");
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

