using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistogramCounter : MonoBehaviour
{
    GameObject redBar;
    GameObject blueBar;

    private void Awake()
    {
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
        redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(redBar.GetComponent<SpriteRenderer>().transform.localScale.x, GameObject.FindGameObjectsWithTag("RedBall").Length);
        blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x, GameObject.FindGameObjectsWithTag("BlueBall").Length);
    }
}
