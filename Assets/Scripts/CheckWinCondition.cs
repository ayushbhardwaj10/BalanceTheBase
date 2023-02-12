using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckWinCondition : MonoBehaviour
{
     List <GameObject> currentCollisions = new List <GameObject> ();
    
    void OnCollisionEnter2D(Collision2D collision){
        if("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag)){
        currentCollisions.Add(collision.gameObject);
        }
        int len = currentCollisions.Count ;
        if (( len == (GameObject.FindGameObjectsWithTag("BlueBall").Length + 
        GameObject.FindGameObjectsWithTag("RedBall").Length)) && (GameObject.FindGameObjectsWithTag("BlueBall").Length == GameObject.FindGameObjectsWithTag("RedBall").Length )){
            Debug.Log("You Win");
        }
    }

    void OnCollisionExit2D (Collision2D collision) {
         // Remove the GameObject collided with from the list.
         currentCollisions.Remove (collision.gameObject);
    }
 
}

  

