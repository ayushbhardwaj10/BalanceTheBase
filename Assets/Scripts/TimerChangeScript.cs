using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerChangeScript : MonoBehaviour
{
    private int timer;
    public TextMeshProUGUI timerText;
    // CreateBlinkingBall blinkingBall = new CreateBlinkingBall();

    public int timerVal
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
            Debug.Log(timer);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // timerVal = blinkingBall.timer;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timerVal.ToString();
    }
}