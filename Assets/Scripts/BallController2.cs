using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BallController2 : MonoBehaviour
{
    public GameObject ballPrefab;
    private Rigidbody ballRigidbody;
    public float throwForce = 15f;

    void Start()
    {
        GameObject ballInstance = Instantiate(ballPrefab);
        ballRigidbody = ballInstance.GetComponent<Rigidbody>();
        ballRigidbody.useGravity = false; // Disable gravity at the start
    }

    void Update()
    {
        // Touch input for mobile devices
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ThrowBall();
        }
        // Mouse input for the editor or desktop builds
        else if (Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.useGravity = true; // Enable gravity when throwing the ball
        ballRigidbody.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
    }
}