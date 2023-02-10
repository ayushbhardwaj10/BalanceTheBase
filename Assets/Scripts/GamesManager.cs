using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public static int level = 1;
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
        Debug.Log("GamesManager:Awake:: ");
    }

    private void Start()
    {
        Debug.Log("GamesManager:Start::");
        NewGame();
    }

    private void NewGame()
    {

        Debug.Log("GamesManager:NewGame::");
        //SceneManager.LoadScene("Level 1");
        SceneManager.LoadScene("Level Manager");

    }

    
}
