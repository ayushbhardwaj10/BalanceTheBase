using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRotate1Wall : MonoBehaviour
{
    // Start is called before the first frame update
    public int num = 1;
    public GameObject w1;
    public GameObject w2;

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
                    num = 2;
                    break;
                case 2:
                    w1.SetActive(false);
                    w2.SetActive(true);
                    num = 1;
                    break;
            }
        }
    }
}
