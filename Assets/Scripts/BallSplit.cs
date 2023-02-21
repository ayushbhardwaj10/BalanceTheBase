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

        // Nothing should happen if colliding with a non-player object (anything other than red/blue balls)
        if(!("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag) ||
        "PinkBall_BlueBall".Equals(collision.gameObject.tag)))
        {
            return;
        }


       Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
       Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);

        string ballColorBeforeCollision = collision.gameObject.tag;

        //First destroy the spillter and then instantiate the balls
        Destroy(gameObject);

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        collision.gameObject.GetComponent<SpriteRenderer>().color = renderer.color;
        var go = Instantiate(collision.gameObject, collision.transform.position, collision.transform.rotation);

        if(collision.gameObject.tag=="PinkBall_RedBall"){
            if(gameObject.tag == "BlueSplitterTriangle"){
                collision.gameObject.tag = "PinkBall_BlueBall";
                go.gameObject.tag = "PinkBall_BlueBall";
            }
        } else if(collision.gameObject.tag=="PinkBall_BlueBall"){
            Debug.Log("hh");
            if(gameObject.tag == "RedSplitterTriangle"){
                Debug.Log("gg");
                collision.gameObject.tag = "PinkBall_RedBall";
                go.gameObject.tag = "PinkBall_RedBall";
            }
        }
    
        if(collision.gameObject.tag!="PinkBall_RedBall" && collision.gameObject.tag!="PinkBall_BlueBall"){
        if(blueColor==(collision.gameObject.GetComponent<SpriteRenderer>().color)){
       collision.gameObject.tag="BlueBall";
        } else if(redColor==(collision.gameObject.GetComponent<SpriteRenderer>().color)){
       collision.gameObject.tag="RedBall";
        }


       if(blueColor==(go.GetComponent<SpriteRenderer>().color)){
           go.gameObject.tag = "BlueBall";
       } else if(redColor==(go.GetComponent<SpriteRenderer>().color)){
           go.gameObject.tag = "RedBall";
       }
       }

       
        AnalyticsManager._instance.analytics_split_record(levelName, DateTime.Now, renderer.tag, ballColorBeforeCollision);
    }
}
