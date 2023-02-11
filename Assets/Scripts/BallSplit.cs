using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BallSplit : MonoBehaviour
{

    string levelName;

    void Start()
    {
        
        levelName = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject);
        //First destrory and then instantiate
        Destroy(gameObject);

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        collision.gameObject.GetComponent<SpriteRenderer>().color = renderer.color;
        Instantiate(collision.gameObject, collision.transform.position, collision.transform.rotation);
        AnalyticsManager._instance.analytics_split_record(levelName, DateTime.Now, renderer.tag, collision.gameObject.tag);
    }
}
