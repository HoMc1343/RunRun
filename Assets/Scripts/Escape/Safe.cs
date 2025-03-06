using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public string correctPassword = "pkw";
    private string inputPassword = "";

    public GameObject safeDoor;
    public GameObject itemInside;
    public Animator doorAnimator;

    private bool isUnlocked = false;

    private void Start()
    {
        itemInside.SetActive(false);
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
            Debug.Log("비밀번호가 틀렸습니다.");
        }
    }

    private void UnlockSafe()
    {
        isUnlocked = true;
        Debug.Log("금고가 열렸습니다!");

        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
        else
        {
            safeDoor.transform.rotation = Quaternion.Euler(0, 90, 0); 
        }

        itemInside.SetActive(true);
    }
}