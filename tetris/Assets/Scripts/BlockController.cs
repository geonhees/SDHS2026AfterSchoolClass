using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{
    public float normalFallTime = 1f;
    public float softDropFallTime = 0.05f;

    public float fallTime;
    float prevTime;

    public int BlockIndex = -1;
     
    private BoardCommander board;
    private BlockSpawner spawner;

    private void Awake()
    {
        board = FindObjectOfType<BoardCommander>();
        spawner = FindObjectOfType<BlockSpawner>();
        fallTime = normalFallTime;
    }

    void Update()
    {
        //HandleInput();
        AutoFall();
    }

    //void HandleInput()
    //{
    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        fallTime = softDropFallTime;
    //    }
    //    else
    //    {
    //        fallTime = normalFallTime;
    //    }
    //    if (leftButton)
    //    {
    //        TryMove(Vector3.left);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        TryMove(Vector3.right);
    //    }            
    //    else if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        TryRotate();
    //    } 
    //    else if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        HardDrop();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        spawner.Holding(this);
    //    }
    //}
    public void MoveLeft()
    {
        TryMove(Vector3.left);
    }

    public void MoveRight()
    {
        TryMove(Vector3.right);
    }

    public void Rotate()
    {
        TryRotate();
    }

    public void Hold(BlockController currentBlock)
    {
        spawner.Holding(currentBlock);
    }
    void AutoFall()
    {
        if (Time.time - prevTime >= fallTime)
        {
            if (board.IsValidPosition(transform, Vector3.down))
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

    public void HardDrop()
    {
        while (board.IsValidPosition(gameObject.transform, Vector3.down))
        {
            transform.position += Vector3.down;
        }

        OnLanded();
    }

    void OnLanded()
    {
        Debug.Log("Block Landed" + gameObject.name);
        board.FixBlock(transform);
        spawner.hasHeldBlock = false;
        enabled = false;
    }
}