using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerChangeScript : MonoBehaviour
{
    private int timer;
    public TextMeshProUGUI timerText;

    public int timerVal
    {
        get {
            return timer;
        }
        set
        {
            timer = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timerVal = 40;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timerVal.ToString();
    }
}
