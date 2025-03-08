using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float jumpPower = 5f; // 점프를 5 만큼 곱하여 증가
    private bool isPlayerJump = false; // 증가 여부

    private void OnTriggerEnter(Collider other) // 증가
    {
        if (other.CompareTag("Player") && !isPlayerJump)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.jumpPower *= jumpPower; // 점프 증가
                isPlayerJump = true; // 상태 변경
            }
        }
    }

    private void OnTriggerExit(Collider other) // 감소
    {
        if (other.CompareTag("Player") && isPlayerJump)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.jumpPower /= jumpPower; // 점프 감소
                isPlayerJump = false; // 상태 변경
            }
        }
    }
}