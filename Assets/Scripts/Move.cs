﻿using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector3 offset = new Vector3(2f,2f,2f);

    private Vector3 mouseOffset;
    private float gOScreenZ;
    private Vector3 prevPos;
    private Vector3 curPos;
    private float radius;

    void OnMouseDown() {
        gOScreenZ = Camera.main.WorldToScreenPoint(transform.position).z;
        mouseOffset = transform.position - GetWorldMousePos();
        prevPos = transform.position;
        SelectedObject.SelectedGO = gameObject;
        radius = GetMaxVal(GetComponent<Renderer>().bounds.extents);
        OffsetY(-1f);
    }

    float GetMaxVal(Vector3 v) {
        return Mathf.Max(Mathf.Max(v.x, v.y),v.z);
    }

    void OnMouseUp() {
        OffsetY(1f);
    }

    void OnMouseDrag() {
        curPos = GetWorldMousePos() + mouseOffset;

        if (GameAreaBounds.bounds.Contains(curPos) && !CurPosNearBoundary()) {
            Vector3 pos = transform.position;

            UpdatePosX(ref pos);
            UpdatePosZ(ref pos);

            transform.position = pos;
            gOScreenZ = Camera.main.WorldToScreenPoint(transform.position).z;
        }
    }

    bool CurPosNearBoundary() {
        bool hit = false;
        Vector3[] dirs = new Vector3[] {Vector3.forward, -Vector3.forward, Vector3.right, -Vector3.right};
        foreach(Vector3 dir in dirs) {
            hit = hit || Physics.Raycast(curPos, dir, radius * 1.1f);
        }
        return hit;
    }

    void UpdatePosX(ref Vector3 pos) {
        pos.x = curPos.x;
        prevPos.x = curPos.x;
    }

    void UpdatePosZ(ref Vector3 pos) {
        pos.z = curPos.z;
        prevPos.z = curPos.z;
    }

    bool MouseMovedOverTileX() {
        return Mathf.Abs(curPos.x - prevPos.x) >= 1f;
    }

    bool MouseMovedOverTileZ() {
        return Mathf.Abs(curPos.z - prevPos.z) >= 1f;
    }

    Vector3 GetWorldMousePos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = gOScreenZ;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OffsetY(float offset) {
        Vector3 pos = transform.position;
        pos.y -= offset;
        transform.position = pos;
    }

}