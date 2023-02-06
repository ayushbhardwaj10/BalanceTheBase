using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltMaze : MonoBehaviour
{ 
    public float speed;
   

    void Start()
    {
         
    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
        }
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, -Vector3.forward, speed * Time.deltaTime);
        }

    }

}
