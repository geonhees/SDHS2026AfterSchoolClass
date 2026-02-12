using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    public int holdingBlockIndex = -1;
    public bool hasHeldBlock = false;

    public BlockController currentBlock;

    void Start()
    {
        SpawnBlock(-1);
    }

    public void SpawnBlock(int index)
    {
        if(index == -1)
        {
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject obj = Instantiate(blockPrefabs[randomIndex], transform.position, Quaternion.identity);

            obj.GetComponent<BlockController>().BlockIndex = randomIndex;
            currentBlock = obj.GetComponent<BlockController>();
        }
        else
        {
            GameObject obj = Instantiate(blockPrefabs[index], transform.position, Quaternion.identity);

            obj.GetComponent<BlockController>().BlockIndex = index;
            currentBlock = obj.GetComponent<BlockController>();
        }
    }
    public void Holding(BlockController current)
    {
        if (hasHeldBlock) return;

        int currentIndex = current.BlockIndex;

        if (holdingBlockIndex == -1)
        {
            holdingBlockIndex = currentIndex;
            Debug.Log("Hold and Spawn");
            SpawnBlock(-1);
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
