using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float boundarySize = 5f; // the size of the square boundary
    public float moveSpeed = 5f; // the speed at which the object moves

    private Vector3 startingPosition; // the starting position of the object
    private Vector3 mousePosition; // the current position of the mouse

    void Start()
    {
        startingPosition = transform.position; // save the starting position of the object
    }

    void Update()
    {
        // get the current position of the mouse
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // calculate the distance between the mouse position and the starting position of the object
        float distance = Vector3.Distance(startingPosition, mousePosition);

        // if the mouse is outside the boundary, move the object towards the closest point on the boundary
        if (distance < boundarySize)
        {
            Vector3 direction = mousePosition - startingPosition;
            direction.Normalize();
            mousePosition = startingPosition + direction * boundarySize;
        }
       

        // move the object towards the mouse position
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }
}
