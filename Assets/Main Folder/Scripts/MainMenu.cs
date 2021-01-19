using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
        SceneManager.LoadScene("PlayMenu");
    }

    public void GoToSettingsMenu() {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }




}
