using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed; // 회전 속도

    public enum RotationAxis // 회전 축
    {
        XAxis,
        YAxis,
        ZAxis
    }

    public RotationAxis rotationAxis = RotationAxis.YAxis; // 회전 축 기본값

    private Vector3 axis; // 회전 방향

    void Start()
    {
        SetRotationAxis();
    }

    void Update()
    {
        transform.Rotate(axis * rotationSpeed * Time.deltaTime); // 회전 호출
    }

    void SetRotationAxis()
    {
        switch (rotationAxis)
        {
            case RotationAxis.XAxis: // X축 회전
                axis = Vector3.right;
                break;
            case RotationAxis.YAxis: // Y축 회전
                axis = Vector3.up;
                break;
            case RotationAxis.ZAxis: // Z축 회전
                axis = Vector3.forward;
                break;
        }
    }
}