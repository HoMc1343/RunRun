using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;
        ReturnToMainScene();
    }

    public void ReturnToMainScene()
    {
        FadeManager.Instance.LoadSceneWithFade("MainScene");
    }
}
