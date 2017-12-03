using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;

    public PlayerController controller;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();
    }

    public void PauseGame()
    {
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1f;
            controller.enabled = true;
        }
        else
        {
            controller.enabled = false;
            Time.timeScale = 0f;
        }

            pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void GotoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
