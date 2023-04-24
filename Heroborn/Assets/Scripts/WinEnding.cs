using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinEnding : MonoBehaviour
{
    public void OnRestart()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void OnTitleScreen()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }
}
