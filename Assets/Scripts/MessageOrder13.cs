using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageOrder13 : MonoBehaviour
{
    public TextMeshProUGUI instruction1;
    private float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(7f); 
        Debug.Log("Fading out");
        float duration = 2f; 
        float alpha = instruction1.color.a;

        while (instruction1.color.a > 0f) 
        {
            alpha -= Time.deltaTime / duration; 
            instruction1.color = new Color(instruction1.color.r, instruction1.color.g, instruction1.color.b, alpha); 
            yield return null;
        }
    }
}
