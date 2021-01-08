using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        //clear scores and reset level in case the method is used to restart
        RunGame.scores.Clear();
        RunGame.level = 1;
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene("FirstLevel_Normal");
    }

    public void QuitGame()
    {
        print("Quit Game");
        Application.Quit();
    }
}
