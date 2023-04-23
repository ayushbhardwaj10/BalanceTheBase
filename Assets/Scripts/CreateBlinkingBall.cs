using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateBlinkingBall : MonoBehaviour
{
   public GameObject prefab;
   public int timer = 0;


    public string objectTag = "Inner_White_Wall"; // The tag of the objects to blink
    public float blinkInterval = 1f; // The time in seconds between blinks
    private SpriteRenderer[] spriteRenderers; // An array of all sprite renderer components with the specified tag
    private Color[] originalColors; // An array of the original colors of all objects
    private bool isBlinking = false;
    float seconds = 4f;

    float t1 = 0;

    void Start()
   {

        // Find all game objects with the specified tag
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objectTag);

        // Initialize arrays
        spriteRenderers = new SpriteRenderer[objects.Length];
        originalColors = new Color[objects.Length];

        // Get the sprite renderer component and original color for each object
        for (int i = 0; i < objects.Length; i++)
        {
            spriteRenderers[i] = objects[i].GetComponent<SpriteRenderer>();
            originalColors[i] = spriteRenderers[i].color;
            Debug.Log("original Colors " + originalColors[i]);
        }



        if ("PinkBall_RedBall" == gameObject.tag || "PinkBall_BlueBall" == gameObject.tag){
          timer = 8;

          //For setting the timer
          gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TimerChangeScript>().timerVal = timer;

          InvokeRepeating ("runTimer", 0.0f, 1.0f);
       } 
       if(gameObject.tag=="BlueBall"){
        prefab = Resources.Load<GameObject>("Prefabs/PinkBallBlueBall");
       } else {
         prefab = Resources.Load<GameObject>("Prefabs/PinkBallRedBall");
       }

   }

   void Update()
   {
    
   }

    void runTimer()
    {
      //For setting the timer
      gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TimerChangeScript>().timerVal = timer;

      if (timer <= 0)
      {
        gameObject.GetComponent<BlinkBall>().destroyBalls();
      }

      // Run the timer every second
      timer -= 1;    
    }

    public void updateTimer(int newTime)
    {
      timer = newTime;
    }
  
    void OnTriggerEnter2D(Collider2D collision)
    {
        if("PowerUp_Star" == collision.gameObject.tag){

            StartCoroutine(BlinkForSeconds(4f));
            
            GamesManager.powerAttainStartTime = DateTime.Now; 

          // Destroy the star and the canvas holding it
          // Save ID of deleted game object
          GameObject parent = collision.gameObject.transform.parent.gameObject;
          List<int> deletedIdList = new List<int>(); 
          int deletedID = parent.GetInstanceID();
          deletedIdList.Add(deletedID);

          Destroy(parent);

          if("RedBall" == gameObject.tag || "BlueBall" == gameObject.tag){
            var go = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);

            go.transform.parent = gameObject.transform.parent;
            go.transform.localScale = gameObject.transform.localScale;
            deletedIdList.Add(gameObject.GetInstanceID());
            Destroy(gameObject);
          }
          else if("PinkBall_RedBall" == gameObject.tag || "PinkBall_BlueBall" == gameObject.tag){
            timer += 8;
          } 




          //Update game state
          GameStateTracking.UpdateGameStack(deletedIdList, "Create blink ball script: " + collision.gameObject.name);
        }
    }

    private IEnumerator BlinkForSeconds(float seconds)
    {
        isBlinking = true;
        float timePassed = 0f;
        while (timePassed < seconds)
        {
            // Change the alpha value of each object to 0 (disappear) and then back to its original color (reappear)
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].color = Color.cyan;

            }
            yield return new WaitForSeconds(blinkInterval);
            
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].color = originalColors[i];
            }
            yield return new WaitForSeconds(blinkInterval);
            timePassed += blinkInterval * 2f;
        }
        // Set the color of each object back to its original color
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = originalColors[i];

        }

    }

}
