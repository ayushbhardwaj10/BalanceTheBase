using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistogramCounter : MonoBehaviour
{
    GameObject redBar;
    GameObject blueBar;
    GameObject redBall;
    GameObject blueBall;

    private void Awake()
    {
        redBall = GameObject.FindGameObjectWithTag("RedBall");
        blueBall = GameObject.FindGameObjectWithTag("BlueBall");
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
        if (redBall)
        {
            Debug.Log("Red ball count: " + redBall.transform.childCount);
            int actualRedY = redBall.transform.childCount;
            redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(redBar.GetComponent<SpriteRenderer>().transform.localScale.x, actualRedY);
        }

        if (blueBall)
        {
            int actualBlueY = blueBall.transform.childCount;
            blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x, actualBlueY);
        }
    }
}
