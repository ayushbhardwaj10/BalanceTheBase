using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueFindBallCountShakeVarient : MonoBehaviour
{
    public TextMeshProUGUI ballCountText;
    public volatile int countBlue;

    public int blueCountIntText
    {
        get { return countBlue; }
        set
        {
            countBlue = value;
            BlueUISetter(countBlue);
            Debug.Log("updated text blue count: " + countBlue);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ballCountText = GameObject.Find("B-text").GetComponent<TextMeshProUGUI>();
    }

    void BlueUISetter(int countBlueParam)
    {
        ballCountText = GameObject.Find("B-text").GetComponent<TextMeshProUGUI>();
        Debug.Log("UI countBlueParam: " + countBlueParam);
        ballCountText.text = countBlueParam.ToString() + " B";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UI Blue updated: " + blueCountIntText);
        //ballCountText.text = blueCountIntText.ToString() + " B";
    }
}
