//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CircleBorder : MonoBehaviour
//{
//    public float radius = 1f; // the radius of the circle
//    public float lineWidth = 0.1f; // the width of the circle's boundary line
//    public Color lineColor = Color.yellow; // the color of the circle's boundary line
//    public float gravityScale = 0f; // the gravity scale of the circle's Rigidbody2D

//    private LineRenderer lineRenderer; // the LineRenderer component used to draw the circle
//    private Rigidbody2D rb2d; // the Rigidbody2D component used to make the circle a collider

//    void Start()
//    {
//        lineRenderer = gameObject.AddComponent<LineRenderer>(); // add a LineRenderer component to the object
//        lineRenderer.useWorldSpace = false; // use local coordinates for the line renderer
//        lineRenderer.startWidth = lineWidth; // set the line width
//        lineRenderer.endWidth = lineWidth; // set the line width
//        lineRenderer.material.color = lineColor; // set the line color
//        DrawCircle(); // draw the circle

//        // add a Rigidbody2D component to the object
//        rb2d = gameObject.AddComponent<Rigidbody2D>();
//        // set the gravity scale of the Rigidbody2D to prevent objects from exiting the circle
//        rb2d.gravityScale = gravityScale;
//        // make the Rigidbody2D a kinematic collider
//        rb2d.bodyType = RigidbodyType2D.Kinematic;
//        // add a CircleCollider2D component to the object
//        CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
//        // set the radius of the CircleCollider2D to the same as the circle's radius
//        circleCollider.radius = radius;
//        // set the CircleCollider2D to be a trigger collider
//        circleCollider.isTrigger = true;
//    }

//    void DrawCircle()
//    {
//        int segments = 64; // the number of line segments used to draw the circle
//        float anglePerSegment = 2f * Mathf.PI / segments; // the angle between each line segment
//        Vector3[] points = new Vector3[segments + 1]; // an array to hold the points on the circle's circumference
//        for (int i = 0; i < segments + 1; i++)
//        {
//            float angle = i * anglePerSegment; // the angle of the current point
//            points[i] = new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius, 0f); // calculate the position of the current point
//        }
//        lineRenderer.positionCount = segments + 1; // set the number of points in the line renderer
//        lineRenderer.SetPositions(points); // set the positions of the points in the line renderer
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBorder : MonoBehaviour
{
    public float radius = 4f; // the radius of the circle
    public float lineWidth = 0.1f; // the width of the circle's boundary line
    public Color lineColor = Color.white; // the color of the circle's boundary line

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

    public void AttachToCircle(GameObject obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = obj.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        FixedJoint2D fj = obj.AddComponent<FixedJoint2D>();
        fj.connectedBody = this.GetComponent<Rigidbody2D>();
    }
}


