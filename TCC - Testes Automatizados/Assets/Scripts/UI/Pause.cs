using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    public GameObject pause;

    private bool isPaused = false;
    
    private void Awake() 
    {
        instance = this;
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public bool getIsPaused()
    {
        return isPaused;
    }
}
