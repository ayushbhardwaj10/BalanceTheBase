using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkTimer : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 5;
    bool check = false;
    Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
    Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);
    Color pinkColor = new Vector4(0.8679245f, 0.4216803f, 0.7468505f,1.0f);
    Color originalColor;



    void Start()
    {
        if(gameObject.tag=="BlueBall"){
            originalColor = blueColor;
        } else {
            originalColor = redColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if((gameObject.tag=="PinkBall_BlueBall" || gameObject.tag=="PinkBall_RedBall") && timer>0){
            if(check==true){
            gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
            check = false;
        } else {
            gameObject.GetComponent<SpriteRenderer> ().color = pinkColor;
            check = true;
        }
        timer -= Time.deltaTime;
        }
        else {
        timer = 5;
        if(gameObject.tag=="PinkBall_BlueBall"){
            gameObject.GetComponent<SpriteRenderer> ().color = blueColor;
            gameObject.tag = "BlueBall";
        }
        if(gameObject.tag=="PinkBall_RedBall"){
            gameObject.GetComponent<SpriteRenderer> ().color = redColor;
            gameObject.tag = "RedBall";
        }
       }
        
    }
}
