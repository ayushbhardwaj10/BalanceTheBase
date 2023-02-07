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


    [SerializeField] private string time_taken_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSfCftSEPZP0b24aGzJZnTR5ccFCkhhiUvQG_ddy7_yDonjy5g/formResponse";
    [SerializeField] private string split_record_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSdHoIbw4HHcJezfd5MVJRBupJOwur0xOc5lfmEPC60SEABq1w/formResponse";

    private void Awake()
    {
        _instance = this;
        _sessionId = UnityEngine.Random.Range(0, 1000000);
        DontDestroyOnLoad(this.gameObject);
    }

    public void analytics_time_taken(int level, int time_taken)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.955126917", _sessionId);
        form.AddField("entry.75752132", level);
        form.AddField("entry.1110799340", time_taken);

        Debug.Log("AnalyticsManager:analytics_time_taken");

        StartCoroutine(Post(form, time_taken_url));

    }
    public void analytics_split_record(int level, DateTime collisionTime,string splitterColor, string ballColor)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.192462917", _sessionId);
        form.AddField("entry.483204020", level.ToString());
        form.AddField("entry.849229179", collisionTime.ToString());
        form.AddField("entry.1020257333", splitterColor);
        form.AddField("entry.1644182129", ballColor);
        Debug.Log("AnalyticsManager:analytics_split_record");
        StartCoroutine(Post(form, split_record_url));

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
