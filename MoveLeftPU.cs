using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftPU : MonoBehaviour
{
    private float speed = 10;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (transform.position.x < -55) //-10)
        {
            Destroy(gameObject);
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Powerup collided with player!");
        }
        else if (other.gameObject.tag == "FrontPlane" || other.gameObject.tag=="Powerup") {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("I did not collide with player, but with something else");
        }
    }
}