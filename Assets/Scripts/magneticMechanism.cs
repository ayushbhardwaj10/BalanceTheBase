using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magneticMechanism : MonoBehaviour
{
    public float forceFactor = 1000f;
    List<Rigidbody2D> rgbBalls = new List<Rigidbody2D>();
    Transform magnetPoint;
    private Renderer rend;
    SpriteRenderer spriteRenderer;


    Color blueCustomColor = new Color(23f / 255f, 153f / 255f, 231f / 255f);
    Color redCustomColor = new Color(1f, 0f, 0f);

    bool isBlue = true;

    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("started..");
        magnetPoint = GetComponent<Transform>();
        rend = GetComponent<Renderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();

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
       
        if (other.CompareTag("BlueBall")) {
            rgbBalls.Add(other.GetComponent<Rigidbody2D>());
        }
        //if (other.CompareTag("sampleBall"))
        //{
        //    rgbBalls.Add(other.GetComponent<Rigidbody2D>());
        //}


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("BlueBall") || other.CompareTag("RedBall"))
        {
            rgbBalls.Remove(other.GetComponent<Rigidbody2D>());
        }

        //if (other.CompareTag("sampleBall"))
        //{
        //    rgbBalls.Remove(other.GetComponent<Rigidbody2D>());
        //}
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Color currentColor = spriteRenderer.color;
    //        Debug.Log("Color currentColor = spriteRenderer.color;" + currentColor);
    //        Debug.Log(currentColor == blueCustomColor);

    //        if (currentColor == blueCustomColor)
    //        {
    //            rend.material.color = redCustomColor;
    //        }
    //        else {
    //            rend.material.color = blueCustomColor;
    //        } 


    //    }
    //    if (rend.material.color == Color.red)
    //    {
    //        Debug.Log("The color of the game object is red.");
    //    }
    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBlue)
            {
                spriteRenderer.color = redCustomColor;
                isBlue = false;
            }
            else
            {
                spriteRenderer.color = blueCustomColor;
                isBlue = true;
            }
        }

        if (spriteRenderer.color == Color.red)
        {
            Debug.Log("The color of the game object is red.");
        }
    }
}
