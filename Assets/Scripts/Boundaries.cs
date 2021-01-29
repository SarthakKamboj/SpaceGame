using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public float boundaryWidth = 0.1f;
    public static float minX, maxX, minZ, maxZ;

    void Start() {
        AddBoundaries();
    }

    void AddBoundaries() {
        BottomBoundary();
        TopBoundary();
        LeftBoundary();
        RightBoundary();
    }

    void BottomBoundary() {
        GameObject bottomBoundary = InstantiateBoundary("Bottom Boundary");
        MoveBoundaryY(ref bottomBoundary);
        Vector3 size = bottomBoundary.GetComponent<Renderer>().bounds.size;
        bottomBoundary.transform.localScale = new Vector3(1f, bottomBoundary.transform.localScale.y, boundaryWidth / size.z);
        MoveBoundaryZ(ref bottomBoundary, -1);
        minZ = bottomBoundary.transform.position.z + boundaryWidth;
    }

    void TopBoundary() {
        GameObject topBoundary = InstantiateBoundary("Top Boundary");
        MoveBoundaryY(ref topBoundary);
        Vector3 size = topBoundary.GetComponent<Renderer>().bounds.size;
        topBoundary.transform.localScale = new Vector3(1f, topBoundary.transform.localScale.y , boundaryWidth / size.z);
        MoveBoundaryZ(ref topBoundary, 1);
        maxZ = topBoundary.transform.position.z - boundaryWidth;
    }

    void LeftBoundary() {
        GameObject leftBoundary = InstantiateBoundary("Left Boundary");
        MoveBoundaryY(ref leftBoundary);
        Vector3 size = leftBoundary.GetComponent<Renderer>().bounds.size;
        leftBoundary.transform.localScale = new Vector3(boundaryWidth / size.x, leftBoundary.transform.localScale.y, 1f);
        MoveBoundaryX(ref leftBoundary, -1);
        minX = leftBoundary.transform.position.x + boundaryWidth;
    }

    void RightBoundary() {
        GameObject rightBoundary = InstantiateBoundary("Right Boundary");
        MoveBoundaryY(ref rightBoundary);
        Vector3 size = rightBoundary.GetComponent<Renderer>().bounds.size;
        rightBoundary.transform.localScale = new Vector3(boundaryWidth / size.x, rightBoundary.transform.localScale.y, 1f);
        MoveBoundaryX(ref rightBoundary, 1);
        maxX = rightBoundary.transform.position.x - boundaryWidth;
    }

    GameObject InstantiateBoundary(string name) {
        GameObject boundary = GameObject.CreatePrimitive(PrimitiveType.Cube);
        boundary.name = name;
        boundary.transform.SetParent(transform, false);
        boundary.AddComponent<BoxCollider>();
        return boundary;
    }

    void MoveBoundaryX(ref GameObject boundary, float multiplier) {
        Vector3 pos = boundary.transform.position;
        Vector3 extents = GetComponent<Renderer>().bounds.extents;
        pos.x += extents.x * multiplier;
        boundary.transform.position = pos;
    }

    void MoveBoundaryZ(ref GameObject boundary, float multiplier) {
        Vector3 pos = boundary.transform.position;
        Vector3 extents = GetComponent<Renderer>().bounds.extents;
        pos.z += extents.z * multiplier;
        boundary.transform.position = pos;
    }

    void MoveBoundaryY(ref GameObject boundary) {

        Renderer renderer = boundary.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;

        boundary.transform.localScale = new Vector3(1f,50f / size.y,1f);

        Vector3 pos = boundary.transform.position;
        Vector3 extents = renderer.bounds.extents;
        pos.y += extents.y;
        boundary.transform.position = pos;
   
    }
}
