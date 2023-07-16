using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class BaseSelectorField
{
    private VisualElement fieldElemet;
    
    public BaseSelectorField(VisualElement fieldElement)
    {

    }
    
    public void HideElement(bool shouldHide)
    {
        fieldElemet.visible = !shouldHide;
    }

    public void SelectElement()
    {

    }
}
