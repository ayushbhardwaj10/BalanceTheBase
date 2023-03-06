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

    [SerializeField] private SpriteRenderer sprite1;
    [SerializeField] private SpriteRenderer sprite2;
    [SerializeField] private SpriteRenderer sprite3;
    [SerializeField] private int sortingOrder = 0;

    void Start()
    {
        startTime = DateTime.Now;

        sprite1.sortingOrder = sortingOrder;
        sprite2.sortingOrder = sortingOrder + 1;
        sprite3.sortingOrder = sortingOrder + 1;
    }


    IEnumerator OnTriggerEnter2D(Collider2D collision){
       if("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag)){
            currentCollisions.Add(collision.gameObject);
       }

        int len = currentCollisions.Count ;

        // len/2 because its counting twice for each object added
        if ((len/2 == (GameObject.FindGameObjectsWithTag("BlueBall").Length +
       GameObject.FindGameObjectsWithTag("RedBall").Length)) &&
       !GameObject.FindWithTag("PinkBall_BlueBall") && !GameObject.FindWithTag("PinkBall_RedBall") &&
       (GameObject.FindGameObjectsWithTag("BlueBall").Length == GameObject.FindGameObjectsWithTag("RedBall").Length)) {
            

            string levelName = SceneManager.GetActiveScene().name;
            string []levelSplit = levelName.Split("_");

            int inner_level = Int32.Parse(levelSplit[2]);
            int outer_level = Int32.Parse(levelSplit[1]);
            
            Debug.Log("You Win");
            endTime = DateTime.Now;
            
            winningPopup.SetActive(true);
            yield return new WaitForSeconds(4);
            int time_taken = (int)(endTime - startTime).TotalSeconds;

            
            int user_rating = GamesManager._instance.calculate_user_ratings(GamesManager.WIN, levelName, time_taken);
            Debug.Log("User rating is " + user_rating);

            //Analytics for time taken
            AnalyticsManager._instance.analytics_time_takenn(levelName, time_taken, GamesManager.WIN);
            //Analytics for user ratings
            AnalyticsManager._instance.analytics_user_ratings(levelName,time_taken,user_rating,GamesManager.WIN);

            //Auto Level Movement
            inner_level++;
            if(levelName == "Level_0_4")
            {
                outer_level++;
                inner_level = 1;
            }
            string load_scene = "Level_" + outer_level.ToString() + "_" + inner_level.ToString();
            
            Debug.Log("Auto Load scene " + load_scene);
            if (load_scene != "Level_2_4")
            {
                SceneManager.LoadScene(load_scene);
            }

        }
   }


   void OnTriggerExit2D(Collider2D collision) {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove (collision.gameObject);
   }
}
