using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Nothing should happen if colliding with a non-player object (anything other than red/blue balls)
        if(!(collision.gameObject.tag != null && collision.gameObject.tag.Contains("Ball")))
            return;

        if(doesBallHaveHalo(gameObject))
        {
            if("BlueBall".Equals(collision.gameObject.tag) && "RedBall".Equals(gameObject.tag))
            {
                return;
            }
            else if("RedBall".Equals(collision.gameObject.tag) && "BlueBall".Equals(gameObject.tag))
            {
                return;
            }
            else //Same color ball collisions
            {   
                List<int> delIdList = new List<int>(); 

                //Kill the splitter
                int delId = collision.gameObject.GetInstanceID();
                delIdList.Add(delId);
                Destroy(collision.gameObject);

                SelectKiller.removeBallFromQueue(delId);
                
                //Update game state
                GameStateTracking.UpdateGameStack(delIdList, "Kill balls script: " + gameObject.name);
            }
            return;
        }
    }

    bool doesBallHaveHalo(GameObject ball)
    {
        foreach (Transform child in ball.transform)
        {
            if(child.name == "Halo")
            {
                return true;
            }
        }
        return false;
    }
}
