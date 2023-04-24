using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    private int _PaintingsCollected = 0;
    public int maxPaint = 5;
    public bool showWinScreen = false;
    public bool showSecretScreen = false;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI paintingsText;
    public TextMeshProUGUI itemsText;
    public bool showLossScreen = false;
    
    public int Items
    {
        get { return _itemsCollected; }
        set {
            _itemsCollected = value;
            if(_itemsCollected >= maxItems) 
            {
                labelText = "You found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int Paintings
    {
        get { return _PaintingsCollected; }
        set {
            _PaintingsCollected = value;
            if(_PaintingsCollected >= maxPaint) 
            {
                labelText = "You found all the paintings!";
                showSecretScreen = true;
            }
            else
            {
                labelText = "Painting found, only " + (maxPaint - _PaintingsCollected) + " more to go!";
            }
        }
    }

    public int _playerHP = 10;

    public int HP
    {
        get { return _playerHP; }
        set {
            _playerHP = value;
            if(_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else{
                labelText = "Ouch...that's gotta hurt!";
            }
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        paintingsText.text = _PaintingsCollected.ToString();
        itemsText.text = _itemsCollected.ToString();
        healthText.text = _playerHP.ToString();
        
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 100, 100), "YOU WON!");
            {
                SceneManager.LoadScene(2);
            }
            //Time.timeScale = 1.0f;
        }
        if(showSecretScreen)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 100, 100), "YOU SOLVED THE SECRETS!");
            {
                RestartLevel();
            }
            //SceneManager.LoadScene(0);
            //Time.timeScale = 1.0f;
        }

        if(showLossScreen)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose!"))
            {
                RestartLevel();
                //SceneManager.LoadScene(0);
                //Time.timeScale = 1.0f;
            }
        }
    }
}
