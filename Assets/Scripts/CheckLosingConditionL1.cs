using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLosingConditionL1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Add losing popup
        if (GameObject.FindGameObjectsWithTag("RedBall").Length != GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            Debug.Log("You lose");
        }
    }
}
