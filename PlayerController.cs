using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Animator playerAnim;

    public AudioClip jumpSound;

    private AudioSource audioSource;
    public float jumpForce = 5;
    public float gravityModifier = 1;
    public bool isOnGround=false;
    public float xPos;
    public float yPos;
    public float zPos;
    private float zBound = 0;
    private float xBoundn = -46;
    private float xBoundp = -10;
    private float yBound = 7;
    public bool hasPowerup=false;
    public GameObject projectilePrefab;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //initializes variables and gameObjects
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>(); 
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {    
        //goes through the animation screens (I set the indicators for jumping through Unity's animation GUI)
        playerAnim.SetFloat("Height", transform.position.y);
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isOnGround))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //plays the jump sound
            audioSource.PlayOneShot(jumpSound, 1.0f);
            
            isOnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            //if the ball is allowed to be spawned, spawn a ball
            if (gameManager.waitBall == false)
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                StartCoroutine(spawnBall());
            }
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }

       //keeps the player within bounds
        if (transform.position.x <xBoundn)
        {
            transform.position = new Vector3(xBoundn, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundp)
        {
            transform.position = new Vector3(xBoundp, transform.position.y, transform.position.z);
        }
        if (transform.position.z != zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }
        if (transform.position.y <= 0.5)
        {
            isOnGround = true;
        }


        //isOnGround = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        
        isOnGround = true;
       // if (other.gameObject.tag == "Enemy")
        //{
         //   Destroy(other.gameObject);
         //   gameManager.UpdateScore(-5);
        //}
        if (other.gameObject.tag == "Powerup")
        {
            gameManager.UpdateScore(10);
            Destroy(other.gameObject);
        }
    }


    IEnumerator spawnBall()
    {
        gameManager.waitBall = true;

        //Wait for 4 seconds
        yield return new WaitForSeconds(0.5f);
        gameManager.waitBall = false;

        if (gameManager.gameOver)
        {
            gameManager.waitBall = true;
        }
     
    }


}
