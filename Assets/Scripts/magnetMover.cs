using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class magnetMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool upperLimitReached = false;
    private bool lowerLimitReached = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // if (transform.position.y <= GameObject.Find("Upper Limit").transform.position.y)
            if (!upperLimitReached)
            {
                transform.Translate(new Vector3(-(verticalInput * moveSpeed) * Time.deltaTime, 0, 0));
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // if (transform.position.y >= GameObject.Find("Lower Limit").transform.position.y)
            if (!lowerLimitReached)
            {
                transform.Translate(new Vector3(-(verticalInput * moveSpeed) * Time.deltaTime, 0, 0));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Upper Limit")
        {
            upperLimitReached = true;
        }

        if (collision.gameObject.name == "Lower Limit")
        {
            lowerLimitReached = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Upper Limit")
        {
            upperLimitReached = false;
        }

        if (collision.gameObject.name == "Lower Limit")
        {
            lowerLimitReached = false;
        }
    }
}
