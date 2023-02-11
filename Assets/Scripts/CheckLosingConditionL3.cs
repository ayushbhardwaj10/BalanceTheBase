using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLosingConditionL3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("BlueSplitter").Length == 1 &&
            GameObject.FindGameObjectsWithTag("RedSplitter").Length == 1 &&
            GameObject.FindGameObjectsWithTag("RedBall").Length != GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            Debug.Log("You lose");
        }
    }
}
