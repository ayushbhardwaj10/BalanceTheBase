using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMagnet : MonoBehaviour
{
    public float speed = 5f;
    public float radius = 4.5f;

    private float angle = 0f;

    private void Update()
    {
        // Get the vertical input axis to move the sprite up and down the circle
        float verticalInput = Input.GetAxis("Vertical");

        // Update the angle based on the vertical input axis and the speed
        angle += verticalInput * speed * Time.deltaTime;

        // Calculate the x and y position of the sprite on the circle
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Set the position of the sprite
        transform.position = new Vector3(x, y, 0f);

        // Calculate the angle between the sprite and the center of the circle
        float angleToCenter = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;

        // Rotate the sprite so that its longer length is parallel to the tangent of the circle
        transform.rotation = Quaternion.Euler(0f, 0f, angleToCenter - 90f);
    }
}
