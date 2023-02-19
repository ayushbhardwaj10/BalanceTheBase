using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttainPower : MonoBehaviour
{
    // Start is called before the first frame update
    Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
    Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log ("Triggered");
         gameObject.SetActive(false);
        if(redColor == (other.gameObject.GetComponent<SpriteRenderer>().color)){
        other.gameObject.tag="PinkBallRedBall";
        }
        else if(blueColor == (other.gameObject.GetComponent<SpriteRenderer>().color))
        {
            other.gameObject.tag="PinkBallBlueBall";
            Debug.Log("");
        }        
    }

}
