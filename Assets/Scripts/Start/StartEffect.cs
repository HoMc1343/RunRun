using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
    public Light directionalLight;
    public GameObject arrow;
    private bool isFading = false;

    private float targetIntensity = 1.0f;
    private float targetFogDensity = 0.0f;
    private float targetRotationX = 50f;

    private float fadeSpeed = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            isFading = true;
        }
    }

    private void Update()
    {
        if (isFading)
        {
            directionalLight.intensity = Mathf.MoveTowards(directionalLight.intensity, targetIntensity, Time.deltaTime * fadeSpeed);

            RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, targetFogDensity, Time.deltaTime * fadeSpeed * 0.1f);

            Quaternion currentRotation = directionalLight.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(targetRotationX, -30f, 0);
            directionalLight.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * fadeSpeed * 2f);

            if (directionalLight.intensity >= targetIntensity && RenderSettings.fogDensity <= targetFogDensity && 
                Mathf.Abs(directionalLight.transform.rotation.eulerAngles.x - targetRotationX) < 0.1f)
            {
                arrow.SetActive(false);
                isFading = false;
            }
        }
    }
}