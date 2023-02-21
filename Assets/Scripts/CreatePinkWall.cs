using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePinkWall : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject prefab;

    void Start(){
        prefab = GameObject.Find("Pink Wall");
    }

    void OnCollisionEnter2D(Collision2D collision){

        if("PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag)){
        var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
        go.transform.parent = gameObject.transform.parent;
        go.transform.localScale = gameObject.transform.localScale;
        Destroy(gameObject);
        }

    }
}
