using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRotate3Walls : MonoBehaviour
{
    // Start is called before the first frame update
    public int num = 1;
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;
    void Start()
    {
        w1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (num)
            {
                case 1:
                    w1.SetActive(true);
                    w2.SetActive(false);
                    w3.SetActive(true);
                    w4.SetActive(true);
                    num = 2;
                    break;
                case 2:
                    w1.SetActive(true);
                    w2.SetActive(true);
                    w3.SetActive(false);
                    w4.SetActive(true);
                    num = 3;
                    break;
                case 3:
                    w1.SetActive(true);
                    w2.SetActive(true);
                    w3.SetActive(true);
                    w4.SetActive(false);
                    num = 4;
                    break;
                case 4:
                    w1.SetActive(false);
                    w2.SetActive(true);
                    w3.SetActive(true);
                    w4.SetActive(true);
                    num = 1;
                    break;
            }
        }
    }
}
