using UnityEngine;

public class ZoomController : MonoBehaviour {

    private Vector3 cameraPosition;
    private Vector3 objectScale;

    void Start() {
        cameraPosition = Camera.current.transform.position;
        objectScale = transform.localScale;
    }

    void Update() {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f) {
            float zoomSpeed = 2f;
            objectScale += Vector3.one * scroll * zoomSpeed;
            objectScale = Vector3.Max(new Vector3(0.1f, 0.1f, 0.1f), Vector3.Min(objectScale, new Vector3(5f, 5f, 5f)));
            transform.localScale = objectScale;

            float cameraDistance = 5f;
            cameraPosition.z = -cameraDistance * objectScale.x;
            Camera.current.transform.position = cameraPosition;
        }
    }
}