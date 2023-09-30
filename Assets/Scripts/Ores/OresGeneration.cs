using System.Collections;
using System.Collections.Generic;
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

    IEnumerator Start()
    {
        /*while (true)
        {
            yield return new WaitForSeconds(0.2f);
            PlayerStats.instance.depth += 1;

            if (DrawRock())
                Debug.Log("Cailloux");
            else
                Debug.Log(GetRandomOre().name);
        }*/
        return null;
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
        int playerDepth = PlayerStats.instance.depth;

        for (int i = 0; i < oreDataBase.oreList.Length; i++)
        {
            Ore selectedOre = oreDataBase.oreList[i];
            float temporaryRarityWeight = 0;
            
            if (playerDepth >= selectedOre.depthMin && playerDepth <= selectedOre.depthMax)
            {
                int depthMid = (selectedOre.depthMin + selectedOre.depthMax) / 2;

                if (playerDepth == depthMid)
                {
                    oreRarityWeightDictionary.Add(i, selectedOre.rarityWeight);
                    totalRarityWeight += selectedOre.rarityWeight;
                    continue;
                }
                else if (playerDepth < depthMid)
                {
                    temporaryRarityWeight = selectedOre.rarityWeight *
                                                ((playerDepth - selectedOre.depthMin) /
                                                 (float)(depthMid - selectedOre.depthMin));

                    if (temporaryRarityWeight < 1) temporaryRarityWeight = 1;
                }
                else if (playerDepth > depthMid)
                {
                    temporaryRarityWeight = selectedOre.rarityWeight *
                                            ((playerDepth - depthMid) /
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
