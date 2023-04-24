using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Sprite cat1;
    public Sprite cat2;
    public Sprite cat3;
    public Sprite cat_type;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    

    public void HandleInputData(int val)
    {
        if(val == 0)
        {
            GameObject.Find("cat").GetComponent<SpriteRenderer>().sprite = cat1;
        } 
        if(val == 1)
        {
            GameObject.Find("cat").GetComponent<SpriteRenderer>().sprite = cat2;
        }
        if(val == 2)
        {
            GameObject.Find("cat").GetComponent<SpriteRenderer>().sprite = cat3;
        }
    }
}
