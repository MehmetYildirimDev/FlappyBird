using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score=0;
    public Text ScoreText;
    public void UpdateScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
   
}
