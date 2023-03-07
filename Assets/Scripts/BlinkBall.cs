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
    // int timer = 0;
    public GameObject prefab;


    void Start()
    {
        InvokeRepeating ("colorChange", 0.0f, 1.0f);
        // yield return new WaitForSeconds(timer);
        // InvokeRepeating ("destroyBalls", 0.0f, 1.0f);    
    }

    // void Update(){
    //     if(gameObject.tag == "PinkBall_BlueBall" || gameObject.tag=="PinkBall_RedBall"){
    //         callRepeatedly();
    //     }
    // }

    // IEnumerator callRepeatedly(){
    //     InvokeRepeating ("colorChange", 0.0f, 1.0f);
    //     yield return new WaitForSeconds(timer);
    //     InvokeRepeating ("destroyBalls", 0.0f, 1.0f); 
    // }

    // public void updateTimer(int newTime){
    //     timer = newTime;
    // }

    public void destroyBalls()
    {
        if(gameObject.tag.Contains("BlueBall")){
           prefab = Resources.Load<GameObject>("Prefabs/Blue Ball");
        } else {
           prefab = Resources.Load<GameObject>("Prefabs/Red Ball");
        }  
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
           if(gameObject.tag.Contains("BlueBall")){
                originalColor = blueColor;
           } else {
                originalColor = redColor;
           }  
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
