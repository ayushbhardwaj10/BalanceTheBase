using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePinkWall : MonoBehaviour
{
    // Start is called before the first frame update
    // Color pinkColor = new Vector4(221, 108, 190,1.0f);
    Color pinkColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
    bool check = false;
    public float speed;


     void Update()
    {
        if(check){
            if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
      
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        if("PinkBallBlueBall".Equals(collision.gameObject.tag) || "PinkBallRedBall".Equals(collision.gameObject.tag)){
        gameObject.GetComponent<SpriteRenderer> ().color = pinkColor;
        check = true;
        }

    }
}
