using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string level_name = "Level_1";

    public void LevelLoad()
    {
        SceneManager.LoadScene(level_name);
    }

    public void StartMenuReturn()
    {
        SceneManager.LoadScene("Title_Screen");
    }
}
