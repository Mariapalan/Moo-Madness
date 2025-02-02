using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

     public int winningScore = 10; 
    private int player1Score = 0;
    private int player2Score = 0;
    public TextMeshProUGUI player1ScoreText;  
    public TextMeshProUGUI player2ScoreText; 
    public GameObject winScreen;
    public Text winText;

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

        winScreen.SetActive(false);
    }
    public void CaptureCow(int playerID)
    {
        if (playerID == 1){
            player1Score += 1;
            player1ScoreText.text = "Player 1: " + player1Score;
        }
            
        else if (playerID == 2){
            player2Score += 1;
            player2ScoreText.text = "Player 2: " + player2Score;
        }
        
        //playerID is 0 right now because the lasso is not implemented yet so scores cannot be read

        Debug.Log($"Player {playerID} captured a cow! Player1: {player1Score}, Player2: {player2Score}");

        CheckForWinners();
    }
    /*public void AddScore(int playerID, int points)
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

        CheckForWinner();
    }*/
    private void CheckForWinners()
    {
        GameObject[] cows = GameObject.FindGameObjectsWithTag("Cow");
        
        if (player1Score >= winningScore)
        {
            EndGame("Player 1 Wins!");
        }
        else if (player2Score >= winningScore)
        {
            EndGame("Player 2 Wins!");
        }
        else if (cows.Length == 1) 
        {
            Debug.Log("Game Over - Showing Winner");
            ShowWinScreen();
        }
    }

    private void EndGame(string message)
    {
        winScreen.SetActive(true); 
        winText.text = message;     
        Time.timeScale = 0;         
    }
    void ShowWinScreen()
    {
        winScreen.SetActive(true); 

        if (player1Score > player2Score)
            winText.text = "Player 1 Wins! 🎉";
        else if (player2Score > player1Score)
            winText.text = "Player 2 Wins! 🎉";
        else
            winText.text = "It's a Tie! 🤝";

        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        Debug.Log("Restart button clicked!");
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
