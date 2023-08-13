using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieAuraManager : MonoBehaviour
{
    [SerializeField]
    private BeastieAuraObjectKeyValue[] auraPrefabs;

    public GameObject GetAuraObject(AuraType auraToRetrieve)
    {
        GameObject auraPrefabToRetrieve = null;
        bool isFound = false;
        int i = 0;
        while (!isFound && i < auraPrefabs.Length)
        {
            if (auraPrefabs[i].Key == auraToRetrieve)
            {
                auraPrefabToRetrieve = auraPrefabs[i].Value;
                isFound = true;
            }
            i++;
        }
        return auraPrefabToRetrieve;
    }
}
