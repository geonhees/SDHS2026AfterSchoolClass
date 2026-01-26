using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    void Start()
    {
        SpawnBlock();
    }

    void SpawnBlock()
    {
        int randomIndex = Random.Range(0, blockPrefabs.Length);
        Instantiate(blockPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}
