using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FindBallCountShakeVarient : MonoBehaviour
{
    public TextMeshProUGUI ballCountText;
    public TextMeshProUGUI blueBallCountText;
    BlueFindBallCountShakeVarient ballCountShakeVarient;
    RedFindBallCountShakeVarient redFindBallCountShakeVarient;
    private volatile int countRed;
    private volatile int countBlue;

    public event Action<int> OnMyIntChanged;

    public int blueCountInt
    {
        get {
            Debug.Log("updated getter blue count: " + countBlue);
            return countBlue; }
        set
        {
            countBlue = value;
            BlueUISetter(countBlue);
            Debug.Log("updated setter blue count: " + countBlue);
        }
    }

    public int redCountInt
    {
        get { return countRed; }
        set
        {
            countRed = value;
            RedUISetter(countRed);
            Debug.Log("updated red count: " + countRed);
        }
    }

    // Start is called before the first frame; update
    void Start()
    {
        ballCountShakeVarient = new BlueFindBallCountShakeVarient();
        redFindBallCountShakeVarient = new RedFindBallCountShakeVarient();
    }

    void BlueUISetter(int countBlueParam)
    {
        ballCountShakeVarient = new BlueFindBallCountShakeVarient();
        ballCountShakeVarient.blueCountIntText = countBlueParam;
        Debug.Log("BlueUISetter: " + countBlueParam);
    }

    void RedUISetter(int countRedParam)
    {
        redFindBallCountShakeVarient = new RedFindBallCountShakeVarient();
        redFindBallCountShakeVarient.redCountIntText = countRedParam;
        Debug.Log("RedUISetter: " + countRedParam);
    }

    // Update is called once per frame
    void Update()
    {
        //countRed = GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length;
        //countBlue = checkLosingConditionBoxRegion.blueCountInt;

        //Debug.Log("updated blue count: " + countBlue);
        //blueBallCountText.text = countBlue.ToString() + " B";

        //ballCountShakeVarient.blueCountIntText = blueCountInt;
        Debug.Log("getter = " + blueCountInt);

        if (redCountInt == blueCountInt)
        {
            ballCountText.text = "";
        }
        else
        {
            ballCountText.text = "!";
        }
    }
}
