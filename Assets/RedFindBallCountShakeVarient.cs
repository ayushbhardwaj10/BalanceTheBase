using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedFindBallCountShakeVarient : MonoBehaviour
{
    public TextMeshProUGUI ballCountText;

    public volatile int countRed;

    public int redCountIntText
    {
        get { return countRed; }
        set
        {
            countRed = value;
            RedUISetter(countRed);
            Debug.Log("updated text red count: " + countRed);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        ballCountText = GameObject.Find("R-text").GetComponent<TextMeshProUGUI>();
    }

    void RedUISetter(int countRedParam)
    {
        ballCountText = GameObject.Find("R-text").GetComponent<TextMeshProUGUI>();
        Debug.Log("UI countRedParam: " + countRedParam);
        ballCountText.text = countRedParam.ToString() + " R";
    }

    // Update is called once per frame
    void Update()
    {
        //int countRed = GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length;
        //ballCountText.text = countRed.ToString() + " R";
    }
}
