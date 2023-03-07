using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SplitterDetails
{
    public string level, splitterColor, ballColor, splitter_id;
    public DateTime collisionTime;
 
    public SplitterDetails(string level,DateTime dateTime,string splitterColor,string ballColor,string splitter_id)
    {
        this.level = level;
        this.collisionTime = dateTime;
        this.splitterColor = splitterColor;
        this.ballColor = ballColor;
        this.splitter_id = splitter_id;
    }
}
