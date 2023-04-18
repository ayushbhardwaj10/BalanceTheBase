using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateTracking : MonoBehaviour
{
    static Stack<GameState> gameStack = new Stack<GameState>();

    void Start()
    {
        //Start every game with a clear stack
        clearStack();
        
        UpdateGameStack(new List<int>(), "Start function");
    }

    // clear stack while restarting the scene view
    public static void clearStack(){
        if(gameStack != null)
            gameStack.Clear();
    }

    public static void UpdateGameStack(List<int> deletedIDs, string message)
    {
        Debug.Log("UPDATE: Triggered by - " + message);
        
        string timeLeftVal = "0";
        string killerModeStatusVal = "OFF";

        if(SceneManager.GetActiveScene().name.Contains("killer"))
        {
            TextMeshProUGUI timeLeftObj = GameObject.Find("TimerLeft").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI killerModeStatusObj = GameObject.Find("KillerModeStatus").GetComponent<TextMeshProUGUI>();

            if(timeLeftObj != null && killerModeStatusObj != null)
            {
                timeLeftVal = timeLeftObj.text;
                Debug.Log("Undo killer test - " + timeLeftVal);

                killerModeStatusVal = killerModeStatusObj.text;
                Debug.Log("Undo killer test - " + killerModeStatusVal);
            }
        }

        gameStack.Push(new GameState(getState("BlueSplitterTriangle", deletedIDs),
                                        getState("RedSplitterTriangle", deletedIDs),
                                        getState("BlinkingSplitter", deletedIDs),
                                        getState("BlueBall", deletedIDs),
                                        getState("RedBall", deletedIDs),
                                        getState("PinkBall_BlueBall", deletedIDs),
                                        getState("PinkBall_RedBall", deletedIDs),
                                        getState("Inner_White_Wall", deletedIDs),
                                        getState("Pink_Wall", deletedIDs),
                                        getState("MazeWalls", deletedIDs),
                                        getState("Star_Canvas", deletedIDs),
                                        timeLeftVal,
                                        killerModeStatusVal)
                                        );

        Debug.Log("UPDATE: Game state stack size after update - " + gameStack.Count);
    }

    public static void UndoLastMove()
    {
        //Side effect
        CheckLosingCondition.lostStatus = false;

        //Only for fog lighting levels
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        if (gameStack.Count < 1) // Worst case - Just as a fail safe
        {
            clearStack();
            UpdateGameStack(new List<int>(), "Fail safe function");
            return;
        }
        else if(gameStack.Count > 1) // The first move represents the initial state of the game and cannot be undone
        {
            // Remove the top most element
            gameStack.Pop();
        }

        // Destroy all current inner game objects
        List<int> deletedObjects = DestroyAllObjects();

        // Resurrect everything from history
        GameState prevState = gameStack.Peek();

        Debug.Log("UNDO: Game state stack size after undo - " + gameStack.Count);

        //--------todo: Find a way to get the main maze wall without using the GameObject.Find() function below--------//
        foreach (State state in prevState.mazeWalls)
        {
            setGameObjectTransform(GameObject.Find("Parent Walls"), state);
        }
        
        foreach (State state in prevState.blueSplitters)
        {
            string prefabPath = "Prefabs/Splitter-Blue";
            if(currentSceneName.Contains("fog"))
            {
                prefabPath = "Prefabs/Splitter-Blue With Light";
            }

            GameObject newObject = Instantiate(Resources.Load<GameObject>(prefabPath));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.redSplitters)
        {
            string prefabPath = "Prefabs/Splitter-Red";
            if(currentSceneName.Contains("fog"))
            {
                prefabPath = "Prefabs/Splitter-Red With Light";
            }

            GameObject newObject = Instantiate(Resources.Load<GameObject>(prefabPath));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.blinkingSplitters)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Blinking Splitter"));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.blueBalls)
        {
            string prefabPath = "Prefabs/Blue Ball";
            if(currentSceneName.Contains("fog"))
            {
                prefabPath = "Prefabs/Blue Ball With Light";
            }

            GameObject newObject = Instantiate(Resources.Load<GameObject>(prefabPath));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.redBalls)
        {
            string prefabPath = "Prefabs/Red Ball";
            if(currentSceneName.Contains("fog"))
            {
                prefabPath = "Prefabs/Red Ball With Light";
            }

            GameObject newObject = Instantiate(Resources.Load<GameObject>(prefabPath));
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
            string prefabPath = "Prefabs/Pink Wall";
            if(currentSceneName.Contains("fog"))
            {
                prefabPath = "Prefabs/Pink Wall With Light";
            }

            GameObject newObject = Instantiate(Resources.Load<GameObject>(prefabPath));
            setGameObjectTransform(newObject, state);
        }

        foreach (State state in prevState.stars)
        {
            GameObject newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Star Canvas"));
            setGameObjectTransform(newObject, state);
        }

        if(currentSceneName.Contains("killer"))
        {
            updateBallQueueInKillerScript(deletedObjects);

            //Set back timer and killer mode
            TextMeshProUGUI timeLeftObj = GameObject.Find("TimerLeft").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI killerModeStatusObj = GameObject.Find("KillerModeStatus").GetComponent<TextMeshProUGUI>();

            if(timeLeftObj != null && killerModeStatusObj != null)
            {
                timeLeftObj.GetComponent<EatingTimer>().timeLeft = int.Parse(prevState.timeLeft);

                killerModeStatusObj.text = "OFF"; //prevState.killerModeStatus;
            }
        }

        string levelName = SceneManager.GetActiveScene().name;
        AnalyticsManager._instance.analytics_undo_last_move(levelName, gameStack.Count);
    }

    private static void updateBallQueueInKillerScript(List<int> deletedIdList)
    {
        GameObject wallsParent = GameObject.Find("Parent Walls");

        if (wallsParent != null)
        {
            // Check if the "SelectKiller" script is attached to the parent "Walls" GameObject
            SelectKiller selectKillerScript = wallsParent.GetComponent<SelectKiller>();

            if (selectKillerScript != null)
            {
                // "SelectKiller" script is attached
                GameObject.Find("Parent Walls").GetComponent<SelectKiller>().refreshKillerBallQueue(deletedIdList);
                Debug.Log("Refreshing killer ball queue");
            }
            else
            {
                // "SelectKiller" script is not attached
                Debug.Log("The parent Walls GameObject does not contain a SelectKiller script.");
            }
        }
        else
        {
            // Parent "Walls" GameObject not found
            Debug.LogError("The parent Walls GameObject could not be found.");
        }
    }

    private static void setGameObjectTransform(GameObject newObject, State state)
    {
        newObject.transform.parent = state.parent;
        newObject.transform.position = state.transform.position;
        newObject.transform.rotation = state.transform.rotation;
        newObject.transform.localScale = state.transform.scale;
        
        newObject.name = state.name;
    }

    private static List<int> DestroyAllObjects()
    {
        List<int> deletedIdList = new List<int>(); 

        string[] tags = new string[]{"BlueSplitterTriangle", "RedSplitterTriangle", "BlinkingSplitter", "BlueBall", "RedBall", "PinkBall_BlueBall", "PinkBall_RedBall", "Inner_White_Wall", "Pink_Wall", "Star_Canvas"};

        foreach (string tag in tags)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                Destroy(obj);
                deletedIdList.Add(obj.GetInstanceID());
            }
        }

        return deletedIdList;
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

            State obj = new State(transform, splitter.transform.parent, splitter.name);

            StateList.Add(obj);
        }

        return StateList;
    }

    

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

        // Maze
        public List<State> mazeWalls;

        // Stars
        public List<State> stars;

        //Killer stats
        public string killerModeStatus = "OFF";
        public string timeLeft = "0";

        public GameState(List<State> blueSplittersObj,
                        List<State> redSplittersObj,
                        List<State> blinkingSplittersObj,
                        List<State> blueBallsObj,
                        List<State> redBallsObj,
                        List<State> pinkBlueBallsObj,
                        List<State> pinkRedBallsObj,
                        List<State> innerWhiteWallsObj,
                        List<State> pinkWallsObj,
                        List<State> mazeWallsObj,
                        List<State> starsObj)
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
            stars = starsObj;
        }

        public GameState(List<State> blueSplittersObj,
                        List<State> redSplittersObj,
                        List<State> blinkingSplittersObj,
                        List<State> blueBallsObj,
                        List<State> redBallsObj,
                        List<State> pinkBlueBallsObj,
                        List<State> pinkRedBallsObj,
                        List<State> innerWhiteWallsObj,
                        List<State> pinkWallsObj,
                        List<State> mazeWallsObj,
                        List<State> starsObj,
                        string timeLeftVal,
                        string killerModeStatusVal)
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
            stars = starsObj;
            timeLeft = timeLeftVal;
            killerModeStatus = killerModeStatusVal;
        }
    }

    private class State {
        public string name;
        public CustomTransform transform;
        public Transform parent;

        public State(CustomTransform cust, Transform par, string nam)
        {
            transform = cust;
            parent = par;
            name = nam;
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
