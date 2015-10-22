using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {


    public void pause(){
        Debug.Log("pausing");
        Time.timeScale = 0;
        var continueButton = GameObject.FindGameObjectWithTag("ContinueButton");
        var restartButton = GameObject.FindGameObjectWithTag("RestartButton");
        var mainMenuButton = GameObject.FindGameObjectWithTag("MainMenuButton");
        var exitButton = GameObject.FindGameObjectWithTag("ExitGameButton");
        var pauseButton = GameObject.FindGameObjectWithTag("PauseButton");


        continueButton.transform.position = new Vector3(850.0f, 500.0f);
        restartButton.transform.position = new Vector3(850.0f, 440.0f);
        mainMenuButton.transform.position = new Vector3(850.0f, 380.0f);
        exitButton.transform.position = new Vector3(850.0f, 320.0f);
        pauseButton.transform.position = new Vector3(-10000.0f, 120.0f);
    }                  


    // If continue button is clicked it will unpause the level.
    // It will enable pause button render and disable the other buttons as well as itself
    // resume animation
    public void continueGame(){
        Time.timeScale = 1;
        var continueButton = GameObject.FindGameObjectWithTag("ContinueButton");
        var restartButton = GameObject.FindGameObjectWithTag("RestartButton");
        var mainMenuButton = GameObject.FindGameObjectWithTag("MainMenuButton");
        var exitButton = GameObject.FindGameObjectWithTag("ExitGameButton");
        var pauseButton = GameObject.FindGameObjectWithTag("PauseButton");

        continueButton.transform.position = new Vector3(-470.0f, 400.0f);
        restartButton.transform.position = new Vector3(-470.0f, 340.0f);
        mainMenuButton.transform.position = new Vector3(-470.0f, 280.0f);
        exitButton.transform.position = new Vector3(-470.0f, 220.0f);
        pauseButton.transform.position = new Vector3(1500.0f, 20.0f);


    }


	// If restart button is clicked it will restart the level.
    // It will enable pause button render and disable the other buttons as well as itself
	public void restart(){
        var lastLvl = Application.loadedLevel;
        Application.LoadLevel(lastLvl);
    }


	// If main menu button is clicked it will load the main menu
	public void mainMenu(){
        Application.LoadLevel(0);

    }


	///Summary
	// If exit game is clicked then the game will exit
	/// Summary end

	public void exit(){
        Application.Quit();
        Debug.Log("exit called");
	}
}
