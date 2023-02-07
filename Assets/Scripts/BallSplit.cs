using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallSplit : MonoBehaviour
{
    // Start is called before the first frame update
    //private static int num_times_ballsplit = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Code Ran");
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        collision.gameObject.GetComponent<SpriteRenderer>().color = renderer.color;
        Instantiate(collision.gameObject, collision.transform.position, collision.transform.rotation);
        AnalyticsManager._instance.analytics_split_record(1, DateTime.Now, renderer.tag, collision.gameObject.tag);

        Destroy(gameObject);
    }
}
