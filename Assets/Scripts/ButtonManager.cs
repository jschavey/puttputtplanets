using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    //main menu
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

	//start button
    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    //how to play button
    public void HowToPlayButton()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    //credits button
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    //quit button
    public void QuitButton()
    {
        Application.Quit();
    }

    //change scene
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
