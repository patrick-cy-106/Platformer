using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start Game Button
    public void StartGame()
    {
        SceneManager.LoadScene("Level_Select");
    }
    
    // Instructions Button
    public void InstructionsMenu()
    {
        SceneManager.LoadScene("Instructions");
    }


    // Achievements Button
    public void AchievementsMenu()
    {
        SceneManager.LoadScene("Achievements");
    }

    // Exit Game Button
    public void ExitGame()
    {
        Application.Quit();
    }
}
