using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CreatePinkWall : MonoBehaviour
{
   // Start is called before the first frame update
   public float speed;
   public GameObject prefab;
    string levelName;


   void Start(){
       prefab = GameObject.Find("Pink Wall");
       levelName = SceneManager.GetActiveScene().name;
    }


   void OnCollisionEnter2D(Collision2D collision){



       if("PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag)){
       var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
       go.transform.parent = gameObject.transform.parent;
       go.transform.localScale = gameObject.transform.localScale;

            AnalyticsManager._instance.analytics_pink_walls(go.transform.localScale, gameObject.name,DateTime.Now,levelName);
            Destroy(gameObject);
       }


   }
}
