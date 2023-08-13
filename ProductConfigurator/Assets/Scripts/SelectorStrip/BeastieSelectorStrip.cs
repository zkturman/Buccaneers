using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BeastieSelectorStrip : BaseSelectorStrip
{
    [SerializeField]
    private string beastieStripName;
    [SerializeField]
    private ColourSelectorStrip colourStrip;
    [SerializeField]
    private AuraSelectorStrip auraStrip;
    [SerializeField]
    private BeastieFieldData[] beastieData;

    protected override void findRootStripElement()
    {
        rootStripElement = rootElement.Q(beastieStripName);
    }
    protected override void createDataList()
    {
        genericFieldData = new List<IFieldData>(beastieData);
        int middleIndex = getCenterDataIndex();
        genericFieldData.Insert(middleIndex, new BeastieFieldData());
    }

    protected override void createModelList()
    {
        selectorFieldModels = new List<ISelectorField>();
        for (int i = 0; i < selectorFieldElements.Count; i++)
        {
            selectorFieldModels.Add(new BeastieSelectorField(selectorFieldElements[i]));
        }
    }

    protected override void selectElement(ISelectorField fieldToSelect)
    {
        BeastieFieldData newFieldData = getElementData(fieldToSelect) as BeastieFieldData;
        uiUpdater.SelectElement(newFieldData, (BeastieFieldData)previousField);
        previousField = newFieldData;
        colourStrip.SetBeastieColours(newFieldData.AvailableColours);
        auraStrip.SetBeastieAura(newFieldData.AvailableAura);
    }
}
