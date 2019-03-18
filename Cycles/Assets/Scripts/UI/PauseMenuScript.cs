using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    //Holds the reference to the pause menu
    public static bool GameIsPaused = false;

    //Holds the transition to the pause menu
    public GameObject pauseMenuUI;

    //Holds reference to title and restart confirmation UI
    public GameObject titleConfirmationMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        titleConfirmationMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Pause game if 'P' button is pressed and title menu not being displayed
        if (Input.GetKeyDown(KeyCode.P) && TitleMenuScript.GameIsAtTitle == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        //Display pause menu UI and stop gametime 
        pauseMenuUI.SetActive(true);
        titleConfirmationMenuUI.SetActive(false);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        //Resume game and begin gametime
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void TitleConfirmationScreen()
    {
        titleConfirmationMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        GameIsPaused = true;
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(0);
        TitleMenuScript.GameIsAtTitle = true;
    }

}
