using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Renderer arrowRenderer;
    private float emissionIntensity = 1.5f;
    private bool increasing = true;
    private float blinkSpeed = 1f;

    void Start()
    {
        arrowRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (increasing)
            emissionIntensity += Time.deltaTime * blinkSpeed;
        else
            emissionIntensity -= Time.deltaTime * blinkSpeed;

        if (emissionIntensity >= 2f) increasing = false;
        else if (emissionIntensity <= 0.5f) increasing = true;

        arrowRenderer.material.SetColor("_EmissionColor", Color.yellow * emissionIntensity);
    }
}