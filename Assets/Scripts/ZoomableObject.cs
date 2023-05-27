using UnityEngine;

public class ZoomableObject : MonoBehaviour
{
    private Vector3 cameraPosition;
    private Vector3 objectScale;
    private float pinchZoomSpeed = 0.1f;

    void Start()
    {
        cameraPosition = Camera.current.transform.position;
        objectScale = transform.localScale;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            // If there are two touches on the screen, zoom in or out
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPreviousPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePreviousPosition = touchOne.position - touchOne.deltaPosition;

            float previousTouchDeltaMagnitude = (touchZeroPreviousPosition - touchOnePreviousPosition).magnitude;
            float touchDeltaMagnitude = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = previousTouchDeltaMagnitude - touchDeltaMagnitude;

            objectScale += Vector3.one * deltaMagnitudeDiff * pinchZoomSpeed * 0.5f;
            objectScale = Vector3.Max(new Vector3(0.1f, 0.1f, 0.1f), Vector3.Min(objectScale, new Vector3(5f, 5f, 5f)));

            cameraPosition.z = -5f * objectScale.x;
            Camera.current.transform.position = cameraPosition;

            transform.localScale = objectScale;
        }
    }
}