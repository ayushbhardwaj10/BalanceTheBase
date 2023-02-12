using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckWinCondition : MonoBehaviour
{
   // Start is called before the first frame update
  


   // Update is called once per frame
   void Update()
   {
       Debug.Log("ccc"+GoalRegion.count);
       if(GameObject.FindGameObjectsWithTag("RedBall").Length == GameObject.FindGameObjectsWithTag("BlueBall").Length &&
       GoalRegion.count == (GameObject.FindGameObjectsWithTag("RedBall").Length + GameObject.FindGameObjectsWithTag("BlueBall").Length)){
           Debug.Log(GoalRegion.count);
           Debug.Log("You Win!");
           Time.timeScale = 0;


       }
   }
}
