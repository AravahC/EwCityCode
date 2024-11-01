using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI beginningText;
    //public bool gameOver;
    public int score=0;
    private bool directionsState=true;

    public GameObject FlyPrefab;

    public Button restartButton;
   // public Button startButton;
    public bool gameOver=false;
    public bool canFire = true;
    public bool waitBall = false;
    public bool startGame=true;

    private string showText = "Press H to see directions";
    private string direcText = "Welcome to Ew City\r\nPress Spacebar to kill flies\r\nUp Arrow to jump\r\nVaccines give you ten points\r\nYou lose when a fly gets past you";

    // Start is called before the first frame update
    void Start()
    {
        FlyPrefab = GameObject.FindWithTag("Enemy");
        GameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        //startButton.gameObject.SetActive(true);
        beginningText.gameObject.SetActive(true);
        beginningText.text = "toggle H to see directions";
        //if (startGame == true)
        //{
        //    startButton.gameObject.SetActive(true);
        //    beginningText.gameObject.SetActive(true);
        //}
        //else
        //{
        //    startButton.gameObject.SetActive(false);
        //    beginningText.gameObject.SetActive(false);
        //}

        ScoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeDirections();
        }
        // if (FlyPrefab.transform.position.x < -45)
        // {
        //     Debug.Log("Game is over!");
        //     GameOver();
        // }
    }
    public void GameOver()
    {
        gameOver = true;
        GameOverText.gameObject.SetActive(true);
        //FlyPrefab.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }
    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        ScoreText.text = "Score: " + score;
    }
    public void RestartGame()
    {
        gameOver = false;
        Debug.Log("The Button Has Been Pressed!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // startGame = false;
    }
    public void ChangeDirections()
    {
        directionsState = !directionsState;
        if (directionsState) 
        {
            beginningText.text = "Welcome to Ew City\r\nPress Spacebar to kill flies\r\nUp Arrow to jump\r\nVaccines give you ten points\r\nYou lose when a fly gets past you";
        }
        else { beginningText.text = "toggle H to see directions"; }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //startButton.gameObject.SetActive(false);
       // beginningText.gameObject.SetActive(directionsState);
    }

}
