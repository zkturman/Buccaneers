using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectorField
{
    public void ConfigureElement(IFieldData fieldData);

    public void HideElement(bool shouldHide);
    public void SelectElement();
}
