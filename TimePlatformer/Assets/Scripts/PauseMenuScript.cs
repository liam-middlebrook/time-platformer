using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
	// variables used
	
    // Render variable for each button
    // When pause is rendered the rest are disabled
    // when pause is not rendered render the rest of the menu

	// Get player object to reset location later	

    // If called render the other four buttons and disable
    // pause button rendering as well as stop animations
    void pause(){

       // this.continueGame.enabled();
       // this.restart.enabled();
       // this.mainMenu.enabled();
       // this.exit.enabled();
    }


	// If continue button is clicked it will unpause the level.
	// It will enable pause button render and disable the other buttons as well as itself
	// resume animation
	void continueGame(){
        //this.pause.enabled();
        //this.continueGame.disabled();
        //this.restart.disabled();
        //this.mainMenu.disabled();
        //this.exit.disabled();
	}


	// If restart button is clicked it will restart the level.
    // It will enable pause button render and disable the other buttons as well as itself
	void restart(){
        //this.pause.enabled();
        //this.continueGame.disabled();
        //this.restart.disabled();
        //this.mainMenu.disabled();
        //this.exit.disabled();
	}


	// If main menu button is clicked it will load the main menu
	void mainMenu(){

	}


	///Summary
	// If exit game is clicked then the game will exit
	/// Summary end

	void exit(){
        Application.Quit();
        Debug.Log("exit called");
	}
}
