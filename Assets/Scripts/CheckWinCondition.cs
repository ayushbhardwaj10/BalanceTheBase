
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWinCondition : MonoBehaviour
{
    List<GameObject> currentCollisions = new List<GameObject>();
    public GameObject winningPopup;

    DateTime startTime, endTime;


    void Start()
    {
        startTime = DateTime.Now;

    }


    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if ("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag) ||
             "PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag))
        {
            currentCollisions.Add(collision.gameObject);
        }


        int len = currentCollisions.Count;

        // len/2 because its counting twice for each object added
        if ((len / 2 == (GameObject.FindGameObjectsWithTag("BlueBall").Length +
       GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length
       + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length)) &&
       (GameObject.FindGameObjectsWithTag("BlueBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length
       == GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length))
        {


            string levelName = SceneManager.GetActiveScene().name;
            string[] levelSplit = levelName.Split("_");

            int inner_level = Int32.Parse(levelSplit[2]);
            int outer_level = Int32.Parse(levelSplit[1]);

            Debug.Log("You Win");
            endTime = DateTime.Now;
            int time_taken = (int)(endTime - startTime).TotalSeconds;
            Debug.Log("time taken" + time_taken);

            int user_rating = 3;
            // GamesManager._instance.calculate_user_ratings(GamesManager.WIN, levelName, time_taken);
            // Debug.Log("User rating is " + user_rating);
            // GetComponent<StarHandler>().starsAcheived(user_rating);
            // Debug.Log("setting up winning pop-up");


            winningPopup.SetActive(true);


            //Analytics for time taken
            AnalyticsManager._instance.analytics_time_takenn(levelName, time_taken, GamesManager.WIN, RestartButton.isRestartClicked);
            //Analytics for user ratings
            AnalyticsManager._instance.analytics_user_ratings(levelName, time_taken, user_rating, GamesManager.WIN);

            yield return new WaitForSeconds(4);

            //Auto Level Movement
            
            if(levelName == "Level_0_1") //Intro 
            {
                SceneManager.LoadScene("Level_0_2");
            }
            else if(levelName == "Level_0_2")
            {
                SceneManager.LoadScene("Level_0_3");
            }
            else if (levelName == "Level_0_3")
            {
                SceneManager.LoadScene("Level_1_2");
            }
            else if (levelName == "Level_1_2") //Power-up and pink walls
            {
                SceneManager.LoadScene("Level_1_3");
            }
            else if (levelName == "Level_1_3")
            {
                SceneManager.LoadScene("Level_2_1"); //Magnet
            }
            else if (levelName == "Level_2_1")
            {
                SceneManager.LoadScene("Level_2_2");
            }
            else if (levelName == "Level_2_2")
            {
                SceneManager.LoadScene("Level_4_1"); //ShakeGrid
            }
            else if (levelName == "Level_4_1")
            {
                SceneManager.LoadScene("Level_4_2");
            }
            else if (levelName == "Level_4_2")
            {
                SceneManager.LoadScene("killerlevel_5_1"); //Killer Ball
            }
            else if (levelName == "killerlevel_5_1")
            {
                SceneManager.LoadScene("killerlevel_5_2");
            }
            else if (levelName == "killerlevel_5_2") //Combo,Bonus,Hard
            {
                SceneManager.LoadScene("Level_6_1");
            }
            else if (levelName == "Level_6_1") 
            {
                SceneManager.LoadScene("Level_6_2");
            }
            else if (levelName == "Level_6_2")
            {
                SceneManager.LoadScene("killerlevel_6_3");
            }
            else if (levelName == "killerlevel_6_3") 
            {
                SceneManager.LoadScene("Level_0_4");
            }
            else if (levelName == "Level_0_4") 
            {
                SceneManager.LoadScene("Level_1_1");
            }
            else if (levelName == "Level_1_1") 
            {
                SceneManager.LoadScene("Level_1_4");
            }
            else if (levelName == "Level_1_4") 
            {
                SceneManager.LoadScene("Level_4_3");
            }
            else if (levelName == "Level_4_3")
            {
                SceneManager.LoadScene("Level_2_3");
            }
            else if (levelName == "Level_2_3")
            {
                SceneManager.LoadScene("foglevel_3_1");
            }
            else if (levelName == "foglevel_3_1")
            {
                SceneManager.LoadScene("foglevel_3_2");
            }else if(levelName == "foglevel_3_2")
            {
                SceneManager.LoadScene("Level Manager");
            }
            





            RestartButton.prev_level = SceneManager.GetActiveScene().name;

            
            

        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        // Remove the GameObject collided with from the list.
        Debug.Log("I EXIT");
        currentCollisions.Remove(collision.gameObject);
    }
}





//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class CheckWinCondition : MonoBehaviour
//{
//    List <GameObject> currentCollisions = new List <GameObject> ();
//    public GameObject winningPopup;

//    DateTime startTime, endTime;


//    void Start()
//    {
//        startTime = DateTime.Now;

//    }


//    IEnumerator OnTriggerEnter2D(Collider2D collision){
//       if("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag) ||
//            "PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag))
//        {
//            currentCollisions.Add(collision.gameObject);
//       }


//        int len = currentCollisions.Count ;

//        // len/2 because its counting twice for each object added
//        if ((len/2 == (GameObject.FindGameObjectsWithTag("BlueBall").Length +
//       GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length
//       + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length)) &&
//       (GameObject.FindGameObjectsWithTag("BlueBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_BlueBall").Length
//       == GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("PinkBall_RedBall").Length)) {


//            string levelName = SceneManager.GetActiveScene().name;
//            string []levelSplit = levelName.Split("_");

//            int inner_level = Int32.Parse(levelSplit[2]);
//            int outer_level = Int32.Parse(levelSplit[1]);

//            Debug.Log("You Win");
//            endTime = DateTime.Now;
//            int time_taken = (int)(endTime - startTime).TotalSeconds;
//            Debug.Log("time taken" + time_taken);

//            int user_rating = 3;
//            // GamesManager._instance.calculate_user_ratings(GamesManager.WIN, levelName, time_taken);
//            // Debug.Log("User rating is " + user_rating);
//            // GetComponent<StarHandler>().starsAcheived(user_rating);
//            // Debug.Log("setting up winning pop-up");


//            winningPopup.SetActive(true);


//            //Analytics for time taken
//            AnalyticsManager._instance.analytics_time_takenn(levelName, time_taken, GamesManager.WIN, RestartButton.isRestartClicked);
//            //Analytics for user ratings
//            AnalyticsManager._instance.analytics_user_ratings(levelName, time_taken, user_rating, GamesManager.WIN);

//            yield return new WaitForSeconds(4);
//            //Auto Level Movement
//            inner_level++;
//            if (levelName == "Level_0_3")
//            {
//                outer_level++;
//                inner_level = 2;
//            }
//            else if (levelName == "Level_1_4")
//            {
//                outer_level = 2;
//                 inner_level = 1;
//            }
//            else if (levelName == "Level_1_1")
//            {
//                outer_level = 0;
//                inner_level = 4;
//            }
//            else if (levelName == "Level_2_3")
//            {
//                outer_level = 4;
//                inner_level = 1;
//            }
//            else if (levelName == "Level_4_3")
//            {
//                SceneManager.LoadScene("killerlevel_5_1");
//            }
//            else if (levelName == "killerlevel_5_1")
//            {
//                SceneManager.LoadScene("killerlevel_5_2");
//            }
//            else if (levelName == "killerlevel_5_2")
//            {
//                SceneManager.LoadScene("foglevel_3_1");
//            }
//            else if (levelName == "foglevel_3_1")
//            {
//                SceneManager.LoadScene("foglevel_3_2");
//            }
//            else if (levelName == "foglevel_3_2")
//            {
//                SceneManager.LoadScene("Level_6_1");
//            }
//            else if (levelName == "Level_6_3")
//            {
//                SceneManager.LoadScene("Level_0_4");
//            }
//            else if (levelName == "Level_0_4")
//            {
//                SceneManager.LoadScene("Level_1_1");
//            }

//            //remove after week 14 presentation
//            if (outer_level == 6 && inner_level == 2)
//            {
//                inner_level = 3;
//            }

//            string load_scene = "Level_" + outer_level.ToString() + "_" + inner_level.ToString();
//            RestartButton.prev_level = SceneManager.GetActiveScene().name;

//            Debug.Log("Auto Load scene " + load_scene);
//            if (load_scene != "Level_0_5" || load_scene !="Level_2_4")
//            {
//                SceneManager.LoadScene(load_scene);
//            }

//        }
//   }


//   void OnTriggerExit2D(Collider2D collision) {
//        // Remove the GameObject collided with from the list.
//        Debug.Log("I EXIT");
//        currentCollisions.Remove(collision.gameObject);
//   }
//}
