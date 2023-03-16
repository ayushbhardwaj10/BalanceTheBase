using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueFindBallCount : MonoBehaviour
{
    public TextMeshProUGUI ballCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int countBlue = GameObject.FindGameObjectsWithTag("BlueBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length;
        ballCountText.text = countBlue.ToString() + " B";
    }
}
