using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if it hits the front plane ends the game
        if (other.gameObject.CompareTag("FrontPlane"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
        //if it hits the back plane gets destroyed
        else if (other.gameObject.CompareTag("BackPlane"))
        {
            Destroy(gameObject);
        }
        //if it gets hit by a fireball score increases+gets destroyed
        else if (other.gameObject.CompareTag("Fire"))
        {
            gameManager.UpdateScore(10);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        //if it hits the player score decreases+destroyed
        else if (other.gameObject.CompareTag("Player")) { 
            Destroy(gameObject);
            gameManager.UpdateScore(-5);
        }
      //  Destroy(gameObject);
        //Destroy(other.gameObject);
       // gameManager.canFire = true;
        //gameManager.UpdateScore(1);

    }
}
