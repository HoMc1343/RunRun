using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
    public Light directionalLight;
    public GameObject[] arrow;
    private bool isFading = false;

    private float targetIntensity = 1.0f; // 밝기
    private float targetFogDensity = 0.0f; // 안개
    private float targetRotationX = 50f; // 각도

    private float fadeSpeed = 0.5f; // 전환 속도

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading) // 플레이어 인식
        {
            SoundManager.Instance.PlaySound(8);
            isFading = true; // 전환 개시
        }
    }

    private void Update()
    {
        if (isFading)
        {
            directionalLight.intensity = Mathf.MoveTowards(directionalLight.intensity, targetIntensity, Time.deltaTime * fadeSpeed); // 밝기 조정

            RenderSettings.fogDensity = Mathf.MoveTowards(RenderSettings.fogDensity, targetFogDensity, Time.deltaTime * fadeSpeed * 0.1f); // 안개 밀도 조정

            Quaternion currentRotation = directionalLight.transform.rotation; // 조명 각도 설정
            Quaternion targetRotation = Quaternion.Euler(targetRotationX, -30f, 0); // 각도 목표 설정
            directionalLight.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * fadeSpeed * 2f); // Lerp를 사용한 부드러운 움직임

            if (directionalLight.intensity >= targetIntensity && RenderSettings.fogDensity <= targetFogDensity && 
                Mathf.Abs(directionalLight.transform.rotation.eulerAngles.x - targetRotationX) < 0.1f) // 각 값이 거의 도달했는지 확인
            {
                foreach (GameObject obj in arrow)
                {
                    obj.SetActive(false); // 화살표 비활성화
                }
                
                isFading = false; // 전환 종료
            }
        }
    }
}