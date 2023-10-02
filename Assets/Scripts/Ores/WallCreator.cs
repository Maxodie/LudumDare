using System;
using Unity.Mathematics;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    OresGeneration oreGenerator;
    [SerializeField] GameObject blockPrefab;

    GameObject previousCreatedBlock;
    float columnNumber = 0;
    int blockInColumn = 0;

    [SerializeField] int maxWallHeight;
    [SerializeField] int wallNumberAtStart;

    void Awake()
    {
        oreGenerator = GetComponent<OresGeneration>();
    }

    public void StartGeneration() {
        CreateWalls(wallNumberAtStart);
    }

    void CreateWalls(int size)
    {
        for (int i = 0; i < size; i++)
        {
            CreateWall(i == 0);
        }
    }
    
    public void CreateWall(bool isFirstWall = false)
    {
        blockInColumn = 0;
        var (newBlock, newBlockData) = CreateBlock();
        newBlock.transform.localPosition = Vector3.right * columnNumber + Vector3.up * 0.5f;
        previousCreatedBlock = newBlock;

        if (isFirstWall)
        {
            newBlock.GetComponent<SpriteRenderer>().sprite = newBlockData.objectData.damagedBorder;
        }

        for (int i = 0; i < maxWallHeight - 1; i++)
        {
            (newBlock, newBlockData) = CreateBlock();

            if (isFirstWall)
            {
                newBlock.GetComponent<SpriteRenderer>().sprite = newBlockData.objectData.damagedBorder;
            }


            // Change blocBelow to the new bloc
            newBlockData.blockBelow = previousCreatedBlock;
            
            // Add to column
            blockInColumn++;
            newBlock.transform.localPosition += Vector3.right * columnNumber + Vector3.up * blockInColumn + Vector3.up * 0.5f;

            previousCreatedBlock = newBlock;
        }

        columnNumber++;
        PlayerStats.instance.depth++;
    }

    (GameObject, ObjectData) CreateBlock()
    {
        GameObject newBlock = Instantiate(blockPrefab, transform.position, quaternion.identity);
        newBlock.transform.SetParent(transform);
        ObjectData newBlockData = newBlock.GetComponent<ObjectData>();
        
        // Set type of block
        newBlockData.LoadObjectData(oreGenerator.DrawRandomOre());

        return (newBlock, newBlockData);
    }

    public void ResetWall()
    {
        columnNumber = 0;
        blockInColumn = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
