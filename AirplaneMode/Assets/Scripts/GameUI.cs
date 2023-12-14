using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public Image winBackground;


    //instance
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "<b>Score:</b> " + score;
    }

    public void SetWinText(string winnerName)
    {
        winBackground.gameObject.SetActive(true);
        winText.text = winnerName + " wins!";
    }

}