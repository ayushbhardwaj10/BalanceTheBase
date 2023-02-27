using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistogramCounter : MonoBehaviour
{
    GameObject redBar;
    GameObject blueBar;
    [SerializeField] private bool increaseFromTop = true;
    [SerializeField] private float scaleYFactor = 0.5f;

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
        int direction = increaseFromTop ? 1 : -1;
        redBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(redBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                    GameObject.FindGameObjectsWithTag("RedBall").Length + (scaleYFactor * Time.deltaTime * direction),
                                                                    redBar.GetComponent<SpriteRenderer>().transform.localScale.z);

        blueBar.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(blueBar.GetComponent<SpriteRenderer>().transform.localScale.x,
                                                                     GameObject.FindGameObjectsWithTag("BlueBall").Length + (scaleYFactor * Time.deltaTime * direction),
                                                                     blueBar.GetComponent<SpriteRenderer>().transform.localScale.x);
    }
}
