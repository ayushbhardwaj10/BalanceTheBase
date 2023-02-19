using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public void levelChangeTo01() {
        SceneManager.LoadScene("Level_0_1");
    }
    public void levelChangeTo02()
    {
        SceneManager.LoadScene("Level_0_2");
    }
    public void levelChangeTo03()
    {
        SceneManager.LoadScene("Level_0_3");
    }
    public void levelChangeTo04()
    {
        SceneManager.LoadScene("Level_0_4");
    }
    public void levelChangeTo2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void levelChangeToLevelManager()
    {
        SceneManager.LoadScene("Level Manager");
    }
    public void restartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
