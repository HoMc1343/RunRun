using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    public float jumpPower = 5f;
    private bool isPlayerJump = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayerJump)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.jumpPower *= jumpPower;
                isPlayerJump = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isPlayerJump)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.jumpPower /= jumpPower;
                isPlayerJump = false;
            }
        }
    }
}