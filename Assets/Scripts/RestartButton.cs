using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    //public static int gameplayid;
    //gameplayid = UnityEngine.Random.Range(1, 100000);

    public static string prev_level;
    public static string isRestartClicked="start";
   


    void Start()
    {
        prev_level = SceneManager.GetActiveScene().name;
        
    }
    
    

   public void RestartLevel()
    {

        
        string levelName = SceneManager.GetActiveScene().name;
        

        if (GamesManager.level_restart_map.ContainsKey(levelName))
        {
            GamesManager.level_restart_map[levelName]++;
        }
        else
        {
            GamesManager.level_restart_map.Add(levelName, 1);
        }

        SceneManager.LoadScene(levelName);

        foreach (var restart_map in GamesManager.level_restart_map)
        {
            Debug.Log("in restart ,restart map, k : " + restart_map.Key + " v: " + restart_map.Value);
        }

        //Debug.Log("In Restart " + gameplayid);
        int k = UnityEngine.Random.Range(1, 100000);
        isRestartClicked = k.ToString() +"_"+levelName;

        AnalyticsManager._instance.analytics_levelwise_restart(levelName, DateTime.Now,isRestartClicked);
    }
}
