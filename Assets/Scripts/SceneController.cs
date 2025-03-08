using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        FadeManager.Instance.LoadSceneWithFade("MainScene"); // 페이드아웃과 함께 메인 씬으로..
    }

    // public void GoToLastScene()
    // {
    //     FadeManager.Instance.LoadSceneWithFade("LastScene");
    // }

    // public void ReturnToStartScene()
    // {
    //     FadeManager.Instance.LoadSceneWithFade("StartScene");
    // }

    public void OpenOptions()
    {
        Debug.Log("Option 버튼 클릭됨!"); // 추후 개발 요망
    }
}