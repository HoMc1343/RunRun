using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalDoor : MonoBehaviour
{
    public int requiredCoins = 10; // 문을 열기 위한 코인 개수
    public Animator animator; // 문 애니메이션
    private bool isUnlocked = false; // 문이 개폐 여부

    public TextMeshPro coinCountText; // 코인 개수
    private int currentCoinCount = 0; // 현재 코인 개수

    public bool IsUnlocked => isUnlocked;

    public void CheckAndOpenDoor(int coinCount) // 문 개방
    {
        if (isUnlocked) return;

        if (coinCount >= requiredCoins)
        {
            OpenDoor();
        }
        UpdateCoinCountText();
    }

    private void OpenDoor() // 문 개방
    {
        isUnlocked = true;
        animator.SetTrigger("Open");
        SoundManager.Instance.PlaySound(4);
    }

    private void UpdateCoinCountText() // 코인 텍스트 업데이트
    {
        if (coinCountText != null)
        {
            coinCountText.text = currentCoinCount.ToString();
        }
    }

    public int GetCurrentCoinCount() // 코인 개수 반환
    {
        return currentCoinCount;
    }

    public void AddCoin() // 코인 추가
    {
        currentCoinCount++;
        UpdateCoinCountText();
    }
}