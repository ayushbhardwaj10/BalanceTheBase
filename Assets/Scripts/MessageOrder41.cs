using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageOrder41 : MonoBehaviour
{
    public TextMeshProUGUI instruction1;
    public TextMeshProUGUI instruction2;
    public int flag = 1;

    // Start is called before the first frame update
    void Start()
    {
        instruction1.enabled = true;
        instruction2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && flag == 1)
        {
            instruction1.enabled = false;
            instruction2.enabled = true;
            flag++;
        }
    }
}
