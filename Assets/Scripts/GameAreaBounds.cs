using System.Collections;
using UnityEngine;

public class GameAreaBounds : MonoBehaviour
{
    public static Bounds bounds;
    void Start() {
        StartCoroutine(CalcGameBounds());
    }

    IEnumerator CalcGameBounds() {
        yield return new WaitForSeconds(1f);
        Bounds floorBounds = gameObject.GetComponent<Renderer>().bounds;
        Bounds boundaryBounds = transform.GetChild(0).GetComponent<Renderer>().bounds;

        Vector3 maxCenter = GetMaxVec(floorBounds.center, boundaryBounds.center);
        Vector3 maxSize = GetMaxVec(floorBounds.size, boundaryBounds.size);

        bounds = new Bounds(maxCenter, maxSize);
    }

    Vector3 GetMaxVec(Vector3 v1, Vector3 v2) {
        return new Vector3(Mathf.Max(v1.x, v2.x), Mathf.Max(v1.y, v2.y), Mathf.Max(v1.z, v2.z));
    }

}
