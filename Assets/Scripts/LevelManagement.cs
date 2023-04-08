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
    public void levelChangeTo14()
    {
        AnalyticsManager._instance.analytics_start_level("Level_1_4", DateTime.Now);
        SceneManager.LoadScene("Level_1_4");
    }
    public void levelChangeTo21()
    {
        AnalyticsManager._instance.analytics_start_level("Level_2_1", DateTime.Now);
        SceneManager.LoadScene("Level_2_1");
    }
    public void levelChangeTo23()
    {
        AnalyticsManager._instance.analytics_start_level("Level_2_3", DateTime.Now);
        SceneManager.LoadScene("Level_2_3");
    }
    public void levelChangeTo22()
    {
        AnalyticsManager._instance.analytics_start_level("Level_2_2", DateTime.Now);
        SceneManager.LoadScene("Level_2_2");
    }
    public void levelChangeTo31()
    {
        AnalyticsManager._instance.analytics_start_level("Level_3_1", DateTime.Now);
        SceneManager.LoadScene("Level_3_1");
    }
    public void levelChangeTo32()
    {
        AnalyticsManager._instance.analytics_start_level("Level_3_2", DateTime.Now);
        SceneManager.LoadScene("Level_3_2");
    }
    public void levelChangeTo42()
    {
        AnalyticsManager._instance.analytics_start_level("Level_4_2", DateTime.Now);
        SceneManager.LoadScene("Level_4_2");
    }
    public void levelChangeTo43()
    {
        AnalyticsManager._instance.analytics_start_level("Level_4_3", DateTime.Now);
        SceneManager.LoadScene("Level_4_3");
    }
    public void levelChangeToLevelManager()
    {
        Debug.Log("level manager called");
        SceneManager.LoadScene("Level Manager");
    }
    public void restartLevel() {
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
