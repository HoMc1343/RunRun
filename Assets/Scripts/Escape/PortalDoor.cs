using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalDoor : MonoBehaviour
{
    public int requiredCoins = 10; // 필요한 코인 개수
    private int currentCoinCount = 0; // 현재 코인 개수
    public TextMeshPro coinCountText;

    private bool isUnlocked = false; // 문 개폐 여부
    public Animator animator;

    public bool IsUnlocked => isUnlocked;

    public void CheckAndOpenDoor(int coinCount) // 문 개방 확인
    {
        if (isUnlocked) return;

        if (coinCount >= requiredCoins) // 조건 충족 시 개방
        {
            OpenDoor();
        }
        UpdateCoinCountText(); // 코인 텍스트 업데이트
    }

    private void OpenDoor() // 문 개방
    {
        if (isUnlocked) return;
        isUnlocked = true;

        animator.SetTrigger("Open"); // 애니메이션 실행
    }

    private void UpdateCoinCountText() // 코인 텍스트 업데이트
    {
        if (coinCountText != null)
        {
            coinCountText.text = currentCoinCount.ToString(); // 텍스트로 코인 개수 표시
        }
    }

    public void AddCoin() // 코인 추가
    {
        currentCoinCount++;
        UpdateCoinCountText(); // 텍스트 갱신
    }

    public int GetCurrentCoinCount() // 현재 코인 개수 반환
    {
        return currentCoinCount;
    }
}