using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public static int Width = 10;
    public static int Height = 20;

    public float normalFallTime = 1f;
    public float softDropFallTime = 0.05f;

    public float fallTime;
    float prevTime;

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
            if (CanMove(Vector3.down))
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
        if (CanMove(dir))
            transform.position += dir;
    }

    void TryRotate()
    {
        transform.Rotate(0, 0, -90);

        if (!CanMove(Vector3.zero))
            transform.Rotate(0, 0, 90);
    }

    bool CanMove(Vector3 dir)
    {
        foreach (Transform block in transform)
        {
            Vector3 nextPos = block.position + dir;

            if (nextPos.x < -4.5f || nextPos.x > 4.5f)
                return false;

            if (nextPos.y < -9.5f)
                return false;
        }
        return true;
    }

    void HardDrop()
    {
        while (CanMove(Vector3.down))
        {
            transform.position += Vector3.down;
        }

        OnLanded();
    }

    void OnLanded()
    {
        enabled = false;
    }
}