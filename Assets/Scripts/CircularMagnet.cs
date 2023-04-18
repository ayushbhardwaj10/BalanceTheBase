using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMagnet : MonoBehaviour
{
    public float speed = 5f;
    public float radius = 5f;

    private float angle = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            angle += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            angle -= speed * Time.deltaTime;
        }

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, 0f);
    }
}
