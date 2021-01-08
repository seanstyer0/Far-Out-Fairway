using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour
{
    public void StartMainScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
