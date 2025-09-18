using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Load MenuScene
            Debug.Log("Menu Opened");
            SceneManager.LoadScene("MenuScene");
        }
    }
}
