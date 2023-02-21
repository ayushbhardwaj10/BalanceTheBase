using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        AnalyticsManager._instance.analytics_levelwise_restart(levelName, DateTime.Now);
    }
}
