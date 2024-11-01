using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > -10)
        {
            Destroy(gameObject);
            gameManager.canFire = true;
        }
    }
}
