using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMessageOrder12 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ("BlueBall".Equals(collision.gameObject.tag) || "RedBall".Equals(collision.gameObject.tag) ||
            "PinkBall_BlueBall".Equals(collision.gameObject.tag) || "PinkBall_RedBall".Equals(collision.gameObject.tag))
        {
            GameObject myGameObject = GameObject.Find("Canvas (2)");
            MessageOrder12 myScript = myGameObject.GetComponent<MessageOrder12>();
            myScript.MoveToInstruction2();
        }
    }
}
