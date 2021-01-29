using UnityEngine;

public class RotateOnInstantiation : MonoBehaviour
{
    public float rotationAngleY = 180f;

    void Start() {
        transform.Rotate(new Vector3(0f,rotationAngleY,0f));
    }

    void Update() {
            
    }
}
