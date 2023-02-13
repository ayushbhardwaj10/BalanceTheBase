using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWinCondition : MonoBehaviour
{
    List <GameObject> currentCollisions = new List <GameObject> ();
    public GameObject winningPopup;

    DateTime startTime, endTime;
    

    void Start()
    {
        startTime = DateTime.Now;
    }


    void OnCollisionEnter2D(Collision2D collision){
       if("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag)){
       currentCollisions.Add(collision.gameObject);
       }

       int len = currentCollisions.Count ;

       if ((len == (GameObject.FindGameObjectsWithTag("BlueBall").Length +
       GameObject.FindGameObjectsWithTag("RedBall").Length)) &&
       (GameObject.FindGameObjectsWithTag("BlueBall").Length == GameObject.FindGameObjectsWithTag("RedBall").Length )) {
            

            string levelName = SceneManager.GetActiveScene().name;
            string []levelSplit = levelName.Split("_");

            int l = Int32.Parse(levelSplit[2]);
            l++;
            Debug.Log("You Win");
            endTime = DateTime.Now;
            winningPopup.SetActive(true);

            AnalyticsManager._instance.analytics_time_takenn(levelName, (int)(endTime - startTime).TotalSeconds, "Win");
            if (l < 5)
            {
                SceneManager.LoadScene("Level_0_" + l.ToString());
            }
            


        }
   }


   void OnCollisionExit2D (Collision2D collision) {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove (collision.gameObject);
   }
}
