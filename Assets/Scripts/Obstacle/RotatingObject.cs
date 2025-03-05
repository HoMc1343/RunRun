using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 30f;  // 회전 속도

    // 회전 축을 선택할 수 있는 Enum 정의
    public enum RotationAxis
    {
        XAxis,
        YAxis,
        ZAxis
    }

    public RotationAxis rotationAxis = RotationAxis.YAxis;  // 기본적으로 Y축으로 설정

    private Vector3 axis;

    void Start()
    {
        // 시작 시 선택된 회전 축에 맞는 Vector3 값 설정
        SetRotationAxis();
    }

    void Update()
    {
        // 지정된 축을 기준으로 오브젝트 회전
        transform.Rotate(axis * rotationSpeed * Time.deltaTime);
    }

    // 회전 축을 선택한 Enum 값에 맞게 설정하는 함수
    void SetRotationAxis()
    {
        switch (rotationAxis)
        {
            case RotationAxis.XAxis:
                axis = Vector3.right;  // X축 기준 회전
                break;
            case RotationAxis.YAxis:
                axis = Vector3.up;  // Y축 기준 회전
                break;
            case RotationAxis.ZAxis:
                axis = Vector3.forward;  // Z축 기준 회전
                break;
        }
    }
}