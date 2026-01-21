using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static GameManager Game { get; private set; }
    private ManagerBase[] _managers;

    void Awake()
    {
        _managers = new ManagerBase[]
        {
            Game = GetComponent<GameManager>(),
        };
        foreach (var manager in _managers)
        {
            manager.Initialize();
        }

        Game.setState(GameManager.GameState.Title);

        DontDestroyOnLoad(gameObject);
    }
}
