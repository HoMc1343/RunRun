using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slowFactor = 0.2f; // 속도를 0.2 만큼 곱하여 감소
    private bool isPlayerSlowed = false; // 플레이어의 속도 감소 상태

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayerSlowed)
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
        if (other.CompareTag("Player") && isPlayerSlowed)
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