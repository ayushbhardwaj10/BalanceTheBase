using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AttainPower : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
   {
        Debug.Log(gameObject.tag);
        
        gameObject.SetActive(false);
        if("RedBall" == (other.gameObject.tag)){
                other.gameObject.tag="PinkBall_RedBall";
        }
        else if("BlueBall" == (other.gameObject.tag)){
            other.gameObject.tag="PinkBall_BlueBall";
        }
        GamesManager.powerAttainStartTime = DateTime.Now; 
   }


}
