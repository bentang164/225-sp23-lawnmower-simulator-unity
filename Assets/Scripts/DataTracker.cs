using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTracker
{
    public static string CurrentLevelName { get; set; }

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

    public static bool NewBestBool = false;
}
