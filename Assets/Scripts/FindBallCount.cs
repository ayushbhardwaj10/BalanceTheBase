using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindBallCount : MonoBehaviour
{
    //public TextMeshProUGUI ballCountText;
    public TextMeshProUGUI ballCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int countRed = GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length;
        int countBlue = GameObject.FindGameObjectsWithTag("BlueBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length;

        if (countRed == countBlue)
        {
            ballCountText.text = "";
        }
        else
        {
            ballCountText.text = "!";
        }

        //if (countRed == countBlue)
        //{
        //    ballCountText.text = " = ";
        //} else
        //{
        //    ballCountText.text = " != ";
        //}
    }
}
