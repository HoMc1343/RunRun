using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneController.Instance.StartGame();
    }

    public void Option()
    {
        Debug.Log("Option 버튼 클릭됨!"); // 추후 개발 요망
    }
}
