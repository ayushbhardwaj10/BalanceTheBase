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
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(-(verticalInput * moveSpeed) * Time.deltaTime,0, 0));
    }
}
