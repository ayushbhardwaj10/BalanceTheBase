using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateBlinkingBall : MonoBehaviour
{
   public GameObject prefab;

   void Start()
   {
       if(gameObject.tag=="BlueBall"){
        prefab = Resources.Load<GameObject>("Prefabs/PinkBallBlueBall");
       } else {
         prefab = Resources.Load<GameObject>("Prefabs/PinkBallRedBall");
       }
   }

   void Update()
   {
        if((gameObject.tag=="PinkBall_BlueBall" || gameObject.tag=="PinkBall_RedBall")){

          var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);

          go.transform.parent = gameObject.transform.parent;
          go.transform.localScale = gameObject.transform.localScale;
          Destroy(gameObject);
        }  
   }


}
