using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageOrder12 : MonoBehaviour
{
    public TextMeshProUGUI instruction1;
    public TextMeshProUGUI instruction2;
    public TextMeshProUGUI instruction3;
    public int flag = 1;

    // Start is called before the first frame update
    void Start()
    {
        instruction1.enabled = true;
        instruction2.enabled = false;
        instruction3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && flag == 2)
        {
            instruction2.enabled = false;
            instruction3.enabled = true;
            flag++;

            StartCoroutine(FadeOut());
        }
    }

    public void MoveToInstruction2()
    {
        instruction1.enabled = false;
        instruction2.enabled = true;
        flag++;
    }

    IEnumerator FadeOut()
    {
        if (flag == 3)
        {
            yield return new WaitForSeconds(3f);
            float duration = 2f;
            float alpha = instruction3.color.a;

            while (instruction3.color.a > 0f)
            {
                alpha -= Time.deltaTime / duration;
                instruction3.color = new Color(instruction3.color.r, instruction3.color.g, instruction3.color.b, alpha);
                yield return null;
            }
            flag++;
        }
    }
}
