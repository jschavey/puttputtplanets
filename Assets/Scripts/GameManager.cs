using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Singleton class that manages the general state of the game
/// Not a script, but it is self-updating once initialized
/// </summary>
class GameManager
{
    #region Fields

    static GameManager instance;

    #endregion

    #region Constructor

    /// <summary>
    /// Private constructor
    /// </summary>
    private GameManager()
    {
        // Creates the object that calls GM's Update method
        UnityEngine.Object.DontDestroyOnLoad(new GameObject("gmUpdater", typeof(Updater)));
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the singleton instance of the game manager
    /// </summary>
    public static GameManager Instance
    {
        get { return instance ?? (instance = new GameManager()); }

        // This is shorthand for:
        // get
        // {
        // 		if (instance == null)
        //		{
        //			instance = new GameManager();
        //		}
        //		return instance;
        // }

        // Allows anything in the game to access the GM with GameManager.Instance.whatever
    }

    #endregion

    private void Update()
    {
        //event testing test code
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    EventManager.Instance.RegisterToEvent(EventType.PlayerDeath, TriggerWhenPlayerDies);
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    EventManager.Instance.RegisterToEvent(EventType.PlayerDeath, AlsoTriggerWhenPlayerDies);
        //}
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    EventManager.Instance.UnregisterFromEvent(EventType.PlayerDeath, TriggerWhenPlayerDies);
        //}
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    EventManager.Instance.FireEvent(EventType.PlayerDeath);
        //}

        //restart the scene hotkey
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    #region Public methods

    /// <summary>
    /// Loads the next scene
    /// </summary>
    /// <param name="name">Select the scene name you want to go to. If you need to add a scene it is in Constants.cs under SCENE_STRINGS</param>
    public void LoadScene(SceneName name)
    {
        SceneManager.LoadScene(Constants.SCENE_STRINGS[name]);
    }

    /// <summary>
    /// Internal class that updates the game manager
    /// </summary>
    class Updater : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            Instance.Update();
        }
    }

    #endregion
}
