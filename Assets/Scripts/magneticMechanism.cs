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
    public float dampingValue = 0.5f;


    Color blueCustomColor = new Color(23f / 255f, 153f / 255f, 231f / 255f);
    Color redCustomColor = new Color(1f, 0f, 0f);

    bool isBlue = false;
    bool isMagnetActive = false;

    // Start is called before the first frame update

    void Start()
    {
        Time.fixedDeltaTime = 0.04f;

        magnetPoint = GetComponent<Transform>();
        rend = GetComponent<Renderer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();
        if ((other.CompareTag("BlueBall") || other.CompareTag("RedBall")) && rb2d != null && !rgbBalls.Contains(rb2d))
        {
            rgbBalls.Add(rb2d);
        }
        Debug.Log("Updated ball count - " + rgbBalls.Count); 
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb2d = other.GetComponent<Rigidbody2D>();
        if ((other.CompareTag("BlueBall") || other.CompareTag("RedBall")) && rb2d != null && !rgbBalls.Contains(rb2d))
        {
            rgbBalls.Add(rb2d);
        }
        Debug.Log("Updated ball count - " + rgbBalls.Count);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BlueBall") || other.CompareTag("RedBall"))
        {
            rgbBalls.Remove(other.GetComponent<Rigidbody2D>());
        }
    }

    void FixedUpdate()
    {
        if (isMagnetActive == true) {
            foreach (Rigidbody2D rgbBall in rgbBalls)
            {
                if(isBlue == true)
                {
                    if(rgbBall.gameObject.CompareTag("BlueBall"))
                    {
                        rgbBall.AddForce((magnetPoint.position - new Vector3(rgbBall.position.x, rgbBall.position.y, 0f)).normalized * forceFactor * Time.fixedDeltaTime);
                        rgbBall.velocity *= (1 - dampingValue * Time.fixedDeltaTime);
                    }
                }
                else
                {
                    if(rgbBall.gameObject.CompareTag("RedBall"))
                    {
                        rgbBall.AddForce((magnetPoint.position - new Vector3(rgbBall.position.x, rgbBall.position.y, 0f)).normalized * forceFactor * Time.fixedDeltaTime);
                        rgbBall.velocity *= (1 - dampingValue * Time.fixedDeltaTime);
                    }
                }
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            if(isMagnetActive == true && isBlue == false)
            {
                spriteRenderer.color = Color.white;
                isMagnetActive = false;
            }
            else if(isMagnetActive == true && isBlue == true)
            {
                spriteRenderer.color = redCustomColor;
                isMagnetActive = true;
                isBlue = false;
            }
            else
            {
                spriteRenderer.color = blueCustomColor;
                isMagnetActive = true;
                isBlue = true;
            }
        }

        // Toggle switching ON and OFF of magnet
        // if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        // {
        //     Debug.Log("Magnet control - Left-shift clicked");
        //     isMagnetActive = !isMagnetActive;
        //     Debug.Log("magnet :" + isMagnetActive);

        //     if (isMagnetActive == false)
        //     {
        //         spriteRenderer.color = Color.white;
        //         rgbBalls.Clear();
        //     }
        //     else
        //     {
        //         if (isBlue)
        //         {
        //             spriteRenderer.color = blueCustomColor;      
        //         }
        //         else
        //         {
        //             spriteRenderer.color = redCustomColor;
        //         }
        //     }
        // }

        // if (isMagnetActive == true) {
        //     // Toggle changing colors of magnet
        //     if (Input.GetKeyDown(KeyCode.Tab))
        //     {
        //         if (isBlue)
        //         {
        //             spriteRenderer.color = redCustomColor;
        //             isBlue = false;

        //             rgbBalls.Clear();
        //             Debug.Log("Magnet control - TAB clicked");
        //         }
        //         else
        //         {
        //             spriteRenderer.color = blueCustomColor;
        //             isBlue = true;

        //             rgbBalls.Clear();
        //             Debug.Log("Magnet control - TAB clicked");
        //         }
        //     }
        // }

        // if (spriteRenderer.color == Color.red)
        // {
        //     Debug.Log("The color of the game object is red.");
        // }
    }
}
