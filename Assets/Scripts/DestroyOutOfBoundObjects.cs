using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundObjects : MonoBehaviour
{
    List<int> deletedIdList = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CustomStateUpdate", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CustomStateUpdate()
    {
        if(deletedIdList.Count > 0)
        {
            //Update game state
            GameStateTracking.UpdateGameStack(deletedIdList, "Destroy out of bounds script");
            deletedIdList.Clear();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // List<int> deletedIdList = new List<int>(); 

        // //Get instance ID of the deleted objects for updating state
        // int deletedID = collision.gameObject.GetInstanceID();
        deletedIdList.Add(collision.gameObject.GetInstanceID());
        Destroy(collision.gameObject);

        //Update game state
        // GameStateTracking.UpdateGameStack(deletedIdList, "Destroy out of bounds script: " + collision.gameObject.name);
    }
}
