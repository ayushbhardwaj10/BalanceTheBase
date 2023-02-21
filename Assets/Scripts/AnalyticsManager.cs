using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using static UnityEngine.EventSystems.EventTrigger;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager _instance;
    public int _sessionId;

    [SerializeField] private string time_taken_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLScaIHhPlLRkFO-Jja0Eq32Wl4THz28OhYFS-uoVHWFrNGy5Bg/formResponse";
    [SerializeField] private string split_record_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSeSj3Ef-ZS6Jq55OJweJLh0pUBj1U8PKTh-4XAbyuhcQOtZEw/formResponse";
    [SerializeField] private string levelwise_restart_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSfElxX9E7dRQOx6hiTfRiTiEiRH9k_nF7L4Ht4is_JGynTM-A/formResponse";
    [SerializeField] private string user_ratings_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSf6bBt4staqnfb-jrN9QRsyKC5McF7Q4rFHqp3nKTOVut9i7w/formResponse";


    private void Awake()
    {
        _instance = this;
        _sessionId = UnityEngine.Random.Range(0, 1000000);
        DontDestroyOnLoad(this.gameObject);
    }

    public void analytics_time_takenn(string level, int timeTaken, string gameStatus)
    {
        WWWForm form_1 = new WWWForm();
        form_1.AddField("entry.1716623696", _sessionId.ToString());
        form_1.AddField("entry.1672803728", level);
        form_1.AddField("entry.796460226", timeTaken.ToString());
        form_1.AddField("entry.269785053", gameStatus);
        Debug.Log("Analytics : time taken ");
        StartCoroutine(Post(form_1, time_taken_url));

    }

    public void analytics_split_record(string level, DateTime collisionTime,string splitterColor, string ballColor)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1053949501", _sessionId.ToString());
        form.AddField("entry.1840337228", level);
        form.AddField("entry.1488388670", collisionTime.ToString());
        form.AddField("entry.184202295", splitterColor);
        form.AddField("entry.1484592871", ballColor);
        Debug.Log("AnalyticsManager:analytics_split_record");
        StartCoroutine(Post(form, split_record_url));

    }

    public void analytics_levelwise_restart(string level, DateTime dateTime)
    {
        WWWForm form_2 = new WWWForm();
        form_2.AddField("entry.1522385615", _sessionId.ToString());
        form_2.AddField("entry.127452655", dateTime.ToString());
        form_2.AddField("entry.1558926028",level);
        Debug.Log("Analytics : Levelwise restart");
        StartCoroutine(Post(form_2,levelwise_restart_url));
    }

    public void analytics_user_ratings(string levelName, int time_taken,int user_rating,string game_status)
    {
        WWWForm form_3 = new WWWForm();
        form_3.AddField("entry.1336985884", _sessionId.ToString());
        form_3.AddField("entry.1167952431", time_taken.ToString());
        form_3.AddField("entry.2046889233", levelName);
        form_3.AddField("entry.693844703", user_rating.ToString());
        form_3.AddField("entry.1829694804", game_status);
        StartCoroutine(Post(form_3, user_ratings_url));
    }

    private IEnumerator Post(WWWForm form, string URL)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("AnalyticsManager:Post");
            }
        }
    }

    


}
