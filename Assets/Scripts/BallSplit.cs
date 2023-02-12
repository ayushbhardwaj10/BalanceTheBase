using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BallSplit : MonoBehaviour
{
   // Start is called before the first frame update
   //private static int num_times_ballsplit = 0;
   void Start()
   {
      
   }


   // Update is called once per frame
   void Update()
   {
      
   }


   void OnCollisionEnter2D(Collision2D collision)
   {
       Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
       Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);

       //First destrory and then instantiate
       Destroy(gameObject);
       SpriteRenderer renderer = GetComponent<SpriteRenderer>();
       collision.gameObject.GetComponent<SpriteRenderer>().color = renderer.color;
      
       var go = Instantiate(collision.gameObject, collision.transform.position, collision.transform.rotation);
    

      if(blueColor==(collision.gameObject.GetComponent<SpriteRenderer>().color)){
       collision.gameObject.tag="BlueBall";
      } else if(redColor==(collision.gameObject.GetComponent<SpriteRenderer>().color)){
       collision.gameObject.tag="RedBall";
      }
       if(blueColor==(go.GetComponent<SpriteRenderer>().color)){
           go.gameObject.tag = "BlueBall";
       }else if(redColor==(go.GetComponent<SpriteRenderer>().color)){
           go.gameObject.tag = "RedBall";
       }
       
      
       // AnalyticsManager._instance.analytics_split_record(1, DateTime.Now, renderer.tag, collision.gameObject.tag);
   }
}
