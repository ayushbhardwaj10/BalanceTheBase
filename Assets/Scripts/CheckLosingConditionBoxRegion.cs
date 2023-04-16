using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class CheckLosingConditionBoxRegion : MonoBehaviour
{
    public GameObject losingPopup;
    DateTime startTime, endTime;
    string levelName;
    public static bool lostStatus;
    int blueCount = 0;
    int redCount = 0;
    FindBallCountShakeVarient findBallCountShakeVarient;
    public static List<int> exitedIdList; 

    public void DisableLoosingPopup()
    {
        Debug.Log("close popup loose");
        losingPopup.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        lostStatus = false;
        startTime = DateTime.Now;
        levelName = SceneManager.GetActiveScene().name;
        findBallCountShakeVarient = new FindBallCountShakeVarient();
        findBallCountShakeVarient.blueCountInt = blueCount;
        findBallCountShakeVarient.redCountInt = redCount;

        exitedIdList = new List<int>();

        InvokeRepeating("LossChecker", 0.0f, 1.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game object tag: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("BlueBall") || collision.gameObject.CompareTag("RedBall"))
        {
            blueCount = GameObject.FindGameObjectsWithTag("BlueBall").Length;
            redCount = GameObject.FindGameObjectsWithTag("RedBall").Length;
            findBallCountShakeVarient.blueCountInt = blueCount;
            findBallCountShakeVarient.redCountInt = redCount;
        }

        Debug.Log("BlueCount: " + blueCount);
        Debug.Log("RedCount: " + redCount);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit Game object tag: " + collision.gameObject.name);
        // Remove the GameObject collided with from the list.
        if ("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag))
        {
            //Destroy the game object
            exitedIdList.Add(collision.gameObject.GetInstanceID());

            blueCount = 0;
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("BlueBall"))
            {
                //exitedIdList is needed to handle ball counts when multiple balls exit at the same time
                if (exitedIdList.Contains(ball.GetInstanceID()))
                    continue;
                blueCount += 1;
            }

            redCount = 0;
            foreach (GameObject ball in GameObject.FindGameObjectsWithTag("RedBall"))
            {
                if (exitedIdList.Contains(ball.GetInstanceID()))
                    continue;
                redCount += 1;
            }

            findBallCountShakeVarient.blueCountInt = blueCount;
            findBallCountShakeVarient.redCountInt = redCount;
        }
        
        Debug.Log("Exit BlueCount: " + blueCount);
        Debug.Log("Exit RedCount: " + redCount);
    }

    // int DestroyBallOnExit(Collider2D collision)
    // {
    //     List<int> deletedIdList = new List<int>(); 
        
    //     //Get instance ID of the deleted objects for updating state
    //     int deletedID = collision.gameObject.GetInstanceID();
    //     deletedIdList.Add(deletedID);
    //     Destroy(collision.gameObject);

    //     //Update game state
    //     GameStateTracking.UpdateGameStack(deletedIdList, "Destroy out of bounds script: " + collision.gameObject.name);

    //     return deletedID;
    // }

    void LossChecker()
    {
        if (!lostStatus && ((!GameObject.FindWithTag("BlueSplitterTriangle") && !GameObject.FindWithTag("RedSplitterTriangle") &&
            !GameObject.FindWithTag("BlinkingSplitter") && redCount != blueCount) || (redCount == 0 && blueCount == 0))) {
            lostStatus = true;

            Debug.Log("YOU LOSE!");
            losingPopup.SetActive(true);
            // this.enabled = false; //added to get out of Update - IMPORTANT
            endTime = DateTime.Now;
            int time_taken = (int)(endTime - startTime).TotalSeconds;
            Debug.Log("time taken in Losing Condition" + time_taken);
            int user_rating = GamesManager._instance.calculate_user_ratings(GamesManager.LOST, levelName, time_taken);
            Debug.Log("User rating in Losing Condition " + user_rating);
            //GetComponent<StarHandler>().starsAcheived(user_rating);            
            //Debug.Log("setting up Losing Condition pop-up");

            RestartButton.prev_level = SceneManager.GetActiveScene().name;

            Debug.Log("Prev scene lost " + RestartButton.prev_level);

            //Analytics for time taken
            AnalyticsManager._instance.analytics_time_takenn(levelName, time_taken, GamesManager.LOST, RestartButton.isRestartClicked);

            //Analytics for user ratings
            AnalyticsManager._instance.analytics_user_ratings(levelName, time_taken, user_rating, GamesManager.LOST);
        }
    }
}