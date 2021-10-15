using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected GameManager() { }
    private static GameManager instance = null;
    //delegate method when the game state changes; Ideal for changing scenes
    public event OnStateChangeHandler OnStateChange;
    //getter for the current gamestate
    public GameState gameState { get; private set; }

    //game manager is never destroyed between scenes
    public static GameManager Instance{
        get
        {
            if(GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }
    }

    //sets new gamestate for the instance and calls 
    //the onstatechange method
    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }
}

//Game States
public enum GameState { INTRO, MAIN_MENU }

public delegate void OnStateChangeHandler();
