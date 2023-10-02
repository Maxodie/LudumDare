using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class OresGeneration : MonoBehaviour
{
    OreDataBase oreDataBase;
    [SerializeField] Ore stoneObjectRef;

    [SerializeField] [Range(0.0f,1.0f)] float rockApparitionPercentage;

    void Awake()
    {
        oreDataBase = GetComponent<OreDataBase>();
    }

    public Ore DrawRandomOre()
    {
        if (DrawRock())
            return stoneObjectRef;
        else
            return GetRandomOre();
    }

    // Return true if create rock
    bool DrawRock()
    {
        float result = Random.Range(0f, 1f);
        return result <= rockApparitionPercentage;
    }

    Ore GetRandomOre()
    {
        // Get ore rarity weight
        // IDictionary<oreDataBaseId, rarityWeight>
        IDictionary<int, int> oreRarityWeightDictionary = new Dictionary<int, int>();
        int totalRarityWeight = 0;
        //int playerDepth = PlayerStats.instance.depth;

        for (int i = 0; i < oreDataBase.oreList.Length; i++)
        {
            Ore selectedOre = oreDataBase.oreList[i];
            float temporaryRarityWeight = 0;
            
            if (PlayerStats.instance.depth >= selectedOre.depthMin && PlayerStats.instance.depth <= selectedOre.depthMax)
            {
                int depthMid = (selectedOre.depthMin + selectedOre.depthMax) / 2;

                if (PlayerStats.instance.depth == depthMid)
                {
                    oreRarityWeightDictionary.Add(i, selectedOre.rarityWeight);
                    totalRarityWeight += selectedOre.rarityWeight;
                    continue;
                }
                else if (PlayerStats.instance.depth < depthMid)
                {
                    temporaryRarityWeight = selectedOre.rarityWeight *
                                                ((PlayerStats.instance.depth - selectedOre.depthMin) /
                                                 (float)(depthMid - selectedOre.depthMin));

                    if (temporaryRarityWeight < 1) temporaryRarityWeight = 1;
                }
                else if (PlayerStats.instance.depth > depthMid)
                {
                    temporaryRarityWeight = selectedOre.rarityWeight *
                                            ((PlayerStats.instance.depth - depthMid) /
                                             (float)(selectedOre.depthMax - depthMid));
                    
                    if (temporaryRarityWeight < 1) temporaryRarityWeight = 1;
                }

                temporaryRarityWeight = Mathf.Round(temporaryRarityWeight);
                
                //Debug.Log(oreDataBase.oreList[i].name + " : " + i);

                oreRarityWeightDictionary.Add(i, (int)temporaryRarityWeight);
                totalRarityWeight += (int)temporaryRarityWeight;
            }
        }
        
        return oreDataBase.oreList[drawRandomOreID(oreRarityWeightDictionary, totalRarityWeight)];
    }

    int drawRandomOreID(IDictionary<int, int> oreDictionary, int totalRarityWeight)
    {
        List<int> oreIdArray = new List<int>();
        int randomInt = Random.Range(0, totalRarityWeight);

        foreach (KeyValuePair<int, int> entry in oreDictionary)
        {
            for (int i = 0; i < entry.Value; i++)
            {
                oreIdArray.Add(entry.Key);
            }
        }
        
        return oreIdArray[randomInt];
    }
}
