using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public const string LOST = "Lost";
    public const string WIN = "Win";
    public enum RATING
    {
        Zero_Star,
        One_Star,
        Two_Star,
        Three_Star
    }


    public static int level = 1;
    public static int restartTimes = 0;
    public static Dictionary<string, int> level_restart_map = new Dictionary<string, int>();
    public static Dictionary<string, SplitterDetails> splitter_details_map = new Dictionary<string, SplitterDetails>();

   
    public static GamesManager _instance;

    public static GamesManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);    
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SceneManager.LoadScene("Level Manager");

    }

    private void OnDestroy()
    {
        foreach (var restart_map in level_restart_map)
        {
            Debug.Log("in destroy ,restart map, k : " + restart_map.Key + " v: " + restart_map.Value);
        }
    }

    public int calculate_user_ratings(string game_status,string levelName,int timeTaken)
    {
        int star_rating=-1,retry=0;
        Debug.Log("In user rating mechanism "+game_status+" "+levelName+" "+timeTaken);

        if (level_restart_map.ContainsKey(levelName))
        {
            retry = level_restart_map[levelName];
        }
        else
        {
            retry = 0;
        }

        if(retry <= 3 && game_status == WIN)
        {
            star_rating = per_level_time_benchmark(levelName,timeTaken);
            
        }else if(retry < 3 && game_status == LOST)
        {
            star_rating = (int)RATING.Two_Star;
        }
        else if(retry == 3 && game_status == LOST)
        {
            star_rating = (int) RATING.One_Star;
        }
        else if (retry > 3 && game_status == LOST)
        {
            star_rating = (int)RATING.Zero_Star;
        }
        else if(retry > 3 && game_status == WIN)
        {
            star_rating = per_level_time_benchmark(levelName, timeTaken);
        }

        return star_rating;

    }

    private int per_level_time_benchmark(string levelName,int time_taken)
    {

        string outerlevel = "Level_" + levelName.Split("_")[1];
        int star_rating=-1;
        switch (outerlevel)
        {
            case "Level_0":
                if(time_taken <= 15)
                {
                    star_rating = (int)RATING.Three_Star;
                }else if(time_taken >15 && time_taken < 30)
                {
                    star_rating = (int)RATING.Two_Star;
                }else
                {
                    star_rating = (int)RATING.One_Star;
                }
                break;
            case "Level_1":
                if (time_taken <= 40)
                {
                    star_rating = (int)RATING.Three_Star;
                }
                else if (time_taken > 40 && time_taken < 70)
                {
                    star_rating = (int)RATING.Two_Star;
                }
                else
                {
                    star_rating = (int)RATING.One_Star;
                }
                break;
            case "Level_2": break;
            case "Level_3": break;
            case "Level_4": break;
        }
        return star_rating;
    }

    

}