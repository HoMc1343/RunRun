using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [Header("Safe Settings")]
    public string correctPassword = "pkw";
    private string inputPassword = "";

    [Header("Safe Components")]
    public GameObject safeDoor;
    public GameObject insideItem;
    public Animator doorAnimator;
    public SafeUI safeUI;

    private bool isUnlocked = false;
    public bool IsUnlocked => isUnlocked;

    private void Start()
    {
        insideItem.SetActive(false);
    }

    public void EnterPassword(string input)
    {
        if (isUnlocked) return;

        inputPassword = input;

        if (inputPassword == correctPassword)
        {
            UnlockSafe();
        }
        else
        {
            Debug.Log("비밀번호가 틀렸습니다");
        }
    }

    public void UnlockSafe()
    {
        if (isUnlocked) return;
        isUnlocked = true;

        doorAnimator.SetTrigger("Open");
        insideItem.SetActive(true);
    }
}