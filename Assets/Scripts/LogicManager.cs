using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public int saltCollected;
    public bool currentLevel;

    public bool level1Complete;
    public bool level2Complete;
    public bool level3Complete;
    public bool level4Complete;
    public bool level5Complete;

    public bool abyss;
    public bool dead;

    //public GameObject winLevelScreen;
    public GameObject LoseScreen;
    public GameObject WinGameScreen;

    public void nextLevel()
    {
        if (currentLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void restartLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void winGame()
    {
        if (saltCollected == 3)
        {
            WinGameScreen.SetActive(true);
        }
    }

    public void loseGame()
    {
        if (abyss || dead)
        {
            LoseScreen.SetActive(true);
        }
    }

    public void quitGame()
    {
        Debug.Log("Returning to Menu Scene...");
        SceneManager.LoadScene("MenuScene");
    }
}
