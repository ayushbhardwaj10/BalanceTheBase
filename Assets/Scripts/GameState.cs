using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject blueTrianglePrefab;// = Resources.Load("Prefabs/Blue Splitter", GameObject) as GameObject;
    private Dictionary<string, int> blue = new Dictionary<string, int>();

    private void getSplitters()
    {
        GameObject[] blueSplitters = GameObject.FindGameObjectsWithTag("BlueSplitterTriangle");
        Debug.Log(blueSplitters.Length);
        foreach (GameObject splitter in blueSplitters)
        {
            Debug.Log("Instance ID: " + splitter.GetInstanceID());
            CustomTransform transform = new CustomTransform(
                splitter.transform.position + Vector3.forward,
                splitter.transform.rotation,
                splitter.transform.localScale);

            SplitterState ts = new SplitterState(transform, GameObject.Find("Parent Walls").transform);
            
            GameObject newObject = Instantiate(blueTrianglePrefab);

            newObject.transform.position = transform.position + Vector3.forward;
            newObject.transform.rotation = transform.rotation;
            newObject.transform.localScale = transform.scale;
            newObject.transform.parent = ts.parent;
        }

        GameObject[] redSplitters = GameObject.FindGameObjectsWithTag("RedSplitterTriangle");

        foreach (GameObject splitter in redSplitters)
        {
            Debug.Log("Instance ID: " + splitter.GetInstanceID());
            // Transform transform = Instantiate(splitter.transform);
        }

        GameObject[] blinkingSplitters = GameObject.FindGameObjectsWithTag("BlinkingSplitter");

        foreach (GameObject splitter in blinkingSplitters)
        {
            Debug.Log("Instance ID: " + splitter.GetInstanceID());
            // Transform transform = Instantiate(splitter.transform);
        }
    }

    void Start()
    {
        // Triangles State
        getSplitters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void savePreference() {
        Debug.Log("Hello from MySharedMethod!");
    }

//     // Create a new dictionary

// // Add some key-value pairs
// myMap.Add("Alice", 23);
// myMap.Add("Bob", 42);
// myMap.Add("Charlie", 37);

// // Access a value using its key
// int aliceAge = myMap["Alice"];

// // Check if a key exists in the map
// bool hasBob = myMap.ContainsKey("Bob");

// // Iterate over all key-value pairs in the map
// foreach (KeyValuePair<string, int> kvp in myMap) {
//     string name = kvp.Key;
//     int age = kvp.Value;
//     Debug.Log(name + " is " + age + " years old.");
// }

    private class SplitterState {
        public CustomTransform transform;
        public Transform parent;

        public SplitterState(CustomTransform t, Transform p)
        {
            transform = t;
            parent = p;
        }
    }

    private class CustomTransform {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public CustomTransform(Vector3 p, Quaternion r, Vector3 s) 
        {
            position = p;
            rotation = r;
            scale = s;
        }
    }
}
