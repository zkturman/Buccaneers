using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class BaseSelectorField
{
    private VisualElement fieldElemet;
    private BaseFieldData fieldData;

    public BaseSelectorField(VisualElement fieldElement, BaseFieldData fieldData)
    {
        this.fieldElemet = fieldElement;
        this.fieldData = fieldData;
        fieldElement.Q(fieldData.ClassManager.NameLabelClass).visible = false;
        fieldElemet.Q(fieldData.ClassManager.CostLabelClass).visible = false;
    }
    
    public void HideElement(bool shouldHide)
    {
        fieldElemet.visible = !shouldHide;
    }

    public void SelectElement()
    {

    }
}
