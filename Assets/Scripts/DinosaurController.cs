using UnityEngine;

public class DinosaurController : MonoBehaviour
{
    public Transform target; // The player's position
    public float moveSpeed = 1.0f; // The speed at which the dinosaur moves
    public float stoppingDistance = 2.0f; // The distance at which the dinosaur stops moving
    private Animator animator; // The animator component for the dinosaur
    private bool isWalking = false; // Flag to check if the dinosaur is currently walking

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            isWalking = true;
            animator.SetBool("isWalking", true);
            transform.LookAt(target);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            isWalking = false;
            animator.SetBool("isWalking", false);
        }
    }
}