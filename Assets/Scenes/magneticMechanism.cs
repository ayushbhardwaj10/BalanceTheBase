using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magneticMechanism : MonoBehaviour
{
    public float forceFactor = 200f;
    List<Rigidbody2D> rgbBalls = new List<Rigidbody2D>();
    Transform magnetPoint;
 

    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("started..");
        magnetPoint = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        foreach (Rigidbody2D rgbBall in rgbBalls) {
            //rgbBall.AddForce((magnetPoint.position - rgbBall.position) * forceFactor * Time.fixedDeltaTime);
            rgbBall.AddForce((magnetPoint.position - new Vector3(rgbBall.position.x, rgbBall.position.y, 0f)) * forceFactor * Time.fixedDeltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("sampleBall")) {
            rgbBalls.Add(other.GetComponent<Rigidbody2D>());
        }

       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("sampleBall"))
        {
            rgbBalls.Remove(other.GetComponent<Rigidbody2D>());
        }
    }
    // Update is called once per frame
    //void Update()
    //{

    //}
}
