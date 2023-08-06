using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BeastieSelectorField : BaseSelectorField
{
    private BeastieFieldData beastieData;
    public BeastieSelectorField(VisualElement fieldElement) : base(fieldElement) { }

    public override void ConfigureElement(IFieldData beastieData)
    {
        this.beastieData = beastieData as BeastieFieldData;
        base.ConfigureElement(beastieData);
    }

    protected override void setMainIcon()
    {
        if (CurrentData != null)
        {
            VisualElement mainIcon = currentElement.Q(SelectorFieldClassManager.Classes.MainIconClass);
            mainIcon.style.backgroundImage = new StyleBackground(IconManager.Icons.GetBeastieIcon(beastieData.Type));
        }
    }

    public override IFieldData SelectElement()
    {
        base.SelectElement();
        return beastieData;  
    }
}
