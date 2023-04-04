using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class magnetMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float h_xRange = 1.2f;
    public float l_xRange = -0.84f;

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
            if (transform.position.y <= GameObject.Find("Upper Limit").transform.position.y)
            {
                transform.Translate(new Vector3(-(verticalInput * moveSpeed) * Time.deltaTime, 0, 0));
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y >= GameObject.Find("Lower Limit").transform.position.y)
            {
                transform.Translate(new Vector3(-(verticalInput * moveSpeed) * Time.deltaTime, 0, 0));
            }
        }
    }
}
