using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class KillerLevelCheckLosingCondition : MonoBehaviour
{
    public GameObject losingPopup;
    DateTime startTime, endTime;
    string levelName;
    public static bool lostStatus;

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

        InvokeRepeating ("LossChecker", 0.0f, 1.0f);
    }

    // Update is called once per second
    void LossChecker()
    {
        if (EatingTimer.timeLeft == 0 && !lostStatus && !GameObject.FindWithTag("BlueSplitterTriangle") && !GameObject.FindWithTag("RedSplitterTriangle") &&
            !GameObject.FindWithTag("BlinkingSplitter") &&
            GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length !=
            GameObject.FindGameObjectsWithTag("BlueBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length)
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
}
