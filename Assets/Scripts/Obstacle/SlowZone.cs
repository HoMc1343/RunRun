using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [Header("Slow Zone Settings")]
    public float slowMultiplier = 0.5f; // 감속 비율 (0.5배)
    public float transitionDuration = 0.5f; // 속도 변화가 적용되는 시간

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                StopAllCoroutines(); // 중복 실행 방지
                StartCoroutine(ChangeSpeed(player, slowMultiplier));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                StopAllCoroutines(); // 중복 실행 방지
                StartCoroutine(ChangeSpeed(player, 1f)); // 원래 속도로 복구
            }
        }
    }

    IEnumerator ChangeSpeed(PlayerController player, float targetMultiplier)
    {
        float initialSpeed = player.moveSpeed;
        float targetSpeed = player.moveSpeed * targetMultiplier;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            player.moveSpeed = Mathf.Lerp(initialSpeed, targetSpeed, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.moveSpeed = targetSpeed; // 최종 속도 설정
    }
}