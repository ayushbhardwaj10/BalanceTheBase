using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMovementScript : MonoBehaviour
{
    //public GameObject rectangle; // reference to sprite B
    //public float speed = 2f;
    //public float amplitude = 2f;
    //public float frequency = 2f;

    //private Vector3 startPosition;
    //private float time = 0f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    startPosition = transform.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    time += Time.deltaTime;

    //    // Move the circle up and down along the rectangle
    //    float yPos = startPosition.y + amplitude * Mathf.Sin(frequency * time);
    //    transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

    //    // Align the circle with the rotation of the rectangle
    //    transform.localEulerAngles = new Vector3(0f, 0f, rectangle.transform.localEulerAngles.z);

    //    // Move the circle left or right with arrow keys
    //    float xInput = Input.GetAxis("Vertical");
    //    transform.Translate(new Vector3(xInput * speed * Time.deltaTime, 0f, 0f));
    //}


    public Transform wallTransform;
    public float wallWidth;

    private float wallAngle;
    private Vector2 magnetPosition;
    private Vector2 magnetVelocity;
    private Rigidbody2D magnetRigidbody;

    void Start()
    {
        magnetRigidbody = GetComponent<Rigidbody2D>();
        magnetPosition = magnetRigidbody.position;
    }

    void FixedUpdate()
    {
        // Get the current angle of the wall
        wallAngle = wallTransform.rotation.eulerAngles.z;

        // Calculate the horizontal distance from the center of the wall to the ball
        float horizontalDistance = Mathf.Cos(wallAngle * Mathf.Deg2Rad) * (wallWidth / 2);

        // Calculate the vertical distance from the center of the wall to the ball
        float verticalDistance = Mathf.Sin(wallAngle * Mathf.Deg2Rad) * (wallWidth / 2);

        // Calculate the position of the magnet along the wall
        float horizontalOffset = Input.GetAxis("Vertical");
        horizontalOffset = horizontalOffset * wallWidth / 2f;
        Vector2 targetPosition = new Vector2(
            wallTransform.position.x + horizontalDistance + horizontalOffset,
            wallTransform.position.y + verticalDistance + Mathf.PingPong(Time.time, 2)
        );

        // Move the magnet towards the target position
        magnetVelocity = (targetPosition - magnetPosition) * 10;
        magnetPosition += magnetVelocity * Time.deltaTime;
        magnetRigidbody.MovePosition(magnetPosition);
    }
}
