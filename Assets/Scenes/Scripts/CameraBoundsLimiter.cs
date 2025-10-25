using UnityEngine;

public class CameraBoundsLimiter : MonoBehaviour
{
    private Camera cam;
    private float halfHeight, halfWidth;

    void Start()
    {
        cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        // Clamp to camera bounds
        pos.x = Mathf.Clamp(pos.x, cam.transform.position.x - halfWidth, cam.transform.position.x + halfWidth);
        pos.y = Mathf.Clamp(pos.y, cam.transform.position.y - halfHeight, cam.transform.position.y + halfHeight);

        transform.position = pos;
    }
}
