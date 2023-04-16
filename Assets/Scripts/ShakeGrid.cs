using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeGrid : MonoBehaviour
{
    // Start is called before the first frame update
    private bool increasing = true; // Keep track of whether we are currently increasing Y position
    private bool coroutineRunning = false; // Keep track of whether the coroutine is currently running

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!coroutineRunning) // Start the coroutine only if it's not already running
            {
                StartCoroutine(ChangeYPosition());
            }
        }
    }

    IEnumerator ChangeYPosition()
    {
        coroutineRunning = true;

        float deltaY = 0.4f; // The amount to change Y position by each time

        int numSteps = 4; // The number of steps to take between the starting and ending positions
        float stepSize = deltaY / numSteps; // The size of each step

        int numIterations = 2; // The number of times to repeat the sequence (increase then decrease)

        for (int i = 0; i < numIterations; i++)
        {
            for (int j = 0; j < numSteps; j++)
            {
                if (increasing)
                {
                    transform.position += new Vector3(0f, stepSize, 0f);
                }
                else
                {
                    transform.position -= new Vector3(0f, stepSize, 0f);
                }

                yield return new WaitForSeconds(0.05f); // Wait for 0.05 seconds between steps
            }

            increasing = !increasing; // Toggle whether we're increasing or decreasing
        }

        coroutineRunning = false;
    }
}

