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

    public GameObject winLevelScreen;
    public GameObject loseScreen;
    public GameObject winGameScreen;

    public void nextLevel()
    {
        if (currentLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void winGame()
    {
        
    }

    public void loseGame()
    {
        if (abyss || dead)
        {
            //SceneManager.LoadScene
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        Debug.Log("Returning to Menu Scene...");
        SceneManager.LoadScene("MenuScene");
    }
}
