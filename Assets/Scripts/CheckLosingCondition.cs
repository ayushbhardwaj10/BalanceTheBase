using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLosingCondition : MonoBehaviour
{
    public GameObject losingPopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindWithTag("BlueSplitterTriangle") && !GameObject.FindWithTag("RedSplitterTriangle") &&
            GameObject.FindGameObjectsWithTag("RedBall").Length != GameObject.FindGameObjectsWithTag("BlueBall").Length)
        {
            Debug.Log("You lose");
            losingPopup.SetActive(true);
            //added to get out of Update
            this.enabled = false;
        }
    }
}
