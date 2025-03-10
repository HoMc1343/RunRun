using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject optionMenuPanel;

    void Start()
    {
        optionMenuPanel.SetActive(false);
    }

    public void OpenOptionMenu()
    {
        optionMenuPanel.SetActive(true);
    }

    public void CloseOptionMenu()
    {
        optionMenuPanel.SetActive(false);
    }

    public void ReturnToMainScene()
    {
        SceneController.Instance.ReturnToMainScene();
    }
}