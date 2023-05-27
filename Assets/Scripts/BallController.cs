using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    private Vector3 startScreenPoint;
    private Vector3 endScreenPoint;
    public float throwForce = 300f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startScreenPoint = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endScreenPoint = Input.mousePosition;
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        Vector3 direction = (startScreenPoint - endScreenPoint).normalized;
        rb.AddForce(new Vector3(direction.x, 0, direction.y) * throwForce);
        Invoke("ResetBall", 3);
    }

    void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
