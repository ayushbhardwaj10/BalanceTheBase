using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBorder : MonoBehaviour
{
    public float radius = 4f; // the radius of the circle
    public float lineWidth = 0.1f; // the width of the circle's boundary line
    public float thickness = 0.1f;
    public Color lineColor = Color.white; // the color of the circle's boundary line

    private LineRenderer lineRenderer; // the LineRenderer component used to draw the circle
    private PolygonCollider2D polyCollider;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>(); // add a LineRenderer component to the object
        lineRenderer.useWorldSpace = false; // use local coordinates for the line renderer
        lineRenderer.startWidth = lineWidth; // set the line width
        lineRenderer.endWidth = lineWidth; // set the line width
        lineRenderer.material.color = lineColor; // set the line color
        DrawCircle(); // draw the circle

        AttachToCircle(gameObject);
    }

    void DrawCircle()
    {
        int segments = 64; // the number of line segments used to draw the circle
        float anglePerSegment = 2f * Mathf.PI / segments; // the angle between each line segment
        Vector3[] points = new Vector3[segments + 1]; // an array to hold the points on the circle's circumference
        for (int i = 0; i < segments + 1; i++)
        {
            float angle = i * anglePerSegment; // the angle of the current point
            points[i] = new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius, 0f); // calculate the position of the current point
        }
        lineRenderer.positionCount = segments + 1; // set the number of points in the line renderer
        lineRenderer.SetPositions(points); // set the positions of the points in the line renderer

        EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        int pointCount = lineRenderer.positionCount;
        Vector2[] pts = new Vector2[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            pts[i] = lineRenderer.GetPosition(i);
        }

        edgeCollider.points = pts;
    }

    public void AttachToCircle(GameObject obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = obj.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}


