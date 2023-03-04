using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AttainPower : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
   {
        if("RedBall" == (other.gameObject.tag)){
                other.gameObject.tag="PinkBall_RedBall";
        }
        else if("BlueBall" == (other.gameObject.tag)){
            other.gameObject.tag="PinkBall_BlueBall";
        }
        GamesManager.powerAttainStartTime = DateTime.Now; 

        // Destroy the star and the canvas holding it
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
   }


}
