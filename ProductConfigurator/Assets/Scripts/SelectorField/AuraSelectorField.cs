using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AuraSelectorField : BaseSelectorField
{
    private AuraFieldData auraData;
    public AuraSelectorField(VisualElement fieldElement) : base(fieldElement) { }

    public override void ConfigureElement(IFieldData auraData)
    {
        this.auraData = auraData as AuraFieldData;
        base.ConfigureElement(auraData);
    }

    protected override void setMainIcon()
    {
        if (CurrentData != null)
        {
            VisualElement mainIcon = currentElement.Q(SelectorFieldClassManager.Classes.MainIconClass);
            mainIcon.style.backgroundImage = new StyleBackground(IconManager.Icons.GetAuraIcon(auraData.Aura));
        }
    }
}
