using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
     bool check = true;
     Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
     Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);

    // Start is called before the first frame update
    
    void Start()
    {
        InvokeRepeating("changeColor", 1.0f, 2.0f);
    }

    void changeColor()
    {
        if(check==true){
            gameObject.GetComponent<SpriteRenderer> ().color = redColor;
            check = false;
        } else {
            gameObject.GetComponent<SpriteRenderer> ().color = blueColor;
            check = true;
        }  
    }

}
