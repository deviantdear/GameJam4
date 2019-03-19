using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuScript : MonoBehaviour
{

    //Holds reference to title screen
    public static bool GameIsAtTitle = true;
    
    //Start the game with the pause menu turned off
    public GameObject titleMenuUI;

    private void Start()
    {
        titleMenuUI.SetActive(true);
        Time.timeScale = 0f;
        titleMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Displays Title Screen if reference to title screen is true
        if (GameIsAtTitle == true)
        {
            titleMenuUI.SetActive(true);
        }
    }

    public void StartGame()
    {
        //Display pause menu UI and stops gametime 
        titleMenuUI.SetActive(false);
        GameIsAtTitle = false;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        //Quits the game
        Application.Quit();
    }
}
