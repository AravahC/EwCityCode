using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static System.Math;

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

    // Start is called before the first frame update
    void Start()
    {
        //instantiates variables and spawning of flies and powerups
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnFly", startDelayFly, repeatRateFly);
        InvokeRepeating("SpawnPU", startDelayPU, repeatRatePU);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function that contains all the variables of where to spawn a fly
    void SpawnFly()
    {
        if (gameManager.gameOver == false)
        {
            if (gameManager.score == 0)
            {
                new WaitForSeconds(2);
            }
            if (gameManager.score < 0)
            {
                new WaitForSeconds(4);;
            }
            else
            {
                new WaitForSeconds(10 - gameManager.score * 0.01f);
            }
            Instantiate(flyPrefab, FlyspawnPos, flyPrefab.transform.rotation);
        }
    }
//function that contains everything to spawn a new powerup
    void SpawnPU()
    {
        if (gameManager.gameOver == false)
        {
            Instantiate(powerupPrefab, powerupspawnPos, powerupPrefab.transform.rotation);
        }
    }
}
