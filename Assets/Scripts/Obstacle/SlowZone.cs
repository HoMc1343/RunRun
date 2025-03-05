using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slowFactor = 0.2f; // 속도를 얼마나 줄일지 설정
    private bool isPlayerSlowed = false; // 플레이어의 속도 감소 상태 추적

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayerSlowed) // 플레이어가 들어왔고 아직 느려지지 않았을 때
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.moveSpeed *= slowFactor; // 속도 감소
                isPlayerSlowed = true; // 상태 변경
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isPlayerSlowed) // 플레이어가 나갔고 이미 속도가 느려졌을 때
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.moveSpeed /= slowFactor; // 원래 속도로 복구
                isPlayerSlowed = false; // 상태 변경
            }
        }
    }
}