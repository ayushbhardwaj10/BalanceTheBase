using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMagnet : MonoBehaviour
{
    public float radius = 5f; // the radius within which the object can be moved
    private Vector3 originalPos; // the object's original position
    private Vector3 mousePos; // the current position of the mouse
    private Vector3 newPos; // the new position of the object

    void Start()
    {
        originalPos = transform.position; // set the object's original position
    }

    void Update()
    {
        // get the current position of the mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // make sure the z-coordinate is zero


        // calculate the distance between the mouse and the original position of the object
        float distance = Vector3.Distance(originalPos, mousePos);

        // check if the mouse is within the radius
        //if (distance == radius)
        //{
        //    newPos = mousePos; // set the new position to the mouse position
        //    Debug.Log("1");
        //}
        //else
        //{
            newPos = originalPos + (mousePos - originalPos).normalized * radius; // set the new position to the edge of the radius
            
       // }

        // move the object to the new position
        transform.position = newPos;
    }
}
