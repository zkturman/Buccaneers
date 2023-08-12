using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class ColourSelectorStrip : BaseSelectorStrip
{
    [SerializeField]
    private string colourStripName;
    [SerializeField]
    private ColourFieldData[] colourData;
    private Dictionary<ColourType, ColourFieldData> colourDataMap;
    private ColourFieldData[] beastieSpecificData;

    protected override void OnEnable()
    {
        initiateStrip();
        colourDataMap = colourData.ToDictionary(data => data.Colour, data => data);
    }

    public void SetBeastieColours(ColourType[] availableColours)
    {
        if (availableColours != null)
        {
            beastieSpecificData = new ColourFieldData[availableColours.Length];
            for (int i = 0; i < availableColours.Length; i++)
            {
                beastieSpecificData[i] = colourDataMap[availableColours[i]];
            }
        }
        else
        {
            beastieSpecificData = new ColourFieldData[0];
        }
        populateInitialStrip();
    }

    protected override void findRootStripElement()
    {
        rootStripElement = rootElement.Q(colourStripName);
    }

    protected override void createDataList()
    {
        genericFieldData = new List<IFieldData>(beastieSpecificData);
        int middleIndex = getCenterDataIndex();
        genericFieldData.Insert(middleIndex, new ColourFieldData());
    }

    protected override void createModelList()
    {
        selectorFieldModels = new List<ISelectorField>();
        for (int i = 0; i < selectorFieldElements.Count; i++)
        {
            selectorFieldModels.Add(new ColourSelectorField(selectorFieldElements[i]));
        }
    }

    protected override void selectElement(ISelectorField fieldToSelect)
    {
        ColourFieldData newFieldData = getElementData(fieldToSelect) as ColourFieldData;
        uiUpdater.SelectElement(newFieldData, (ColourFieldData)previousField);
        previousField = newFieldData;
    }
}
