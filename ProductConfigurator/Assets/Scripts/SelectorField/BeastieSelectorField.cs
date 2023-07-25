using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BeastieSelectorField : BaseSelectorField
{
    private BeastieFieldData beastieData;
    public BeastieSelectorField(VisualElement fieldElement) : base(fieldElement) { }

    public void ConfigureElement(BeastieFieldData beastieData)
    {
        this.beastieData = beastieData;
        base.ConfigureElement(beastieData);
    }

    protected override void setMainIcon()
    {
        if (currentData != null)
        {
            VisualElement mainIcon = currentElement.Q(SelectorFieldClassManager.Classes.MainIconClass);
            mainIcon.style.backgroundImage = new StyleBackground(IconManager.Icons.GetBeastieIcon(beastieData.Type));
        }
    }
}
