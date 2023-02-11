using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckLosingConditionL2 : MonoBehaviour
{
    // Start is called before the first frame update
    System.DateTime startTime, endTime;
    string levelName;

    void Start()
    {
        startTime = System.DateTime.Now;
        levelName = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {
        // Add losing popup
        if (!GameObject.FindWithTag("BlueSplitterTriangle") &&
            GameObject.FindGameObjectsWithTag("RedBall").Length != GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            Debug.Log("You lose");
            this.enabled = false;
            endTime = System.DateTime.Now;
            Debug.Log("start"+startTime);

            Debug.Log("end"+ endTime);

            int timeTakenn = (int)(endTime - startTime).TotalSeconds;
            
            AnalyticsManager._instance.analytics_time_takenn(levelName, timeTakenn, "Lost");
        }
    }
}
