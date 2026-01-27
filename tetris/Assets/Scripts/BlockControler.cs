using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float normalFallTime = 1f;
    public float softDropFallTime = 0.05f;

    public float fallTime;
    float prevTime;

    private BoardCommander board;

    private void Awake()
    {
        board = FindObjectOfType<BoardCommander>();
    }

    void Update()
    {
        HandleInput();
        AutoFall();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            fallTime = softDropFallTime;
        }
        else
        {
            fallTime = normalFallTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMove(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMove(Vector3.right);
        }            
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryRotate();
        } 
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            HardDrop();
        }            
    }

    void AutoFall()
    {
        if (Time.time - prevTime >= fallTime)
        {
            if (board.IsValidPosition(gameObject.transform, Vector3.down))
            {
                transform.position += Vector3.down;
            }
            else
            {
                OnLanded();
            }

            prevTime = Time.time;
        }
    }

    void TryMove(Vector3 dir)
    {
        if (board.IsValidPosition(gameObject.transform, dir))
            transform.position += dir;
    }

    void TryRotate()
    {
        transform.Rotate(0, 0, -90);

        if (!board.IsValidPosition(gameObject.transform, Vector3.zero))
            transform.Rotate(0, 0, 90);
    }

    void HardDrop()
    {
        while (board.IsValidPosition(gameObject.transform, Vector3.down))
        {
            transform.position += Vector3.down;
        }

        OnLanded();
    }

    void OnLanded()
    {
        board.FixBlock(transform);
        enabled = false;
    }
}