using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public GameObject[] Stars;
    public int numofretry;
    public bool win;
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;


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
        oneStar.SetActive(false);
        twoStar.SetActive(false);
        threeStar.SetActive(false);


        if ( user_rating == 0)
        {
           Debug.Log("No Rating assinged for user");
        }
        if( user_rating == 1)
        {
           Debug.Log("user rating 1");
           Stars[2].SetActive(true);
           oneStar.SetActive(true);
        }
        if( user_rating == 2)        
        {
          Debug.Log("User Rating 2");
          Vector2 star2_currentPosition = Stars[2].transform.position;
          float star2_x = star2_currentPosition.x;
          float star2_y = star2_currentPosition.y;
          float star2_newX = star2_x - 15;
          Debug.Log("x position of Star-2" + star2_x );
          Debug.Log("new x position of Star-2" + star2_newX );
          Vector2 star2_newPosition = new Vector2(star2_newX, star2_y);
          Stars[2].transform.position = star2_newPosition;

          Vector2 star4_currentPosition = Stars[3].transform.position;
          float star4_x = star4_currentPosition.x;
          float star4_y = star4_currentPosition.y;
          float star4_newX = star4_x - 25;
          Debug.Log("x position of Star-4" + star4_x );
          Debug.Log("new x position of Star-4" + star4_newX );
          Vector2 star4_newPosition = new Vector2(star4_newX, star4_y);
          Stars[3].transform.position = star4_newPosition;




          Stars[2].SetActive(true);
          Stars[3].SetActive(true);
          twoStar.SetActive(true);

        }
        if ( user_rating == 3)
        {
          Debug.Log("User Rating 3");
          Stars[1].SetActive(true);
          Stars[2].SetActive(true);
          Stars[3].SetActive(true);
          threeStar.SetActive(true);

        }
        if ( user_rating == 4)
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
