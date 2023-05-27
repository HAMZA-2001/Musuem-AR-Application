using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CupDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Destroy the cup when the ball enters it
            Destroy(gameObject);
        }
    }
}