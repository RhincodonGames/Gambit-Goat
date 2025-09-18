using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void displayRules()
    {
        Debug.Log("Rules Displayed");
    }

    public void quitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
