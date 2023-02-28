using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkBall : MonoBehaviour
{
    Color blueColor = new Vector4(0.09019608f, 0.6f, 0.9058824f,1.0f);
    Color pinkColor = new Vector4(0.8679245f, 0.4216803f, 0.7468505f,1.0f);
    Color redColor = new Vector4(0.7830189f, 0.1578784f, 0.1071111f,1.0f);
    bool destroy = true;
    bool check = false;
    Color originalColor;
    public GameObject prefab;


    IEnumerator Start()
    {
        if(gameObject.tag.Contains("BlueBall")){
           originalColor = blueColor;
           prefab = Resources.Load<GameObject>("Prefabs/Blue Ball");
        } else {
           originalColor = redColor;
           prefab = Resources.Load<GameObject>("Prefabs/Red Ball");
        }  
        InvokeRepeating ("colorChange", 0.0f, 1.0f);
        yield return new WaitForSeconds(5);
        InvokeRepeating ("destroyBalls", 0.0f, 1.0f);      
    }


    void destroyBalls()
    {
        if(destroy){
        var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
        go.transform.parent = gameObject.transform.parent;
        go.transform.localScale = gameObject.transform.localScale;
        Destroy(gameObject);
        destroy = false;
        }
    }

    
    void colorChange()
    {
           if(check==true) {
                gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
                check = false;
            } 
            else {
                gameObject.GetComponent<SpriteRenderer> ().color = pinkColor;
                check = true;
            }       
    }

}
