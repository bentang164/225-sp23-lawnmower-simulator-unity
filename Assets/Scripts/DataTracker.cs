using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTracker
{
    public static string CurrentLevelName { get; set; }

    public static float LevelOnePrevBestTime = 0;
    public static float LevelTwoPrevBestTime = 0;

    public static float LevelOneBestTime = 0;
    public static float LevelTwoBestTime = 0;

    public static bool NewBestBool = false;
}
