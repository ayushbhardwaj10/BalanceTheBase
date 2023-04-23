using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    
    Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
    Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);
    public Color currentColor;
    bool check = false;
    void Start()
    {
       currentColor = blueColor;
    }

   // Update is called once per frame
    void Update()
    {
        float duration = 8f;
        float alpha = this.transform.GetComponent<SpriteRenderer>().color.a;
        if(alpha <= 0.3){
            check = !check;
            alpha = 1.0f;
        }
        
        if(check){
            currentColor = redColor;
            this.transform.GetComponent<SpriteRenderer>().color = currentColor;
        }
        if(!check){
            currentColor = blueColor;
            this.transform.GetComponent<SpriteRenderer>().color = currentColor;
        }
        if(alpha > 0.3) {
            alpha -= Time.deltaTime / duration;
            Color newColor = currentColor;
            newColor.a = alpha;
            this.transform.GetComponent<SpriteRenderer>().color = newColor;
        }
        
    }

}

