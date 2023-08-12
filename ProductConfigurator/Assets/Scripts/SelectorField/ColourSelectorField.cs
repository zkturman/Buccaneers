using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColourSelectorField : BaseSelectorField
{
    private ColourFieldData colourData;
    public ColourSelectorField(VisualElement fieldElement) : base(fieldElement){ }

    public override void ConfigureElement(IFieldData colourData)
    {
        this.colourData = colourData as ColourFieldData;
        base.ConfigureElement(colourData);
    }

    protected override void setMainIcon()
    {
        if (CurrentData != null)
        {
            VisualElement mainIcon = currentElement.Q(SelectorFieldClassManager.Classes.MainIconClass);
            mainIcon.style.backgroundImage = new StyleBackground(IconManager.Icons.GetColourIcon(colourData.Colour));
        }
    }
}
