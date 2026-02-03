using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCommander : CommanderBase
{
    int score = 0;
    BlockSpawner blockSpawner;

    private void Awake()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
    }

    public void OnBlockFixed(int clearedLines, bool isGameOver)
    {
        AddScore(clearedLines);

        if (isGameOver)
        {
            GameOver();
            return;
        }

        blockSpawner.SpawnBlock(-1);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
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
