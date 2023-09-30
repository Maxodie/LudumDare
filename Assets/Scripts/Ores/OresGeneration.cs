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
            yield return new WaitForSeconds(.5f);
            PlayerStats.instance.depth += 2;
            Debug.LogWarning("PROFONDEUR : " + PlayerStats.instance.depth);

            GetRandomOre();
            /*if (GetRock())
                Debug.LogWarning("CAILLOUX");
            else
                GetRandomOre();#1#
            //Debug.Log(GetRandomOre().name);
        }*/
        yield return null;
    }

    // Return true if create rock
    bool GetRock()
    {
        float result = Random.Range(0f, 1f);
        return result <= rockApparitionPercentage;
    }

    Ore GetRandomOre()
    {
        // IDictionary<oreDataBaseId, rarityweight>
        IDictionary<int, int> oreRarityWeight = new Dictionary<int, int>();
        int totalRarityWeight = 0;
        int playerDepth = PlayerStats.instance.depth;

        for (int i = 0; i < oreDataBase.oreList.Length; i++)
        {
            Ore selectedOre = oreDataBase.oreList[i];
            var temporaryRarityWeight = 0;
            
            if (playerDepth >= selectedOre.depthMin && playerDepth <= selectedOre.depthMax)
            {
                int depthMid = (selectedOre.depthMin + selectedOre.depthMax) / 2;

                if (playerDepth == depthMid)
                {
                    oreRarityWeight.Add(i, selectedOre.rarityWeight);
                    totalRarityWeight += selectedOre.rarityWeight;
                }
                else if (playerDepth < depthMid)
                {
                    temporaryRarityWeight = selectedOre.rarityWeight *
                                                ((playerDepth - selectedOre.depthMin) /
                                                 (depthMid - selectedOre.depthMin));
                }
                else if (playerDepth > depthMid)
                {
                    temporaryRarityWeight = selectedOre.rarityWeight *
                                                ((playerDepth - depthMid) /
                                                 (selectedOre.depthMax - depthMid));
                }

                temporaryRarityWeight++;
                Debug.Log(selectedOre.name + " : " + temporaryRarityWeight);
                oreRarityWeight.Add(i, temporaryRarityWeight);
                totalRarityWeight += selectedOre.rarityWeight;
            }
        }
        
        Debug.Log("TOTAL WEIGHT : " + totalRarityWeight);
        return null;
    }

    /*Ore GetRandomOre()
    {
        List<Ore> availableOres = new List<Ore>();
        List<int> oreRarityWeights = new List<int>();
        int totalRarityWeight = 0;

        // Get every ores that can be found at different depths
        foreach (var selectedOre in oreDataBase.oreList)
        {
            if (PlayerStats.instance.depth >= selectedOre.depthMin)
            {
                // Adjust rarity weight according to min and max depth
                var temporaryRarityWeight = selectedOre.rarityWeight;
                temporaryRarityWeight -= PlayerStats.instance.depth - selectedOre.depthMax;

                if (selectedOre.tempRarityWeight > 0)
                {
                    Debug.Log(selectedOre.name + " : " + selectedOre.tempRarityWeight);
                    oreRarityWeights.Add(selectedOre);
                    totalRarityWeight += selectedOre.tempRarityWeight;
                }
                else 
                    oreRarityWeights.Add(0);
            }
            else
                oreRarityWeights.Add(0);
        }
        
        List<Ore> oreListWithWeight = new List<Ore>();
        for (int i = 0; i < availableOres.Count; i++)
        {
            for (int j = 0; j < availableOres[i].tempRarityWeight; j++)
            {
                oreListWithWeight.Add(availableOres[i]);
            }
        }
        
        int randomInt = Random.Range(0, totalRarityWeight);

        return oreListWithWeight[randomInt];
    }*/
}
