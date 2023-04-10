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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlueBall"))
        {
            blueCount++;
        }
        if (collision.gameObject.CompareTag("RedBall"))
        {
            redCount++;
        }

        Debug.Log("BlueCount: " + blueCount);
        Debug.Log("RedCount: " + redCount);
        if (!lostStatus && !GameObject.FindWithTag("BlueSplitterTriangle") && !GameObject.FindWithTag("RedSplitterTriangle") &&
            !GameObject.FindWithTag("BlinkingSplitter") && redCount != blueCount)
        {
            LossChecker();
        }
        if (!lostStatus && redCount == 0 && blueCount == 0)
        {
            Debug.Log("In here");
            LossChecker();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        // Remove the GameObject collided with from the list.
        if ("BlueBall".Equals(collision.gameObject.tag))
        {
            blueCount--;
        }
        if ("RedBall".Equals(collision.gameObject.tag))
        {
            redCount--;
        }
        Debug.Log("BlueCount: " + blueCount);
        Debug.Log("RedCount: " + redCount);
        if (!lostStatus && !GameObject.FindWithTag("BlueSplitterTriangle") && !GameObject.FindWithTag("RedSplitterTriangle") &&
            !GameObject.FindWithTag("BlinkingSplitter") && redCount != blueCount)
        {
            LossChecker();
        }
        if (!lostStatus && redCount == 0 && blueCount == 0)
        {
            LossChecker();
        }
    }

    void LossChecker()
    {
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