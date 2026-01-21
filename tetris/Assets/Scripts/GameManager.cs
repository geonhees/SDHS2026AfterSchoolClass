using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : ManagerBase
{
    public enum GameState
    {
        Loading,
        Title,
        InGame,
        Result
    }

    private GameState _currentState = GameState.Loading;

    public void setState(GameState newState)
    {
        _currentState = newState;
        SceneManager.LoadScene(newState.ToString());
    }

    public override void Initialize()
    {
        base.Initialize();
    }
}
