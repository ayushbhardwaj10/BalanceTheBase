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

        //Save ID of deleted game object
        List<int> deletedIdList = new List<int>(); 
        int deletedID = gameObject.transform.parent.gameObject.GetInstanceID();
        deletedIdList.Add(deletedID);

        // Destroy the star and the canvas holding it
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);

        //Update game state
        GameStateTracking.UpdateGameStack(deletedIdList, "Attain Power Script: " + gameObject.name);
   }


}
