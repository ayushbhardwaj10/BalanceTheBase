using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWinCondition : MonoBehaviour
{
    List <GameObject> currentCollisions = new List <GameObject> ();
    public GameObject winningPopup;

    void OnCollisionEnter2D(Collision2D collision){
       if("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag)){
       currentCollisions.Add(collision.gameObject);
       }

       int len = currentCollisions.Count ;

       if ((len == (GameObject.FindGameObjectsWithTag("BlueBall").Length +
       GameObject.FindGameObjectsWithTag("RedBall").Length)) &&
       (GameObject.FindGameObjectsWithTag("BlueBall").Length == GameObject.FindGameObjectsWithTag("RedBall").Length )) {
            
            string name = SceneManager.GetActiveScene().name;
            Debug.Log("Scene "+ name);
            string[] levelSplit = name.Split("_");
            Debug.Log(levelSplit[2]);
            int l = Int32.Parse(levelSplit[2]);
            l++;
            Debug.Log("You Win");

            //Debug.Log(levelSplit.Length);
            SceneManager.LoadScene("Level_0_" + l.ToString());


            //winningPopup.SetActive(true);
        }
   }


   void OnCollisionExit2D (Collision2D collision) {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove (collision.gameObject);
   }
}
