using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMagnet : MonoBehaviour
{


    // *********************************** This is wrt Keyboard Control ********************************************** 

    //public float moveSpeed = 5f; // the speed at which the object moves
    //public float boundaryRadius = 5f; // the radius of the circular boundary

    //private Vector2 centerPosition; // the center position of the circular boundary


    //void Start()
    //{
    //    centerPosition = transform.position; // set the center position to the initial position of the object
    //}

    //void Update()
    //{
    //    // get the horizontal and vertical input from the keyboard
    //    float horizontalInput = Input.GetAxisRaw("Horizontal");
    //    float verticalInput = Input.GetAxisRaw("Vertical");
    //    // calculate the movement direction based on the keyboard input
    //    Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

    //    // calculate the target position based on the movement direction, the speed, and the center position
    //    Vector2 targetPosition = centerPosition + movementDirection * boundaryRadius;

    //    // move the object towards the target position
    //    transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    //    // clamp the object within the circular boundary
    //    float distanceFromCenter = Vector2.Distance(centerPosition, transform.position);
    //    if (distanceFromCenter > boundaryRadius)
    //    {
    //        transform.position = (Vector3)centerPosition + ((Vector3)(transform.position) - (Vector3)(centerPosition)).normalized * boundaryRadius;
    //    }
    //}


    public float radius = 5f; // the radius within which the object can be moved
    private Vector3 originalPos; // the object's original position
    private Vector3 mousePos; // the current position of the mouse
    private Vector3 newPos; // the new position of the object

    private float angle = 0f;

    void Update()
    {
        

        // calculate the distance between the mouse and the original position of the object
        float distance = Vector3.Distance(originalPos, mousePos);

        // check if the mouse is within the radius
        
            newPos = originalPos + (mousePos - originalPos).normalized * radius; // set the new position to the edge of the radius
        

        // move the object to the new position
        transform.position = newPos;
    }
}
