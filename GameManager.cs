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
    public bool gameOver=false;
    public bool canFire = true;
    public bool waitBall = false;
    public bool startGame=true;

    private string showText = "Press H to see directions";
    private string direcText = "Welcome to Ew City\r\nPress Spacebar to kill flies\r\nUp Arrow to jump\r\nVaccines give you ten points\r\nYou lose when a fly gets past you";

    // Start is called before the first frame update
    void Start()
    {
        //initializing variables and gameObjects
        FlyPrefab = GameObject.FindWithTag("Enemy");
        GameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        beginningText.gameObject.SetActive(true);
        beginningText.text = "toggle H to see directions";

        ScoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        //change Directions refers to the change of the text directions, not to the movement of the player
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeDirections();
        }
    }
    //sets GameOver to true and sets the restart button to appear
    public void GameOver()
    {
        gameOver = true;
        GameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    //updates score
    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        ScoreText.text = "Score: " + score;
    }
    //restarts the game and reloads the scene when the restart button is pressed
    public void RestartGame()
    {
        gameOver = false;
        Debug.Log("The Button Has Been Pressed!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // startGame = false;
    }
    //toggles the directions on the screen
    public void ChangeDirections()
    {
        directionsState = !directionsState;
        if (directionsState) 
        {
            beginningText.text = "Welcome to Ew City\r\nPress Spacebar to kill flies\r\nUp Arrow to jump\r\nVaccines give you ten points\r\nYou lose when a fly gets past you";
        }
        else { beginningText.text = "toggle H to see directions"; }
    }

}
