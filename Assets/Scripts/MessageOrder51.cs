using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageOrder51 : MonoBehaviour
{
    public TextMeshProUGUI instruction1;
    public TextMeshProUGUI instruction2;
    public TextMeshProUGUI instruction3;

    // Start is called before the first frame update
    void Start()
    {
        instruction2.enabled = false;
        instruction3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            instruction1.enabled = false;
        }
    }
}
