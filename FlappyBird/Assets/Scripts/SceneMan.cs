using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    //kuþ ölü olabilir dikkat et hata çýkarsa
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

}
