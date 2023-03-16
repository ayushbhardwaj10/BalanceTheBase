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
    DateTime endTime;
    string levelName;

    private bool isDestroyedAlready;

   void Start(){
        prefab = Resources.Load<GameObject>("Prefabs/Pink Wall");
        levelName = SceneManager.GetActiveScene().name;

        isDestroyedAlready = false;
   }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("Stay start.....");
        if ("PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag))
        {
            // change the walls only when space button is pressed
            if (Input.GetKey(KeyCode.S) == true && !isDestroyedAlready) {

                endTime = DateTime.Now;
                var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
                go.transform.parent = gameObject.transform.parent;
                go.transform.localScale = gameObject.transform.localScale;

                AnalyticsManager._instance.analytics_pink_walls(go.transform.localScale, gameObject.transform.name, DateTime.Now,GamesManager.powerAttainStartTime,levelName);
                GamesManager.powerAttainStartTime = DateTime.MinValue;

                Debug.Log("Destroying game object - " + gameObject.name);
                
                //Save ID of deleted game object
                List<int> deletedIdList = new List<int>(); 
                int deletedID = gameObject.GetInstanceID();
                deletedIdList.Add(deletedID);

                Destroy(gameObject);
                //This variable avoids the state from getting updated multiple times
                isDestroyedAlready = true;

                //Update game state
                GameStateTracking.UpdateGameStack(deletedIdList, "Pink Wall Script: " + gameObject.name);
            }

        }

    }
}
