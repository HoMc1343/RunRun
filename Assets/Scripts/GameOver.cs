using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float overPosY = -10;
    public GameOverUI gameOverUI;

    private void Awake()
    {
        gameOverUI = FindObjectOfType<GameOverUI>();
    }

    private void Start()
    {
        gameOverUI.gameObject.SetActive(false);
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
        Cursor.lockState = CursorLockMode.None;

        if (gameOverUI != null)
        {
            gameOverUI.gameObject.SetActive(true);
        }
    }
}
