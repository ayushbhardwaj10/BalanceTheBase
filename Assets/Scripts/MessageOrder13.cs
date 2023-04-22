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

    // Update is called once per frame
    //private void Disappear()
    //{
    //    instruction1.enabled = false;
    //    Debug.Log("Dissapeared");
    //    StartCoroutine(FadeOut());
    //}

    IEnumerator FadeOut()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(7f); // Wait for 15 seconds before starting the fade-out effect
        Debug.Log("Fading out");
        float duration = 2f; // The duration of the fade-out effect in seconds
        float alpha = instruction1.color.a; // Get the initial alpha value of the text

        while (instruction1.color.a > 0f) // Continue the loop while the text is still visible
        {
            alpha -= Time.deltaTime / duration; // Decrease the alpha value over time
            instruction1.color = new Color(instruction1.color.r, instruction1.color.g, instruction1.color.b, alpha); // Set the new alpha value of the text
            yield return null;
        }
    }
}
