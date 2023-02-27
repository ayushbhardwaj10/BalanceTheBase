using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistogramCounter : MonoBehaviour
{
    GameObject redBar;
    GameObject blueBar;
    [SerializeField] private bool increaseFromTop = true;
    [SerializeField] private Canvas canvas;
    [SerializeField] private SpriteRenderer sprite1;
    [SerializeField] private SpriteRenderer sprite2;
    [SerializeField] private SpriteRenderer sprite3;
    [SerializeField] private int sortingOrder = 0;

    public GameObject BText;
    public GameObject EqualText;
    public GameObject RText;

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
        canvas.sortingOrder = sortingOrder + 2;
        sprite1.sortingOrder = sortingOrder + 1;
        sprite2.sortingOrder = sortingOrder;
        sprite3.sortingOrder = sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        int direction = increaseFromTop ? 1 : -1;
        if (redCount < GameObject.FindGameObjectsWithTag("RedBall").Length)
        {
            redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(redBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.y + (GameObject.FindGameObjectsWithTag("RedBall").Length * 0.5f * direction),
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.z);
            redCount = GameObject.FindGameObjectsWithTag("RedBall").Length;
        } else if (redCount > GameObject.FindGameObjectsWithTag("RedBall").Length)
        {
            redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(redBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.y - (GameObject.FindGameObjectsWithTag("RedBall").Length * 0.5f * direction),
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.z);
            redCount = GameObject.FindGameObjectsWithTag("RedBall").Length;
        }

        if (blueCount < GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.y + (GameObject.FindGameObjectsWithTag("BlueBall").Length * 0.5f * direction),
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.x);
            blueCount = GameObject.FindGameObjectsWithTag("BlueBall").Length;
        } else if (blueCount > GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.y - (GameObject.FindGameObjectsWithTag("BlueBall").Length * 0.5f * direction),
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.x);
            blueCount = GameObject.FindGameObjectsWithTag("BlueBall").Length;
        }

        Debug.Log("Red count: " + redCount);
        Debug.Log("Blue count: " + blueCount);


        if (blueCount == redCount)
        {
            BText.SetActive(true);
            EqualText.SetActive(true);
            RText.SetActive(true);
        } else
        {
            BText.SetActive(false);
            EqualText.SetActive(false);
            RText.SetActive(false);
        }
    }
}
