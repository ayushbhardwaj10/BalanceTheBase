using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttainPower : MonoBehaviour
{
   // Start is called before the first frame update
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
       if("RedBall" == (other.gameObject.tag)){
       other.gameObject.tag="PinkBall_RedBall";
       }
       else if("BlueBall" == (other.gameObject.tag))
       {
           other.gameObject.tag="PinkBall_BlueBall";
       }       
   }


}
