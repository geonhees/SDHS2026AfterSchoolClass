using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCommander : CommanderBase
{
    public static int score = 0;
    private BlockSpawner blockSpawner;

    private void Awake()
    {
        Time.timeScale = 1f;
        blockSpawner = FindObjectOfType<BlockSpawner>();
    }

    public void OnBlockFixed(int clearedLines, bool isGameOver)
    {
        AddScore(clearedLines);
        blockSpawner.hasHeldBlock = false;
        if (isGameOver)
        {
            GameOver();
            return;
        }

        blockSpawner.SpawnBlock(-1);
        Debug.Log("Land and spawn new block");
    }
    public void GameOver()
    {
        Managers.Game.setState(GameManager.GameState.Result);
        Time.timeScale = 0f;
    }

    public void AddScore(int lines)
    {
        if (lines == 0) return;

        int[] table = { 0, 100, 300, 500, 800 };
        score += table[lines];

        Debug.Log("Score: " + score);
    }
}
