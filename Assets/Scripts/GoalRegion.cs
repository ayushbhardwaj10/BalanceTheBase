using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalRegion : MonoBehaviour
{
   public float xLeftPosition;
   public float yTopPosition;
   public float xRightPosition;
   public float yBottomPosition;
   public GameObject gameObjectToDrag;
   public int initialCount;
   public static int count=0;
   public bool check;
   List<string> balls = new List<string>();


  void Start(){
       balls.Clear();
  }
   void Update()
   {
       if(transform.position.x >= xLeftPosition && transform.position.x <= xRightPosition && transform.position.y >= yBottomPosition
       && transform.position.y <= yTopPosition){
           if(!balls.Contains(this.gameObject.name)){
           count+=1;
           balls.Add(this.gameObject.name);
           // Debug.Log(this.gameObject.name);
           }
           // balls.ForEach(p => Debug.Log(p));
       }
   }
}
