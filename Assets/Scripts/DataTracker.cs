using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTracker
{
    //This class keeps track of data that needs to be used by multiple scenes

    public static string CurrentLevelName;

    public static IDictionary<string, float> BestTimes = new Dictionary<string, float>(){
        {"LevelOne", 0},
        {"LevelTwo", 0},
        {"LevelThree", 0},
    };

    public static IDictionary<string, float> PrevBestTimes = new Dictionary<string, float>(){
        {"LevelOne", 0},
        {"LevelTwo", 0},
        {"LevelThree", 0},
    };

    //whether a new best was achieved on the current level; used by EndLevelScript to determine the Best and Previous Best texts; set by TimerFunction
    public static bool NewBestBool = false;
}
