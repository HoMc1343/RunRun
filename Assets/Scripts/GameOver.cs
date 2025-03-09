using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float overPosY = -10;
    public GameOverUI gameOverUI;

    private void Start()
    {
        gameOverUI = FindObjectOfType<GameOverUI>();
    }

    private void Update()
    {
        if (transform.position.y <= overPosY)
        {
            IsGameOver();
        }
    }

    private void IsGameOver()
    {
        Time.timeScale = 0f;

        if (gameOverUI == null)
        {
            gameOverUI = FindObjectOfType<GameOverUI>();
        }

        if (gameOverUI != null)
        {
            gameOverUI.gameObject.SetActive(true);
        }
    }
}
