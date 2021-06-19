using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("House");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void IntoStory()
    {
        SceneManager.LoadScene("Story");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
