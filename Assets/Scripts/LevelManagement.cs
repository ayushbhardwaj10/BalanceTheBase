using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManagement : MonoBehaviour
{


    public void levelChangeTo01() {
        AnalyticsManager._instance.analytics_start_level("Level_0_1",DateTime.Now);
        SceneManager.LoadScene("Level_0_1");
    }
    public void levelChangeTo02()
    {
        AnalyticsManager._instance.analytics_start_level("Level_0_2", DateTime.Now);
        SceneManager.LoadScene("Level_0_2");
    }
    public void levelChangeTo03()
    {
        AnalyticsManager._instance.analytics_start_level("Level_0_3",DateTime.Now);
        SceneManager.LoadScene("Level_0_3");
    }
    public void levelChangeTo04()
    {
        AnalyticsManager._instance.analytics_start_level("Level_0_4",DateTime.Now);
        SceneManager.LoadScene("Level_0_4");
    }
    public void levelChangeTo11()
    {
        AnalyticsManager._instance.analytics_start_level("Level_1_1", DateTime.Now);
        SceneManager.LoadScene("Level_1_1");
    }
    public void levelChangeTo12()
    {
        AnalyticsManager._instance.analytics_start_level("Level_1_2", DateTime.Now);
        SceneManager.LoadScene("Level_1_2");
    }
    public void levelChangeTo13()
    {
        AnalyticsManager._instance.analytics_start_level("Level_1_3", DateTime.Now);
        SceneManager.LoadScene("Level_1_3");
    }
    public void levelChangeToLevelManager()
    {
        Debug.Log("level manager called");
        SceneManager.LoadScene("Level Manager");
    }
    public void restartLevel() {
        //GameStateTracking.clearStack();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
