using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    public int holdingBlockIndex = -1;
    public bool hasHeldBlock = false;
    private bool holdingBlock = false;

    void Start()
    {
        SpawnBlock(-1);
    }

    public void SpawnBlock(int index)
    {
        GameObject obj;
        if (holdingBlock)
        {
            obj = Instantiate(blockPrefabs[index], transform.position, Quaternion.identity);

            obj.GetComponent<BlockController>().BlockIndex = index;
            return;
        }
        index = Random.Range(0, blockPrefabs.Length);
        obj = Instantiate(blockPrefabs[index], transform.position, Quaternion.identity);

        obj.GetComponent<BlockController>().BlockIndex = index;
    }
    public void Holding(BlockController current)
    {
        if (hasHeldBlock) return;

        int currentIndex = current.BlockIndex;

        if (holdingBlockIndex == -1)
        {
            holdingBlockIndex = currentIndex;
            SpawnBlock(-1);
            holdingBlock = true;
        }
        else
        {
            SpawnBlock(holdingBlockIndex);
            holdingBlockIndex = currentIndex;
        }
        hasHeldBlock = true;
        Destroy(current.gameObject);
    }
}
