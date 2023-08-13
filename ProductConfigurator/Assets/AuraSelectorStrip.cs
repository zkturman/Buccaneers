using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class AuraSelectorStrip : BaseSelectorStrip
{
    [SerializeField]
    private string auraStripName;
    [SerializeField]
    private AuraFieldData[] auraData;
    private Dictionary<AuraType, AuraFieldData> auraDataMap;
    private AuraFieldData[] beastieSpecificData;
    private bool isInitiated = false;

    protected override void OnEnable()
    {
        tryInitiateStrip();
        auraDataMap = auraData.ToDictionary(data => data.Aura, data => data);
    }

    private void tryInitiateStrip()
    {
        if (!isInitiated)
        {
            initiateStrip();
            isInitiated = true;
        }
    }

    public void SetBeastieAura(AuraType[] availableAura)
    {
        tryInitiateStrip();
        if (availableAura != null)
        {
            beastieSpecificData = new AuraFieldData[availableAura.Length];
            for (int i = 0; i < availableAura.Length; i++)
            {
                beastieSpecificData[i] = auraDataMap[availableAura[i]];
            }
        }
        else
        {
            beastieSpecificData = new AuraFieldData[0];
        }
        populateInitialStrip();
    }

    protected override void findRootStripElement()
    {
        rootStripElement = rootElement.Q(auraStripName);
    }

    protected override void createDataList()
    {
        genericFieldData = new List<IFieldData>(beastieSpecificData);
        int middleIndex = getCenterDataIndex();
        genericFieldData.Insert(middleIndex, new AuraFieldData());
    }

    protected override void createModelList()
    {
        selectorFieldModels = new List<ISelectorField>();
        for (int i = 0; i < selectorFieldElements.Count; i++)
        {
            selectorFieldModels.Add(new AuraSelectorField(selectorFieldElements[i]));
        }
    }

    protected override void selectElement(ISelectorField fieldToSelect)
    {
        AuraFieldData newFieldData = getElementData(fieldToSelect) as AuraFieldData;
        uiUpdater.SelectElement(newFieldData, (AuraFieldData)previousField);
        previousField = newFieldData;
    }
}
