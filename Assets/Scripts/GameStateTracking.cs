using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracking : MonoBehaviour
{
    public static GameObject blueTrianglePrefab;
    
    static Stack<GameState> gameStack = new Stack<GameState>();

    public static void UpdateGameStack(List<int> deletedIDs)
    {
        Debug.Log("Updating game stack");

        gameStack.Push(new GameState(getState("BlueSplitterTriangle", deletedIDs),
                                        getState("RedSplitterTriangle", deletedIDs),
                                        getState("BlinkingSplitter", deletedIDs),
                                        getState("BlueBall", deletedIDs),
                                        getState("RedBall", deletedIDs),
                                        getState("PinkBall_BlueBall", deletedIDs),
                                        getState("PinkBall_RedBall", deletedIDs),
                                        getState("Inner_White_Wall", deletedIDs),
                                        getState("Pink_Wall", deletedIDs),
                                        getState("MazeWalls", deletedIDs))
                                        );

        Debug.Log("Update Game state Stack size.." + gameStack.Count);

        //Remove later
        GameState prevState = gameStack.Peek();
        Debug.Log("Redsplitter count" + prevState.redSplitters.Count);
        Debug.Log("Bluesplitter count" + prevState.blueSplitters.Count);
        Debug.Log("Blinking splitter count" + prevState.blinkingSplitters.Count);
    }

    public static void UndoLastMove()
    {
        Debug.Log("Undoing last move");

        // The first move represents the initial state of the game and cannot be undone
        if (gameStack.Count <= 1) //----Change this to == 1 after you add an undo button-----//
            return;

        GameState prevState = gameStack.Peek();

        Debug.Log("Before pop Stack size.." + gameStack.Count);
        Debug.Log("Redsplitter count" + prevState.redSplitters.Count);
        Debug.Log("Bluesplitter count" + prevState.blueSplitters.Count);
        Debug.Log("Blinking splitter count" + prevState.blinkingSplitters.Count);

        // Remove the top most element
        gameStack.Pop();
        Debug.Log("Pop Stack size.." + gameStack.Count);

        // Destroy all current inner game objects
        DestroyAllObjects();

        // Resurrect everything from history
        prevState = gameStack.Peek();

        Debug.Log("Stack size.." + gameStack.Count);
        Debug.Log("Redsplitter count" + prevState.redSplitters.Count);
        Debug.Log("Bluesplitter count" + prevState.blueSplitters.Count);
        Debug.Log("Blinking splitter count" + prevState.blinkingSplitters.Count);


        //--------Find a way to get the main maze wall without using the GameObject.Find() function below--------//
        foreach (State state in prevState.mazeWalls)
        {
            setGameObjectTransform(GameObject.Find("Parent Walls"), state);
        }
        
        foreach (State state in prevState.blueSplitters)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Splitter-Blue"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.redSplitters)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Splitter-Red"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.blinkingSplitters)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Blinking Splitter"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.blueBalls)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Blue Ball"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.redBalls)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Red Ball"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.pinkBlueBalls)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/PinkBallBlueBall"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.pinkRedBalls)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/PinkBallRedBall"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.innerWhiteWalls)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Inner_walls"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.pinkWalls)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Pink Wall"));
            setGameObjectTransform(newObject, state);
        }
    }

    private static void setGameObjectTransform(GameObject newObject, State state)
    {
        newObject.transform.position = state.transform.position;
        newObject.transform.rotation = state.transform.rotation;
        newObject.transform.localScale = state.transform.scale;
        newObject.transform.parent = state.parent;
    }

    private static void DestroyAllObjects()
    { 
        string[] tags = new string[]{"BlueSplitterTriangle", "RedSplitterTriangle", "BlinkingSplitter", "BlueBall", "RedBall", "PinkBall_BlueBall", "PinkBall_RedBall", "Inner_White_Wall", "Pink_Wall"};

        foreach (string tag in tags)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                Destroy(obj);
            }
        }
    }

    private static List<State> getState(string tag, List<int> deletedIDs)
    {
        List<State> StateList = new List<State>();

        GameObject[] splitters = GameObject.FindGameObjectsWithTag(tag);
        
        foreach (GameObject splitter in splitters)
        {
            //Do not fetch the state of deleted IDs
            if (deletedIDs.Contains(splitter.GetInstanceID()))
                continue;

            CustomTransform transform = new CustomTransform(
                splitter.transform.position,
                splitter.transform.rotation,
                splitter.transform.localScale);

            State obj = new State(transform, splitter.transform.parent);//GameObject.Find("Parent Walls").transform);

            StateList.Add(obj);
        }

        return StateList;
    }

    void Start()
    {
        UpdateGameStack(new List<int>());
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKey(KeyCode.U))
    //     {
    //         UndoLastMove();
    //     }
    // }

    private class GameState {
        public List<State> blueSplitters;
        public List<State> redSplitters;
        public List<State> blinkingSplitters;

        // Balls State
        public List<State> blueBalls;
        public List<State> redBalls;
        public List<State> pinkBlueBalls;
        public List<State> pinkRedBalls;

        // White Walls
        public List<State> innerWhiteWalls;

        // Pink Walls
        public List<State> pinkWalls;

        // Stars

        // Maze
        public List<State> mazeWalls;

        public GameState(List<State> blueSplittersObj,
                        List<State> redSplittersObj,
                        List<State> blinkingSplittersObj,
                        List<State> blueBallsObj,
                        List<State> redBallsObj,
                        List<State> pinkBlueBallsObj,
                        List<State> pinkRedBallsObj,
                        List<State> innerWhiteWallsObj,
                        List<State> pinkWallsObj,
                        List<State> mazeWallsObj)
        {
            blueSplitters = blueSplittersObj;
            redSplitters = redSplittersObj;
            blinkingSplitters = blinkingSplittersObj;
            blueBalls = blueBallsObj;
            redBalls = redBallsObj;
            pinkBlueBalls = pinkBlueBallsObj;
            pinkRedBalls = pinkRedBallsObj;
            innerWhiteWalls = innerWhiteWallsObj;
            pinkWalls = pinkWallsObj;
            mazeWalls = mazeWallsObj;
        }
    }

    private class State {
        public CustomTransform transform;
        public Transform parent;

        public State(CustomTransform cust, Transform par)
        {
            transform = cust;
            parent = par;
        }
    }

    private class CustomTransform {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public CustomTransform(Vector3 pos, Quaternion rot, Vector3 scl) 
        {
            position = pos;
            rotation = rot;
            scale = scl;
        }
    }
}
