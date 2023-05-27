using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CupDetector2 : MonoBehaviour
{
    public bool ballInCup = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballInCup = true;
        }
    }
}
