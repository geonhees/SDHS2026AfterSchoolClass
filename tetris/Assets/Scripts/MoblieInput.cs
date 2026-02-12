using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public BlockSpawner spawner;

    public void MoveLeft()
    {
        if (spawner.currentBlock != null)
            spawner.currentBlock.MoveLeft();
    }

    public void MoveRight()
    {
        if (spawner.currentBlock != null)
            spawner.currentBlock.MoveRight();
    }

    public void Rotate()
    {
        if (spawner.currentBlock != null)
            spawner.currentBlock.Rotate();
    }

    public void Hold()
    {
        if (spawner.currentBlock != null)
            spawner.currentBlock.Hold(spawner.currentBlock);
    }
    public void HardDrop()
    {
        if (spawner.currentBlock != null)
            spawner.currentBlock.HardDrop();
    }
}
