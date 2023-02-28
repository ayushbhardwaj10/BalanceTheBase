using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatePinkWall : MonoBehaviour
{
   // Start is called before the first frame update
   public float speed;
   public GameObject prefab;


   void Start(){
       prefab = Resources.Load<GameObject>("Prefabs/Pink Wall");
   }


    //void OnCollisionEnter2D(Collision2D collision){

    //    if("PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag)){
    //    Debug.Log("super power collision...");
    //    var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
    //    go.transform.parent = gameObject.transform.parent;
    //    go.transform.localScale = gameObject.transform.localScale;
    //    Destroy(gameObject);
    //    }

    //}

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    Debug.Log("Stay");
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("PLayer Detected");
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            Debug.Log("E pressed");
    //        }
    //    }
    //}

    void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("Stay start.....");
        if ("PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag))
        {
            // change the walls only when space button is pressed
            if (Input.GetKey(KeyCode.S) == true) {
                Debug.Log("super power collision...");
                var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
                go.transform.parent = gameObject.transform.parent;
                go.transform.localScale = gameObject.transform.localScale;
                Destroy(gameObject);
            }

        }

    }
}
