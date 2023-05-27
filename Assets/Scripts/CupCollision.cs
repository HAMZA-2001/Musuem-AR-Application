using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCollision : MonoBehaviour
{
    public float ballInsideThreshold = 0.1f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            float ballYPosition = collision.gameObject.transform.position.y;
            if (ballYPosition - transform.position.y <= ballInsideThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
}
