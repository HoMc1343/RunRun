using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeTrigger : MonoBehaviour
{
    public SafeUI safeUI;
    public Safe safe; // Safe 참조 추가

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && safeUI != null && !safe.IsUnlocked)
        {
            safeUI.ShowUI();
        }
    }
}
