using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            PublicVars.isAlive = false;
            SceneManager.LoadScene("Title_Screen");
        }
    }
}
