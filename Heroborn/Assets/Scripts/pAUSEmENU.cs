using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class pAUSEmENU : MonoBehaviour
{
   public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public PlayerBehavior player_script;
 

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

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }

    public void SleaseMode()
    {
        player_script = GameObject.Find("Player").GetComponent<PlayerBehavior>();
        player_script.moveSpeed = 20f;
        player_script.bulletSpeed = 150f;
        player_script.rotateSpeed = 100f;
    }
}
