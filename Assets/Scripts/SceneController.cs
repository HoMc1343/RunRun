using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance; // Singleton 인스턴스

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        FadeManager.Instance.LoadSceneWithFade("FirstScene");
    }

    public void GoToLastScene()
    {
        FadeManager.Instance.LoadSceneWithFade("LastScene");
    }

    public void ReturnToMainScene()
    {
        FadeManager.Instance.LoadSceneWithFade("MainScene");
        SoundManager.Instance.PlaySound(0);
    }

    public void UsePortal(string sceneName, Vector3 spawnPosition, string portalTag)
    {
        GameManager.Instance.SavePortalData(spawnPosition, portalTag);
        FadeManager.Instance.LoadSceneWithFade(sceneName);
    }
}