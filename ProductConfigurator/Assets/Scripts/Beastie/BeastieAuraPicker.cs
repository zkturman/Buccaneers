using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastieAuraPicker : MonoBehaviour
{
    [SerializeField]
    private Transform auraParent;
    private GameObject currentAura;

    public void SetAura(GameObject auraToSet)
    {
        if (currentAura != null)
        {
            Destroy(currentAura);
        }
        if (auraToSet != null)
        {
            currentAura = Instantiate(auraToSet, auraParent);
        }
        else
        {
            currentAura = null;
        }
    }
}
