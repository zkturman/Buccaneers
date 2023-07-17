using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestFieldPopulator : MonoBehaviour
{
    [SerializeField]
    private BaseFieldData testData;
    [SerializeField]
    private SelectorFieldClassManager selectorFieldClassManager;
    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        VisualElement selectorField = rootElement.Q("SelectorFieldTemplate");
        testData.ClassManager = selectorFieldClassManager;
        BaseSelectorField testField = new BaseSelectorField(selectorField, testData);
    }
}
