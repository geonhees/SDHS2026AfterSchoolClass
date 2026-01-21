using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCommander : CommanderBase
{
    [SerializeField]
    private CommanderChildBase[] _childCommanders;

    private void Awake()
    {
        foreach(var child in _childCommanders)
        {
            child.Initialize(this);
        }
    }

    public void StartGame()
    {
        Managers.Game.setState(GameManager.GameState.InGame);
    }
}
