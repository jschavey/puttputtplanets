using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Constants
{
    #region Fields

    //global constants


    //player constants


    //UI constants


    //The dictionary that gives the proper string for each SceneName enum
    public static readonly Dictionary<SceneName, string> SCENE_STRINGS = new Dictionary<SceneName, string>
    {
        { SceneName.MainMenu, "MainMenu" },
        { SceneName.HowToPlay, "HowToPlay" },
        { SceneName.LevelOne, "LevelOne" },
        { SceneName.PlayerVictory, "PlayerVictory" },
        { SceneName.PlayerDefeat, "PlayerDefeat" }
    };

    #endregion
}