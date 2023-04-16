using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularDrawer : MonoBehaviour
{
    public float radius = 1f; // the radius of the circle
    public float lineWidth = 0.1f; // the width of the circle's boundary line
    public Color lineColor = Color.yellow; // the color of the circle's boundary line

    private LineRenderer lineRenderer; // the LineRenderer component used to draw the circle

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>(); // add a LineRenderer component to the object
        lineRenderer.useWorldSpace = false; // use local coordinates for the line renderer
        lineRenderer.startWidth = lineWidth; // set the line width
        lineRenderer.endWidth = lineWidth; // set the line width
        lineRenderer.material.color = lineColor; // set the line color
        DrawCircle(); // draw the circle
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
    }



    //public float radius = 1f; // the radius of the circle
    //public int numSegments = 32; // the number of line segments used to draw the circle

    //private LineRenderer lineRenderer; // the LineRenderer component used to draw the circle

    //void Start()
    //{
    //    // create a new GameObject with a LineRenderer component
    //    GameObject lineObject = new GameObject("Circle");

    //    lineRenderer = lineObject.AddComponent<LineRenderer>();

    //    //lineRenderer.endColor = Color.cyan;
    //    //lineRenderer.startColor = Color.green;


    //    // set the LineRenderer's properties
    //    lineRenderer.positionCount = numSegments + 1; // add one extra point to complete the circle
    //    lineRenderer.useWorldSpace = false; // use local coordinates

    //}
    //void Update()
    //{
    //    // calculate the points on the circle using the sin and cos functions
    //    Vector3[] points = new Vector3[numSegments + 1];
    //    for (int i = 0; i <= numSegments; i++)
    //    {
    //        float angle = i * 2f * Mathf.PI / numSegments;
    //        float x = Mathf.Sin(angle) * radius;
    //        float y = Mathf.Cos(angle) * radius;

    //        points[i] = new Vector3(x, y, 0);
    //    }

    //    // set the LineRenderer's points to the calculated points
    //    lineRenderer.SetPositions(points);
    //}
}
