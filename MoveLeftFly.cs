using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//using TMPro;

public class MoveLeftFly : MonoBehaviour
{
    public float speedFly;
    private float speed = 7;

    public bool isOnGround;

    private Rigidbody flyRb;
    private float yBound = 5;
    private float zBound;

    private GameManager gameManager;

    //public TextMeshProUGUI GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        flyRb = GetComponent<Rigidbody>();
        zBound = transform.position.z;
       // GameOverText = GameObject.Find("GameOver").GetComponent<TextMeshProUGUI>();
        //GameOverText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //the creature is rotated and whne I put in my character I must rotate it back
        transform.Translate(Vector3.up * Time.deltaTime * speed); //up means that the fly is z positive, forward means positive x, left means y positive
                                                                  //transform.Translate(Vector3.left * Time.deltaTime * speedFly);
                                                                  // transform.Translate(Vector3.left * 0.1f);
                                                                  //if ((transform.position.y > 5) || (transform.position.y<1))
                                                                  //{
                                                                  //   transform.Translate(transform.position.x, 0, transform.position.z);
                                                                  //   speedFly *= -1;
                                                                  //     Debug.Log("Vector3.left=" + Vector3.left);
                                                                  // }
                                                                  //transform.Translate(-23, transform.position.y, transform.position.z);

        speedFly = Random.Range(0,10);
        speed = Random.Range(10,30);

              if (isOnGround)
        {
            flyRb.AddForce(Vector3.up * speedFly, ForceMode.Impulse);
            //transform.Translate(Vector3.forward * Time.deltaTime * speedFly);
            isOnGround = false;
           
        }
        if (transform.position.y<-yBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y>yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }
        if (transform.position.z != zBound)
        {
            transform.position=new Vector3(transform.position.x, transform.position.y, zBound);
        }
        //if (transform.position.x < -50)
        //{
         //   GameOver();
        //}
        if (transform.position.y < 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
    //private void GameOver()
    //{
    //   GameOverText.gameObject.SetActive(true);
    //}

    //    private void OnTriggerEnter(Collider other)
    //    {
    //        if (other.CompareTag("Powerup"))
    //        {
    //            gameManager.score += 0;
    //        }
    //    }
}

