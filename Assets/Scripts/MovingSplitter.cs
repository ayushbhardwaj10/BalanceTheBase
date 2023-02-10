using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSplitter : MonoBehaviour
{
    Transform waypoint1 , waypoint2;
    [SerializeField] private float speed = 2f;
    Vector3 current_target;
   


    //private void FixedUpdate()
    //{
    //    var step = speed * Time.deltaTime;
    //    if(transform.position == waypoint1.position)
    //    {
    //        current_target = waypoint2.position;
    //    }
    //    else if(transform.position == waypoint2.position)
    //    {
    //        current_target = waypoint1.position;

    //    }
    //    transform.position = Vector3.MoveTowards(transform.position, current_target, step);

    //}

    //private void Update()
    //{
    //    if (Vector2.Distance(wayPoints[curWayPointIndex].transform.position,transform.position) < .15f)
    //    {
    //        curWayPointIndex++;
    //        if(curWayPointIndex >= wayPoints.Length)
    //        {
    //            curWayPointIndex = 0;
    //        }
    //    }
    //    transform.position = Vector2.MoveTowards(transform.position, wayPoints[curWayPointIndex].transform.position, speed * Time.deltaTime);
    //}

}
