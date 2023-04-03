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
    bool isMagnetActive = false;

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
        if (isMagnetActive == true) {

            foreach (Rigidbody2D rgbBall in rgbBalls)
            {
                //rgbBall.AddForce((magnetPoint.position - rgbBall.position) * forceFactor * Time.fixedDeltaTime);
                rgbBall.AddForce((magnetPoint.position - new Vector3(rgbBall.position.x, rgbBall.position.y, 0f)) * forceFactor * Time.fixedDeltaTime);

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isBlue == true)
        {
            if (other.CompareTag("BlueBall"))
            {
                rgbBalls.Add(other.GetComponent<Rigidbody2D>());
            }
        }
        else {
            if (other.CompareTag("RedBall"))
            {
                rgbBalls.Add(other.GetComponent<Rigidbody2D>());
            }
        }  
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit..");
        rgbBalls.Clear();

        if (other.CompareTag("BlueBall") || other.CompareTag("RedBall"))
        {
            rgbBalls.Remove(other.GetComponent<Rigidbody2D>());
        }
   
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isBlue == true)
        {
            if (other.CompareTag("BlueBall"))
            {
                rgbBalls.Add(other.GetComponent<Rigidbody2D>());
            }
        }
        else
        {
            if (other.CompareTag("RedBall"))
            {
                rgbBalls.Add(other.GetComponent<Rigidbody2D>());
            }
        }

    }

    void Update()
    {
        // Toggle switching ON and OFF of magnet
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            isMagnetActive = !isMagnetActive;
            Debug.Log("magnet :" + isMagnetActive);

            if (isMagnetActive == false)
            {
                spriteRenderer.color = Color.white;
                rgbBalls.Clear();
            }
            else
            {
                if (isBlue)
                {
                    spriteRenderer.color = blueCustomColor;      
                }
                else
                {
                    spriteRenderer.color = redCustomColor;
                }
            }
        }

        if (isMagnetActive == true) {
            // Toggle changing colors of magnet
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (isBlue)
                {
                    spriteRenderer.color = redCustomColor;
                    isBlue = false;

                    rgbBalls.Clear();
                }
                else
                {
                    spriteRenderer.color = blueCustomColor;
                    isBlue = true;

                    rgbBalls.Clear();
                }
            }
        }

        if (spriteRenderer.color == Color.red)
        {
            Debug.Log("The color of the game object is red.");
        }
    }
}
