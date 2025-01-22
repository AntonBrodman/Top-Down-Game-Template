using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonFunctions : MonoBehaviour
{

    public void LoadGame()
    {
        print("Loading current profile");
        SceneManager.LoadScene("GameScene");
    }
    public void SelectProfile()
    {
        print("Select profile");

    }
    public void NewProfile()
    {
        print("Create new profile");

    }
    public void ExitGame()
    {
        print("Exiting Game");
        Application.Quit();

    }
}
