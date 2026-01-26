using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControler : MonoBehaviour
{ 
    float fallTime = 1f;
    float prevTime;

    void Update()
    {
        HandleInput();
        AutoFall();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
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
            if (CanMoveDown())
            {
                transform.position += Vector3.down;
                prevTime = Time.time;
            }
        }
    }
    bool CanMoveDown()
    {
        foreach (Transform block in transform)
        {
            if (block.position.y <= -9.5f)
            {
                return false;
            }
        }
        return true;
    }


    void HardDrop()
    {
        while (CanMoveDown())
        {
            transform.position += Vector3.down;
        }
        prevTime = Time.time;
    }
}
    