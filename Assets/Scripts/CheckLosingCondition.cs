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
            GameObject.FindGameObjectsWithTag("RedBall").Length != GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            Debug.Log("You lose");   
            this.enabled = false; //added to get out of Update - IMPORTANT
            endTime = DateTime.Now;
            int time_taken = (int)(endTime - startTime).TotalSeconds;
            AnalyticsManager._instance.analytics_time_takenn(levelName, time_taken, GamesManager.LOST);

            int user_rating = GamesManager._instance.calculate_user_ratings(GamesManager.LOST, levelName, time_taken);
            Debug.Log("User rating is " + user_rating);
            losingPopup.SetActive(true);
        }
    }
}
