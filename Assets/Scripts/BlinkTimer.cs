using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkTimer : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 15;
    bool check = false;
    Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
    Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((gameObject.tag=="PinkBallBlueBall" || gameObject.tag=="PinkBallRedBall") && timer>0){
            if(check==true){
            gameObject.GetComponent<SpriteRenderer> ().color = redColor;
            check = false;
        } else {
            gameObject.GetComponent<SpriteRenderer> ().color = blueColor;
            check = true;
        }
        timer -= Time.deltaTime;
        }
        else {
        timer = 15;
        if(gameObject.tag=="PinkBallBlueBall"){
            gameObject.GetComponent<SpriteRenderer> ().color = blueColor;
            gameObject.tag = "BlueBall";
        }
        if(gameObject.tag=="PinkBallRedBall"){
            gameObject.GetComponent<SpriteRenderer> ().color = redColor;
            gameObject.tag = "RedBall";
        }
       }
        
    }
}
