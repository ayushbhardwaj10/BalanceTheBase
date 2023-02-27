using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistogramCounter : MonoBehaviour
{
    GameObject redBar;
    GameObject blueBar;
    [SerializeField] private bool increaseFromTop = true;
    int redCount;
    int blueCount;

    private void Awake()
    {
        redBar = GameObject.FindWithTag("RedHistogram");
        blueBar = GameObject.FindWithTag("BlueHistogram");
    }

    // Start is called before the first frame update
    void Start()
    {
        redCount = 0;
        blueCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(redCount);
        int direction = increaseFromTop ? 1 : -1;
        if (redCount < GameObject.FindGameObjectsWithTag("RedBall").Length)
        {
            Debug.Log("came inside red increase");
            redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(redBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.y + (GameObject.FindGameObjectsWithTag("RedBall").Length * direction),
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.z);
            redCount = GameObject.FindGameObjectsWithTag("RedBall").Length;
        } else if (redCount > GameObject.FindGameObjectsWithTag("RedBall").Length)
        {
            redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(redBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.y - (GameObject.FindGameObjectsWithTag("RedBall").Length * direction),
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.z);
            redCount = GameObject.FindGameObjectsWithTag("RedBall").Length;
        }

        if (blueCount < GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.y + (GameObject.FindGameObjectsWithTag("BlueBall").Length * direction),
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.x);
            blueCount = GameObject.FindGameObjectsWithTag("BlueBall").Length;
        } else if (blueCount > GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.y - (GameObject.FindGameObjectsWithTag("BlueBall").Length * direction),
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.x);
            blueCount = GameObject.FindGameObjectsWithTag("BlueBall").Length;
        }
    }
}
