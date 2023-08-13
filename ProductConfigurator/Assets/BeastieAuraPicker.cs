using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieAuraPicker : MonoBehaviour
{
    [SerializeField]
    private Transform auraParent;
    private GameObject currentAura;
    private BeastieAuraManager auraManager;

    private void Awake()
    {
        auraManager = GetComponentInParent<BeastieAuraManager>();
    }

    public void SetAura(AuraType auraToSet)
    {
        GameObject auraPrefab = auraManager.GetAuraObject(auraToSet);
        if (currentAura != null)
        {
            Destroy(currentAura);
        }
        if (auraPrefab != null)
        {
            currentAura = Instantiate(auraPrefab, auraParent);
        }
        else
        {
            currentAura = null;
        }
    }
}
