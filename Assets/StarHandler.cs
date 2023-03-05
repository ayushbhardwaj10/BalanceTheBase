using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public GameObject[] Stars;
    public int numofretry;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("star script called start func");
        //retrive values here 
         numofretry = 2;
         win = true;
    }

    public void starsAcheived(int user_rating){
        Debug.Log("function called in starsAcheived ");
        Debug.Log("User rating in Star script" + user_rating);

        if( user_rating == 0)
        {
           Debug.Log("No Rating assinged for user");
        }
        if( user_rating == 1)
        {
           Stars[2].SetActive(true);
        }
        if( user_rating == 2)
        {
           Stars[2].SetActive(true);
           Stars[3].SetActive(true);
        }
        if( user_rating == 3)
        {
          Stars[1].SetActive(true);
          Stars[2].SetActive(true);
          Stars[3].SetActive(true);
        }
        if( user_rating == 4)
        {
          Stars[1].SetActive(true);
          Stars[2].SetActive(true);
          Stars[3].SetActive(true);
          Stars[4].SetActive(true);
        }

        if( user_rating == 5)
        {
          Stars[0].SetActive(true);
          Stars[1].SetActive(true);
          Stars[2].SetActive(true);
          Stars[3].SetActive(true);
          Stars[4].SetActive(true);

        }

        

       
    }
}
