using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
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
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        gameManager.GameOver();
    //    }
    //    else if (other.gameObject.tag == "Powerup")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}
