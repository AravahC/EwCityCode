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
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x /2;
        sizer = GetComponent<BoxCollider>().size;
        //repeatWidth = 38;
        Debug.Log("Size of Box Collider: " + sizer);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (startPos.x - repeatWidth))
        {
            transform.position = startPos;
        }
        
    }
}
