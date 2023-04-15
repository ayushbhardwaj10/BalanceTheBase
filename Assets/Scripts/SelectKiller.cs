using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectKiller : MonoBehaviour
{
    static Queue<GameObject> ballsQueue = new Queue<GameObject>();
    public TextMeshProUGUI killerModeStatus;

    private bool keyPressed = false;
    private bool killerModeKeyPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] redBalls = GameObject.FindGameObjectsWithTag("RedBall");
        GameObject[] blueBalls = GameObject.FindGameObjectsWithTag("BlueBall");

        foreach (GameObject redBall in redBalls)
        {
            ballsQueue.Enqueue(redBall);
        }

        foreach (GameObject blueBall in blueBalls)
        {
            ballsQueue.Enqueue(blueBall);
        }
        Debug.Log(ballsQueue.Count);
    }

    public static void addBallToQueue(GameObject ball)
    {
        ballsQueue.Enqueue(ball);
    }

    public static void removeBallFromQueue(int deletedID)
    {
        Queue<GameObject> tmpQueue = new Queue<GameObject>();
        while (ballsQueue.Count > 0)
        {
            GameObject go = ballsQueue.Dequeue();
            
            if (deletedID == go.GetInstanceID())
                continue;

            tmpQueue.Enqueue(go);
        }
        ballsQueue = tmpQueue;
        Debug.Log("Removed ball from queue. New size: " + ballsQueue.Count);
    }

    public static void removeHaloFromAllBalls()
    {
        GameObject[] redBalls = GameObject.FindGameObjectsWithTag("RedBall");
        GameObject[] blueBalls = GameObject.FindGameObjectsWithTag("BlueBall");

        foreach (GameObject redBall in redBalls)
        {
            foreach (Transform child in redBall.transform)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (GameObject blueBall in blueBalls)
        {
            foreach (Transform child in blueBall.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Turning the killer mode ON/OFF
        if (Input.GetKey(KeyCode.K) && !killerModeKeyPressed)
        {
            killerModeKeyPressed = true;

            if(killerModeStatus.text == "ON")
            {
                removeHaloFromAllBalls();
                killerModeStatus.text = "OFF";
            }
            else
            {
                killerModeStatus.text = "ON";
            }
        }

        // Reset the flag if the key is released
        if (Input.GetKeyUp(KeyCode.K))
        {
            killerModeKeyPressed = false;
        }

        //Choosing the killer ball
        if (Input.GetKey(KeyCode.Space) && killerModeStatus.text == "ON" && !keyPressed)
        {
            keyPressed = true;

            // Revoke the killer power from current ball
            GameObject currentBall = ballsQueue.Dequeue();
            Debug.Log("Balls queue count - " + ballsQueue.Count);
            foreach (Transform child in currentBall.transform)
            {
                // Destroy the child game object
                Destroy(child.gameObject);
            }
            ballsQueue.Enqueue(currentBall);


            // Making a normal ball into a killer ball
            GameObject chosenBall = ballsQueue.Peek();

            Debug.Log(chosenBall.name);

            // Create a new game object with a circle sprite
            GameObject circleObject = new GameObject("Halo");
            SpriteRenderer circleRenderer = circleObject.AddComponent<SpriteRenderer>();
            circleRenderer.sprite = Resources.Load<Sprite>("Sprites/Circle");
            circleRenderer.color = Color.cyan;
            circleObject.transform.SetParent(chosenBall.transform);
            circleObject.transform.localPosition = Vector3.zero;
            circleObject.transform.localScale = chosenBall.transform.localScale * 2f;
        }

        // Reset the flag if the key is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            keyPressed = false;
        }
    }
}
