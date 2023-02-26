using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistogramCounter : MonoBehaviour
{
    GameObject redBar;
    GameObject blueBar;
    GameObject[] redBall;
    GameObject[] blueBall;

    private void Awake()
    {
        redBall = GameObject.FindGameObjectsWithTag("RedBall");
        blueBall = GameObject.FindGameObjectsWithTag("BlueBall");
        redBar = GameObject.FindWithTag("RedHistogram");
        blueBar = GameObject.FindWithTag("BlueHistogram");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        Debug.Log("Red ball count: " + redBall.Length);
        int actualRedY = redBall.Length;
        redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(redBar.GetComponent<SpriteRenderer>().transform.localScale.x, actualRedY);

        Debug.Log("Blue ball count: " + blueBall.Length);
        int actualBlueY = blueBall.Length;
        blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x, actualBlueY);
    }
}
