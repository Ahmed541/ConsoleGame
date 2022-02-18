using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool gameOver;
    public static bool WinLevel;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOver = WinLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true); 
        }
        
        if (WinLevel)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            
        }





    }
}
