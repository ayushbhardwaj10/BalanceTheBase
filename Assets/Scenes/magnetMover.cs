using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0, horizontalInput * moveSpeed * Time.deltaTime, 0));
    }
}
