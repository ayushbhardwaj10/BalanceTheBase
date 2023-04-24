using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageOrder51 : MonoBehaviour
{
    public TextMeshProUGUI instruction1;
    public TextMeshProUGUI instruction2;
    public TextMeshProUGUI instruction3;
    public TextMeshProUGUI instruction4;
    public TextMeshProUGUI instruction5;
    public int flag = 1;

    // Start is called before the first frame update
    void Start()
    {
        instruction1.enabled = true;
        instruction2.enabled = false;
        instruction3.enabled = false;
        instruction4.enabled = false;
        instruction5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && flag == 1)
        {
            instruction1.enabled = false;
            instruction2.enabled = true;
            flag++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && flag == 2)
        {
            instruction2.enabled = false;
            instruction3.enabled = true;
            flag++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && flag == 3)
        {
            instruction3.enabled = false;
            instruction4.enabled = true;
            flag++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && flag == 4)
        {
            instruction4.enabled = false;
            instruction5.enabled = true;
            flag++;

            //Set back timer and killer mode
            TextMeshProUGUI timeLeftObj = GameObject.Find("TimerLeft").GetComponent<TextMeshProUGUI>();

            if(timeLeftObj != null)
            {
                timeLeftObj.GetComponent<EatingTimer>().timeLeft = 60;
            }

            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        if (flag == 5)
        {
            yield return new WaitForSeconds(3f);
            float duration = 2f;
            float alpha = instruction5.color.a;

            while (instruction5.color.a > 0f)
            {
                alpha -= Time.deltaTime / duration;
                instruction5.color = new Color(instruction5.color.r, instruction5.color.g, instruction5.color.b, alpha);
                yield return null;
            }
            flag++;
        }
    }
}
