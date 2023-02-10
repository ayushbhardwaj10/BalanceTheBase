using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltMaze : MonoBehaviour
{ 
    public float speed;
    //public Transform customPivot;
    public Vector3 customPivot;

    void Start()
    {
         
    
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(customPivot, Vector3.forward, speed * Time.deltaTime);
        }
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(customPivot, -Vector3.forward, speed * Time.deltaTime);
            //new Vector3(-6.47f, 0.316f, 0f)
        }

    }

}
