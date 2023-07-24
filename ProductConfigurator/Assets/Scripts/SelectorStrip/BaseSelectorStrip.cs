using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class BaseSelectorStrip : MonoBehaviour
{
    [SerializeField]
    private string leftArrowButtonName = "LeftArrow";
    [SerializeField]
    private string rightArrowButtonName = "RightArrow";
    private int maxVisibleFields;
    private List<VisualElement> selectorFieldElements;
    private List<BaseSelectorField> selectorFieldModels;
    [SerializeField]
    private BaseFieldData[] fieldData;
    private VisualElement rootElement;
    private int currentFieldIndex;

    private void OnEnable()
    {
        rootElement = GetComponent<UIDocument>().rootVisualElement;
        VisualElement firstStrip = rootElement.Q("SelectorStrip");
        selectorFieldElements = firstStrip.Query("SelectorFieldTemplate").ToList();
        selectorFieldModels = new List<BaseSelectorField>();
        for (int i = 0; i < selectorFieldElements.Count; i++)
        {
            selectorFieldModels.Add(new BaseSelectorField(selectorFieldElements[i]));
        }
        maxVisibleFields = selectorFieldElements.Count;
        hideAllFields();
        int middleIndex = fieldData.Length / 2; //start by selecting the middle index
        configureStripUI(middleIndex);
    }

    private void hideAllFields()
    {
        for (int i = 0; i < selectorFieldElements.Count; i++)
        {
            selectorFieldModels[i].HideElement(true);
        }
    }

    private void configureStripUI(int selectedIndex)
    {
        int minimumIndex = (maxVisibleFields / 2) * -1;
        minimumIndex = centerIndex(minimumIndex, selectedIndex);
        int maximumIndex = maxVisibleFields / 2;
        maximumIndex = centerIndex(maximumIndex, selectedIndex);
        int j = 0;  
        for (int i = minimumIndex; i <= maximumIndex; i++)
        {
            if (i >= 0 && i < fieldData.Length)
            {
                BaseSelectorField field = new BaseSelectorField(selectorFieldElements[j]);
                field.ConfigureElement(fieldData[i]);
                field.HideElement(false);
                field.SelectElement();
            }
            j++;
        }
    }

    private int centerIndex(int rawIndex, int middleIndex)
    {
        return rawIndex + middleIndex;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
