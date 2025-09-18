using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public GoatController goatController;

    //public GameObject winLevelScreen;
    public GameObject LoseScreen;
    public GameObject WinGameScreen;

    public int saltCollected = 0;
    public Text scoreText;

    public bool currentLevel;

    public bool level1Complete;
    //public bool level2Complete;
    //public bool level3Complete;
    //public bool level4Complete;
    //public bool level5Complete;

    //Increase Salt Collected Count
    public void AddSalt(int saltToAdd)
    {
        saltCollected += saltToAdd;
        scoreText.text = saltCollected.ToString();
    }

    public void NextLevel()
    {
        if (currentLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void WinGame()
    {
        if (saltCollected == 3)
        {
            WinGameScreen.SetActive(true);
        }
    }

    public void LoseGame()
    {
        if (!goatController.isAlive)
        {
            LoseScreen.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Returning to Menu Scene...");
        SceneManager.LoadScene("MenuScene");
    }
}
