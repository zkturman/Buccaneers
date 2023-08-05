using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BeastieSelectorStrip : BaseSelectorStrip
{
    [SerializeField]
    private string beastieStripName;
    [SerializeField]
    private BeastieFieldData[] beastieData;

    protected override void findRootStripElement()
    {
        rootStripElement = rootElement.Q(beastieStripName);
    }
    protected override void createDataList()
    {
        genericFieldData = new List<IFieldData>(beastieData);
    }

    protected override void createModelList()
    {
        selectorFieldModels = new List<ISelectorField>();
        for (int i = 0; i < selectorFieldElements.Count; i++)
        {
            selectorFieldModels.Add(new BeastieSelectorField(selectorFieldElements[i]));
        }
    }
}
