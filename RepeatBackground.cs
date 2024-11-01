using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 sizer;

    private float repeatWidth;
    


    // Start is called before the first frame update
    void Start()
    {
    //instantiates variables and gameObjects
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x /2;
        sizer = GetComponent<BoxCollider>().size;
    }

    // Update is called once per frame
    void Update()
    {
        //resets the position of the city so it looks like the player is moving through the city
        if (transform.position.x < (startPos.x - repeatWidth))
        {
            transform.position = startPos;
        }
        
    }
}
