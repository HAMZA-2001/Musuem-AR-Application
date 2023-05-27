using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thresholdDistance = 5.0f; // The distance at which the dinosaur starts chasing the player
    private DinosaurController dinosaurController; // Reference to the DinosaurController script

    void Start()
    {
        GameObject dinosaurObject = GameObject.Find("Dinosaur");
        dinosaurController = dinosaurObject.GetComponent<DinosaurController>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, dinosaurController.transform.position);

        if (distance < thresholdDistance)
        {
            dinosaurController.target = transform;
        }
        else
        {
            dinosaurController.target = null;
        }
    }
}