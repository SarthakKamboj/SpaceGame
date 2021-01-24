using UnityEngine;

public class FloorGrid : MonoBehaviour
{

    public Vector2 gridDim;
    [HideInInspector]
    public Vector2 gridSize;
    
    private Collider floorCollider;

    void Start() {
        Rescale();
    }
    
    void Rescale() {
        Vector3 scale = transform.localScale;
        scale.x = gridDim.x;
        scale.z = gridDim.y;
        transform.localScale = scale;
    }


}
