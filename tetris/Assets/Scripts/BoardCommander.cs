using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCommander : CommanderBase
{
    public static int Height = 20;
    public static int Width = 10;

    public static Transform[,] grid = new Transform[Width, Height];

    private InGameCommander inGameC;

    void Awake()
    {
        inGameC = FindObjectOfType<InGameCommander>();    
    }

    Vector2Int WorldToGrid(Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x + Width / 2f);
        int y = Mathf.FloorToInt(pos.y + Height / 2f);
        return new Vector2Int(x, y);
    }

    public void FixBlock(Transform tetromino)
    {
        foreach (Transform block in tetromino)
        {
            Vector2Int p = WorldToGrid(block.position);

            if (p.y >= Height) continue;

            if (p.x < 0 || p.x >= Width || p.y < 0 || p.y >= Height)
            {
                Debug.LogError($"FixBlock OOB: {p}");
                continue;
            }

            grid[p.x, p.y] = block;
        }

        int clearedLines = ClearLines();
        inGameC.OnBlockFixed(clearedLines, IsGameOver());
    }

    public bool IsValidPosition(Transform tetromino, Vector3 dir)
    {
        foreach (Transform block in tetromino)
        {
            Vector3 nextPos = block.position + dir;
            Vector2Int p = WorldToGrid(nextPos);

            if (p.x < 0 || p.x >= Width || p.y < 0)
                return false;

            if (p.y >= Height)
                continue;

            if (grid[p.x, p.y] != null)
                return false;
        }
        return true;
    }

    int ClearLines()
    {
        int cleared = 0;
        for (int y = 0; y < Height; y++)
        {
            if (IsLineFull(y))
            {
                DeleteLine(y);
                MoveDownLines(y + 1);
                y--;
                cleared++;
            }
        }
        return cleared;
    }
    bool IsLineFull(int y)
    {
        for(int x = 0; x < Width; x++)
        {
            if(grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }
    void DeleteLine(int y)
    {
        for(int x = 0; x < Width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }
    void MoveDownLines(int y)
    {
        for(int i = y; i < Height; i++)
        {
            for(int x = 0; x < Width; x++)
            {   
                if (grid[x, i] != null)
                {
                    grid[x, i-1] = grid[x, i];
                    grid[x, i-1].position += Vector3.down;
                    grid[x, i] = null;
                }
            }
        }
    }
    bool IsGameOver()
    {
        for (int x = 0; x < Width; x++)
        {
            if (grid[x, Height - 1] != null)
                return true;
        }
        return false;
    }

}
