using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class CheckLosingCondition : MonoBehaviour
{
    public GameObject losingPopup;
    DateTime startTime, endTime;
    string levelName;

    public void DisableLoosingPopup()
    {
        Debug.Log("close popup loose");
        losingPopup.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
        levelName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindWithTag("BlueSplitterTriangle") && !GameObject.FindWithTag("RedSplitterTriangle") &&
            !GameObject.FindWithTag("BlinkingSplitter") &&
            GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length !=
            GameObject.FindGameObjectsWithTag("BlueBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length)
        {
            Debug.Log("You lose");
            losingPopup.SetActive(true);
            this.enabled = false; //added to get out of Update - IMPORTANT
            endTime = DateTime.Now;
            int time_taken = (int)(endTime - startTime).TotalSeconds;
            Debug.Log("time taken in Losing Condition" + time_taken);
            int user_rating = GamesManager._instance.calculate_user_ratings(GamesManager.LOST, levelName, time_taken);
            Debug.Log("User rating in Losing Condition " + user_rating);
            //GetComponent<StarHandler>().starsAcheived(user_rating);            
            //Debug.Log("setting up Losing Condition pop-up");

            //Analytics for time taken
            AnalyticsManager._instance.analytics_time_takenn(levelName, time_taken, GamesManager.LOST);

            //Analytics for user ratings
            AnalyticsManager._instance.analytics_user_ratings(levelName, time_taken, user_rating, GamesManager.LOST);

            losingPopup.SetActive(true);
        }
    }
}
