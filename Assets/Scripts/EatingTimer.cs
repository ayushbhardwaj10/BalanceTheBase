using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EatingTimer : MonoBehaviour
{
    public float timeLeft = 60;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI killerModeStatus;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0 && (killerModeStatus.text == "ON"))
        {
            
            timeLeft -= Time.deltaTime;
            // KillerModeText.text = "Killer Mode ON";

        }
        else if(timeLeft <= 0)
        {
            // KillerModeText.text = "Killer Mode OFF";
            timeLeft = 0;
            SelectKiller.removeHaloFromAllBalls();
            killerModeStatus.text = "OFF";
        }
        DisplayTime(timeLeft);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float seconds = Mathf.FloorToInt(timeToDisplay);
        timeText.text = string.Format("{0:00}", seconds);
    }

    
}
