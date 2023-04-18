using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongBorder : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if the mouse is within the square
        if (GetComponent<BoxCollider2D>().bounds.Contains(mousePosition))
        {
            // Stop the movement
            targetPosition = transform.position;
            return;
        }

        // Calculate the movement direction
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // Calculate the target position
        Vector2 center = GetComponent<BoxCollider2D>().bounds.center;
        Vector2 size = GetComponent<BoxCollider2D>().bounds.size;
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;

        Vector2[] points = new Vector2[] {
            new Vector2(center.x - halfWidth, center.y), // Left
            new Vector2(center.x, center.y + halfHeight), // Top
            new Vector2(center.x + halfWidth, center.y), // Right
            new Vector2(center.x, center.y - halfHeight) // Bottom
        };

        float minDistance = Mathf.Infinity;
        foreach (Vector2 point in points)
        {
            float distance = Vector2.Distance(mousePosition, point);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetPosition = point;
            }
        }

        // Move the object towards the target position
        float speed = 10f;
        rb.MovePosition(Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime));
    }
}



