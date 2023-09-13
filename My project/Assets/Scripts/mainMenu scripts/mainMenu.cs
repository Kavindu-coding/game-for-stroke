using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void startGameOne()
    {
        SceneManager.LoadScene("StartUI");
    }
    public void startGameTwo()
    {
        SceneManager.LoadScene("first_page");
    }

    public void startGameThree()
    {
        SceneManager.LoadScene("New Scene");
    }
}

