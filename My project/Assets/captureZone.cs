using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Cow"))
        {
            CaptureCow(other.gameObject);
        }
    }

    private void CaptureCow(GameObject cow)
    {
        
        GameManager.Instance.AddScore(1);

        AudioManager.Instance.PlaySound("cow_captured");

        Destroy(cow);
    }
}
