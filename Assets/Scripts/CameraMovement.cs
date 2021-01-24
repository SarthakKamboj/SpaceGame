using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float horizontal, vertical;
    float mouseX, mouseY;
    [SerializeField]
    void LateUpdate() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        Vector3 pos = transform.position;
        pos += transform.forward * vertical;
        pos += transform.right * horizontal;
        transform.position = pos;
    }
}
