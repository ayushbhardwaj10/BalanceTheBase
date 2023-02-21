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


    IEnumerator OnCollisionEnter2D(Collision2D collision){
       if("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag)){
       currentCollisions.Add(collision.gameObject);
       }

       int len = currentCollisions.Count ;

       if ((len == (GameObject.FindGameObjectsWithTag("BlueBall").Length +
       GameObject.FindGameObjectsWithTag("RedBall").Length)) &&
       (GameObject.FindGameObjectsWithTag("BlueBall").Length == GameObject.FindGameObjectsWithTag("RedBall").Length )) {
            

            string levelName = SceneManager.GetActiveScene().name;
            string []levelSplit = levelName.Split("_");

            int inner_level = Int32.Parse(levelSplit[2]);
            int outer_level = Int32.Parse(levelSplit[1]);
            inner_level++;
            Debug.Log("You Win");
            endTime = DateTime.Now;
            winningPopup.SetActive(true);
            yield return new WaitForSeconds(4);
            int time_taken = (int)(endTime - startTime).TotalSeconds;
            AnalyticsManager._instance.analytics_time_takenn(levelName, time_taken, GamesManager.WIN);

            
            int user_rating = GamesManager._instance.calculate_user_ratings(GamesManager.WIN, levelName, time_taken);
            Debug.Log("User rating is " + user_rating);

           
            if (inner_level > 4)
            {
                outer_level++;
                inner_level = 1;

            }
            string load_scene = "Level_" + outer_level.ToString() + "_" + inner_level.ToString();
            Debug.Log("Auto Load scene " + load_scene);
            if (inner_level < 5)
            {
                
                SceneManager.LoadScene(load_scene);
                
            }

            


        }
   }


   void OnCollisionExit2D (Collision2D collision) {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove (collision.gameObject);
   }
}
