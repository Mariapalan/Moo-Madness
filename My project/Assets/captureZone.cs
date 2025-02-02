using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaptureZone : MonoBehaviour
{
    public int playerID; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cow")) // Ensure it's a cow
        {
            Cow cowScript = other.GetComponent<Cow>();

            if (cowScript != null && !(cowScript.isLassoed)) // Check if lassoed
            {
                Debug.Log("Lassoed cow captured!");
                GameManager.Instance.CaptureCow(cowScript.capturedByPlayerID); 
                Destroy(other.gameObject); // Remove the cow
            }
            else
            {
                Debug.Log("Cow is not lassoed! Ignored.");
            }
        }   
    }

    /*private void CaptureCow(GameObject cow)
    {
        GameManager.Instance.AddScore(playerID, 1);
        
        //AudioManager.Instance.PlaySound("cow_captured");
        Destroy(cow);
    }*/

}

