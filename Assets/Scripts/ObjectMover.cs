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

        // clamp the mouse position to the boundary
        mousePosition.x = Mathf.Clamp(mousePosition.x, startingPosition.x - boundarySize, startingPosition.x + boundarySize);
        mousePosition.y = Mathf.Clamp(mousePosition.y, startingPosition.y - boundarySize, startingPosition.y + boundarySize);

        // move the object towards the mouse position
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }
}
