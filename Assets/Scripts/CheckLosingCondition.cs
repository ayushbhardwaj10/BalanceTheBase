using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class CheckLosingCondition : MonoBehaviour
{
    public GameObject losingPopup;

    public void DisableLoosingPopup()
    {
        Debug.Log("close popup loose");
        losingPopup.SetActive(false);
    }

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
        }
    }
}
