using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Renderer arrowRenderer; // 화살표 랜더러
    private float lightingArrow = 1f; // 발광 강도
    private bool lighting = true; // 발광
    private float lightingSpeed = 2f; // 발광 속도

    void Start()
    {
        arrowRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (lighting)
            lightingArrow += Time.deltaTime * lightingSpeed; // 증가
        else
            lightingArrow -= Time.deltaTime * lightingSpeed; // 감소

        if (lightingArrow >= 1.5f) lighting = false; // 1.5 도달 시 감소
        else if (lightingArrow <= 0.1f) lighting = true; // 0.1 도달 시 증가

        arrowRenderer.material.SetColor("_EmissionColor", Color.green * lightingArrow); // 녹색 발광
    }
}