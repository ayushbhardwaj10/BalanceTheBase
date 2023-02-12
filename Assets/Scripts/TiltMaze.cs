using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltMaze : MonoBehaviour
{ 
    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public float acceleration;
    public Vector3 customPivot;

    void Start()
    {
         
    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
                transform.RotateAround(customPivot, Vector3.forward, speed * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(customPivot, Vector3.forward, speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
                transform.RotateAround(customPivot, -Vector3.forward, speed * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(customPivot, -Vector3.forward, speed * Time.deltaTime);
            }
        }
        else
        {
            speed = minSpeed;
        }
    }

}
