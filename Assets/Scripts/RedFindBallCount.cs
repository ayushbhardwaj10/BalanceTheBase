using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedFindBallCount : MonoBehaviour
{
    public TextMeshProUGUI ballCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int countRed = GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length;
        Debug.Log("Red count: " + countRed);
        ballCountText.text = countRed.ToString() + " R";
    }
}
