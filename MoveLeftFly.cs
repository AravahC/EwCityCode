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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        flyRb = GetComponent<Rigidbody>();
        zBound = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        //move the fly upwards
        transform.Translate(Vector3.up * Time.deltaTime * speed); 

        speedFly = Random.Range(0,10);
        speed = Random.Range(10,30);

        if (isOnGround){
            //move the fly upwards with irregularity
            flyRb.AddForce(Vector3.up * speedFly, ForceMode.Impulse);
            isOnGround = false;
           
        }
        //keeps the fly within bounds
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

        //keeps the fly from going through the ground
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
}

