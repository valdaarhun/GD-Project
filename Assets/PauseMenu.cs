using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; //variable keeps track of if the game is paused 
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)    //pressed escape key when game was already paused so resume
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    { 
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //normal rate
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //freezes the game
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
