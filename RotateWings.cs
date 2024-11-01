using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWings : MonoBehaviour
{
    [SerializeField] protected Vector3 m_from = new Vector3(0.0F, 45.0F, 0.0F);
    [SerializeField] protected Vector3 m_to = new Vector3(0.0F, -45.0F, 0.0F);
    [SerializeField] protected float m_frequency = 1.0F;

    public float speed = 5;
    public int rotationAmount = 30;
    public bool rotateClockwise;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("FrontWing"))
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
//helps rotate the wings left and right. 
    protected virtual void Update()
    {
        Quaternion from = Quaternion.Euler(this.m_from);
        Quaternion to = Quaternion.Euler(this.m_to);

        float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.m_frequency));
        this.transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }
}
