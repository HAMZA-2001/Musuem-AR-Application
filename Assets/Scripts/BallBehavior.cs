using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    //    private Rigidbody rb;
    //     public float forceMultiplier = 5.0f;

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     rb.useGravity = false;
    // }

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;

    //         if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
    //         {
    //             rb.useGravity = true;
    //             Vector3 forceDirection = (hit.point - Camera.main.transform.position).normalized;
    //             forceDirection.y = Mathf.Abs(forceDirection.y);
    //             rb.AddForce(forceDirection * forceMultiplier, ForceMode.Impulse);
    //         }
    //     }
    // }
private Vector3 startPosition;
private Rigidbody rb;
private bool isDragging = false;
private Camera mainCamera;
// public float forceMultiplier = 500f;
public float throwPower = 20f;
public float respawnTime = 3f; // Set the respawn time (in seconds)
    public float minRespawnHeight = -5f; // Set the minimum height for respawn
    void Start()
{
    rb = GetComponent<Rigidbody>();
    startPosition = transform.position;
    mainCamera = Camera.main;
    rb.useGravity = false;
}


void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    if (isDragging)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            Vector3 newBallPosition = new Vector3(hit.point.x, hit.point.y, startPosition.z);
            transform.position = newBallPosition;
        }
    }

    if (Input.GetMouseButtonUp(0) && isDragging)
    {
        isDragging = false;
        rb.useGravity = true;

        Vector3 throwDirection = (startPosition - transform.position).normalized;
        rb.AddForce(new Vector3(throwDirection.x, Mathf.Abs(throwDirection.y), throwDirection.z) * throwPower, ForceMode.Impulse);
    }

    CheckRespawn();
}

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(respawnTime);
        isDragging = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }

    void CheckRespawn()
    {
        if (!isDragging && transform.position.y < minRespawnHeight)
        {
            StartCoroutine(RespawnBall());
        }
    }
}