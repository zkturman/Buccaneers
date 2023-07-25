using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestFieldPopulator : MonoBehaviour
{
    [SerializeField]
    private bool isBeastie = false;
    [SerializeField]
    private BaseFieldData baseFieldData;
    [SerializeField]
    private BeastieFieldData beastieData;
    [SerializeField]
    private SelectorFieldClassManager selectorFieldClassManager;
    private void OnEnable() 
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        VisualElement selectorField = rootElement.Q("SelectorFieldTemplate");
        if (isBeastie)
        {
            configureBeastieField(selectorField);
        }
        else
        {
            configureBaseField(selectorField);
        }
    }

    private void configureBeastieField(VisualElement fieldToConfigure)
    {
        BeastieSelectorField testField = new BeastieSelectorField(fieldToConfigure);
        selectField(testField);
        testField.ConfigureElement(beastieData);
    }

    private void configureBaseField(VisualElement fieldToConfigure)
    {
        BaseSelectorField testField = new BaseSelectorField(fieldToConfigure);
        selectField(testField);
        testField.ConfigureElement(baseFieldData);
    }

    private void selectField(BaseSelectorField fieldForData)
    {
        fieldForData.SelectElement();
    }
}
