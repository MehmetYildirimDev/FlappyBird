using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    //ku� �l� olabilir dikkat et hata ��karsa
  public void GameSceneTransition()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    
    public void MenuSceneTransition()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
