using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start Game Button
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    // Exit Game Button
    public void ExitGame()
    {
        Application.Quit();
    }
}
