using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SafeUI : MonoBehaviour
{
    [Header("UI Components")]
    public GameObject safePanel;
    public TMP_InputField passwordInput;
    public Button enterButton;
    
    public Safe safe;
    public PlayerController playerController;

    private CursorLockMode previousCursorLockState;
    private bool previousCursorVisible;

    private void Start()
    {
        safePanel.SetActive(false);
        enterButton.onClick.AddListener(CheckPassword);

        if (safe == null)
        {
            safe = FindObjectOfType<Safe>();
        }
    }

    public void ShowUI()
    {
        safePanel.SetActive(true);

        previousCursorLockState = Cursor.lockState;
        previousCursorVisible = Cursor.visible;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerController != null)
        {
            playerController.canLook = false;
            playerController.enabled = false;
        }
    }

    public void CheckPassword()
    {
        if (passwordInput.text == safe.correctPassword)
        {
            safe.UnlockSafe();
            safePanel.SetActive(false);
            CloseUI();
        }
    }

    public void CloseUI()
    {
        safePanel.SetActive(false);
        Cursor.lockState = previousCursorLockState;
        Cursor.visible = previousCursorVisible;

        if (playerController != null)
        {
            playerController.canLook = true;
            playerController.enabled = true;
        }
    }
}
