using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance; 

    private int player1Score = 0;
    private int player2Score = 0;
    public TextMeshProUGUI player1ScoreText;  
    public TextMeshProUGUI player2ScoreText; 
    public GameObject winScreen;
    public Text winText;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int playerID, int points)
    {
        if (playerID == 1)
        {
            player1Score += points;
            player1ScoreText.text = "Player 1: " + player1Score;
        }
        else if (playerID == 2)
        {
            player2Score += points;
            player2ScoreText.text = "Player 2: " + player2Score;
        }
    }
}
