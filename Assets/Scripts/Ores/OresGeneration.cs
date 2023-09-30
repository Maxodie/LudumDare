using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class OresGeneration : MonoBehaviour
{
    [SerializeField] OreDataBase oreDataBase;

    [SerializeField] [Range(0.0f,1.0f)] float rockApparitionPercentage;

    void Awake()
    {
        oreDataBase = GetComponent<OreDataBase>();
    }

    void Start()
    {
        foreach (var ore in oreDataBase.oreList)
        {
            Debug.Log(ore.name);
        }
    }

    /*void Update()
    {
        Debug.Log(GetRock());
        
        if (GetRock())
            Debug.Log("CAILLOUX");
        else
            Debug.Log(GetRandomOre().name);
    }*/

    // Return true if create rock
    bool GetRock()
    {
        float result = Random.Range(0f, 1f);
        return result <= rockApparitionPercentage;
    }

    public Ore GetRandomOre()
    {
        return null;
    }
}
