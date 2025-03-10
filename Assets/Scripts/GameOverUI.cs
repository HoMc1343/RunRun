using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        ResetPlayerPosition();
    }

    public void ReturnToMainScene()
    {
        Time.timeScale = 1f;
        ResetPlayerPosition();
        FadeManager.Instance.LoadSceneWithFade("MainScene");
    }
    
    public void ResetPlayerPosition()
    {
        gameObject.SetActive(false);
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(0, 1, 0);
        }
    }
}
