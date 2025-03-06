using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed;

    public enum RotationAxis
    {
        XAxis,
        YAxis,
        ZAxis
    }

    public RotationAxis rotationAxis = RotationAxis.YAxis;

    private Vector3 axis;

    void Start()
    {
        SetRotationAxis();
    }

    void Update()
    {
        transform.Rotate(axis * rotationSpeed * Time.deltaTime);
    }

    void SetRotationAxis()
    {
        switch (rotationAxis)
        {
            case RotationAxis.XAxis:
                axis = Vector3.right;
                break;
            case RotationAxis.YAxis:
                axis = Vector3.up;
                break;
            case RotationAxis.ZAxis:
                axis = Vector3.forward;
                break;
        }
    }
}