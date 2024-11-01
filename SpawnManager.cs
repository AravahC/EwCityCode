using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
//using UnityEngine.UIElements;
using static System.Math;
//using Math;

public class SpawnManager : MonoBehaviour
{
    public GameObject flyPrefab;
    public GameObject powerupPrefab;

    private Vector3 FlyspawnPos = new Vector3 (0, 3, 0);
    private Vector3 powerupspawnPos = new Vector3(1, 3, 0);

    private GameManager gameManager;

    private float startDelayFly = 2;
    private float repeatRateFly=1;

    private float startDelayPU = 3;
    private float repeatRatePU=5;

    //private List<GameObject> flies = new List<GameObject>(); // List to store instantiated flies
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnFly", startDelayFly, repeatRateFly);
        InvokeRepeating("SpawnPU", startDelayPU, repeatRatePU);
       // InvokeRepeating("SpawnFly", startDelay, repeatRate);
      //  if (gameManager.score != 0)
        //{
          //  repeatRate *= gameManager.score;
            //Debug.Log("Rate of repetition" + repeatRate);
        //}
        //else
        //{
          //  repeatRate = 2;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnFly()
    {
        if (gameManager.gameOver == false)
        {
            if (gameManager.score == 0)
            {
                new WaitForSeconds(2);
                Debug.Log("Score is 0");
            }
            if (gameManager.score < 0)
            {
                new WaitForSeconds(4);
                Debug.Log("Score is negative");
            }
            //new WaitForSeconds(10/gameManager.score);
            else
            {
                new WaitForSeconds(10 - gameManager.score * 0.01f);
            }
            Instantiate(flyPrefab, FlyspawnPos, flyPrefab.transform.rotation);
          //  Instantiate(powerupPrefab, FlyspawnPos, flyPrefab.transform.rotation);
        }
    }

    void SpawnPU()
    {
        if (gameManager.gameOver == false)
        {
            Debug.Log("Potenial Demon Spawn");
            if (gameManager.score < 0)
            {
                // gameManager.score = 0;
                Debug.Log("Banana");
            }
            //new WaitForSeconds(10/gameManager.score);
            else
            {
                Debug.Log("Spawn Syringe");
              //new WaitForSeconds(10 - Mathf.Abs(gameManager.score) * 0.01f);
            }
            Instantiate(powerupPrefab, powerupspawnPos, powerupPrefab.transform.rotation);
        }
    }
}
