using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageOrder21 : MonoBehaviour
{
    public TextMeshProUGUI instruction1;
    public TextMeshProUGUI instruction2;
    public TextMeshProUGUI instruction3;
    public TextMeshProUGUI instruction4;
    public int flag = 1;

    // Start is called before the first frame update
    void Start()
    {
        instruction1.enabled = true;
        instruction2.enabled = false;
        instruction3.enabled = false;
        instruction4.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && flag == 1)
        {
            instruction1.enabled = false;
            instruction2.enabled = true;
            flag++;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && flag == 2)
        {
            instruction2.enabled = false;
            instruction3.enabled = true;
            flag++;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && flag == 3)
        {
            instruction3.enabled = false;
            instruction4.enabled = true;
            flag++;

            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        if (flag == 4)
        {
            yield return new WaitForSeconds(9f);
            float duration = 2f;
            float alpha = instruction4.color.a;

            while (instruction4.color.a > 0f)
            {
                alpha -= Time.deltaTime / duration;
                instruction4.color = new Color(instruction4.color.r, instruction4.color.g, instruction4.color.b, alpha);
                yield return null;
            }
            flag++;
        }
    }
}
