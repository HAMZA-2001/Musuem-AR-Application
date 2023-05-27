using UnityEngine;

public class SpatializedAudio : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = 1.0f;
    [SerializeField] private LayerMask occlusionMask;
    [SerializeField] private float occlusionFactor = 0.5f;

    private AudioSource audioSource;
    private Transform playerTransform;
    private float initialVolume;

    private void Start()
    {
        playerTransform = Camera.main.transform;
        CreateAudioSource();
    }

    private void CreateAudioSource()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.spatialBlend = 1.0f; // Set the spatial blend to fully 3D
        audioSource.volume = volume;
        initialVolume = volume;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        HandleOcclusion();
    }

    private void HandleOcclusion()
    {
        RaycastHit hit;
        Vector3 direction = playerTransform.position - transform.position;
        float distance = direction.magnitude;

        if (Physics.Raycast(transform.position, direction, out hit, distance, occlusionMask))
        {
            // If there's an obstacle, reduce the volume by the occlusion factor
            audioSource.volume = initialVolume * occlusionFactor;
        }
        else
        {
            // If there's no obstacle, set the volume back to the initial value
            audioSource.volume = initialVolume;
        }
    }
}