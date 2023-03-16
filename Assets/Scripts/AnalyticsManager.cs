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
    [SerializeField] private string split_record_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSdHoIbw4HHcJezfd5MVJRBupJOwur0xOc5lfmEPC60SEABq1w/formResponse";

    [SerializeField] private string levelwise_restart_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSfElxX9E7dRQOx6hiTfRiTiEiRH9k_nF7L4Ht4is_JGynTM-A/formResponse";
    [SerializeField] private string user_ratings_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSf6bBt4staqnfb-jrN9QRsyKC5McF7Q4rFHqp3nKTOVut9i7w/formResponse";

    [SerializeField] private string pink_wall_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSfSd_uvlAzBimvuNrX3Gue4nmDdU0AMRzc0wI68BZHW6YZXzQ/formResponse";
    [SerializeField] private string start_level_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSfx3T5fXovnKj1LpoSwj8lTHHdmCZvXtoE89MuLHYHVmHNx1g/formResponse";

    [SerializeField] private string undo_move_url = @"https://docs.google.com/forms/u/1/d/e/1FAIpQLSdQNYg7eMTv9illODTCMScK39KNvjDlknJ5SSaaQEStO75_-g/formResponse";

    private void Awake()
    {
        _instance = this;
        _sessionId = UnityEngine.Random.Range(0, 1000000);
        DontDestroyOnLoad(this.gameObject);
    }

    public void analytics_time_takenn(string level, int timeTaken, string gameStatus, string isRestartClicked)
    {
        WWWForm form_1 = new WWWForm();
        form_1.AddField("entry.1716623696", _sessionId.ToString());
        form_1.AddField("entry.1672803728", level);
        form_1.AddField("entry.796460226", timeTaken.ToString());
        form_1.AddField("entry.269785053", gameStatus);
        form_1.AddField("entry.1769943241", isRestartClicked);
        Debug.Log("Analytics : time taken ");
        StartCoroutine(Post(form_1, time_taken_url));

    }

    public void analytics_split_record(string level, DateTime collisionTime,string splitterColor, string ballColor,string splitter_id,string isRestartClicked)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.192462917", _sessionId.ToString());
        form.AddField("entry.483204020", level);
        form.AddField("entry.849229179", collisionTime.ToString());
        form.AddField("entry.1020257333", splitterColor);
        form.AddField("entry.1644182129", ballColor);
        form.AddField("entry.1229735257", splitter_id);
        form.AddField("entry.435186845", isRestartClicked);
        Debug.Log("AnalyticsManager:analytics_split_record");
        StartCoroutine(Post(form, split_record_url));

    }

    public void analytics_levelwise_restart(string level, DateTime dateTime, string isRestartClicked)
    {
        WWWForm form_2 = new WWWForm();
        form_2.AddField("entry.1522385615", _sessionId.ToString());
        form_2.AddField("entry.127452655", dateTime.ToString());
        form_2.AddField("entry.1558926028",level);
        form_2.AddField("entry.2100795516", isRestartClicked);
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

    public void analytics_pink_walls(Vector3 localScale,string inner_wall_id,DateTime endCollisionTime,DateTime startPowerTime,string levelName)
    {
        WWWForm form_4 = new WWWForm();
        
        form_4.AddField("entry.1168131134", _sessionId.ToString());
        form_4.AddField("entry.680564588", startPowerTime.ToString());
        form_4.AddField("entry.532737174", endCollisionTime.ToString());
        form_4.AddField("entry.1185637680", levelName);
        form_4.AddField("entry.939107459", inner_wall_id);
        form_4.AddField("entry.1403126087", localScale.ToString());
        StartCoroutine(Post(form_4, pink_wall_url));
    }

    public void analytics_start_level(string levelName,DateTime startTime)
    {
        WWWForm form_5 = new WWWForm();

        form_5.AddField("entry.941754938", _sessionId.ToString());
        form_5.AddField("entry.502897263", levelName);
        form_5.AddField("entry.419281248", startTime.ToString());
        StartCoroutine(Post(form_5, start_level_url));
    }

    public void analytics_undo_last_move(string levelName,int game_stack_count)
    {
        WWWForm form_6 = new WWWForm();
        form_6.AddField("entry.1968809503", _sessionId.ToString());
        form_6.AddField("entry.2061175414", levelName);
        form_6.AddField("entry.1488716983", game_stack_count.ToString());

        StartCoroutine(Post(form_6,undo_move_url));
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
