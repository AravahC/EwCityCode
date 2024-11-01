using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 2;
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
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
