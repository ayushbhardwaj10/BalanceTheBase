using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BallSplit : MonoBehaviour
{
    
    string levelName,splitterMomentColor;
    

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
        if(!(collision.gameObject.tag != null && collision.gameObject.tag.Contains("Ball")))
            return;

        //Do not change these colors ever
        Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
        Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);
        List<int> deletedIdList = new List<int>(); 

        //Used for analytics
        string ballColorBeforeCollision = collision.gameObject.tag;

        //First destroy the spillter and then instantiate the balls
        String tagName = gameObject.tag;
        
        //Get instance ID of the deleted objects for updating state
        int deletedID = gameObject.GetInstanceID();
        deletedIdList.Add(deletedID);
        Destroy(gameObject);

        Debug.Log(tagName + " " + GameObject.FindGameObjectsWithTag(tagName).Length);

        //Get the color of the splitter and assign it to the ball
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        collision.gameObject.GetComponent<SpriteRenderer>().color = renderer.color;
        
        //Clone the ball
        var go = Instantiate(collision.gameObject, collision.transform.position, collision.transform.rotation);

        //Add tags for the new balls
        if(collision.gameObject.tag=="PinkBall_RedBall")
        {
            if(blueColor == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                collision.gameObject.tag = "PinkBall_BlueBall"; //original ball
                go.gameObject.tag = "PinkBall_BlueBall"; //cloned ball
            }
        }
        else if(collision.gameObject.tag=="PinkBall_BlueBall")
        {
            if(redColor == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                collision.gameObject.tag = "PinkBall_RedBall";
                go.gameObject.tag = "PinkBall_RedBall";
            }
        }
        else
        {
            if(blueColor == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                go.gameObject.tag = "BlueBall";
                collision.gameObject.tag="BlueBall";
            }
            else if(redColor == collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                go.gameObject.tag = "RedBall";
                collision.gameObject.tag="RedBall";
            }
        }

        //Get splitter colour based on
        splitterMomentColor = collision.gameObject.tag.Contains("RedBall") ? "RedSplitterTriangle" : "BlueSplitterTriangle";

        

        //Save collision in analytics
        AnalyticsManager._instance.analytics_split_record(levelName, DateTime.Now, splitterMomentColor, ballColorBeforeCollision, gameObject.name);

        Debug.Log("Tag "  + gameObject.tag);
        Debug.Log("Name "+ gameObject.name);

        //Update game state
        GameStateTracking.UpdateGameStack(deletedIdList);
    
    }
}
