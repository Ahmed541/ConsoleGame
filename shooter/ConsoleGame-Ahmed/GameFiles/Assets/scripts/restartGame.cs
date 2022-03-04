using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    public string CurrentLevel;
    // Start is called before the first frame update

    public void RestartGame()
    {

        SceneManager.LoadScene(CurrentLevel);
        //yield return 0;
       
        //  SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level 3"));
    }
}
