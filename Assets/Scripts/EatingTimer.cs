using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EatingTimer : MonoBehaviour
{
    public float timeLeft = 90;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = 0;
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
