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
        currentFieldIndex = fieldData.Length / 2; //start by selecting the middle index
        configureStripUI(currentFieldIndex);
        configureArrowButtons();
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
            BaseSelectorField field = selectorFieldModels[j];
            if (i >= 0 && i < fieldData.Length)
            {
                field.ConfigureElement(fieldData[i]);
                field.HideElement(false);
                if (i == currentFieldIndex)
                {
                    field.SelectElement();
                }
            }
            else
            {
                field.HideElement(true);
            }
            j++;
        }
    }

    private int centerIndex(int rawIndex, int middleIndex)
    {
        return rawIndex + middleIndex;
    }
    
    private void configureArrowButtons()
    {
        VisualElement firstStrip = rootElement.Q("SelectorStrip");
        Button leftArrow = firstStrip.Q<Button>(leftArrowButtonName);
        leftArrow.clicked += () => { inputaction(-1); };
        Button rightArrow = firstStrip.Q<Button>(rightArrowButtonName);
        rightArrow.clicked += () => { inputaction(1); };
    }

    private void inputaction(int direction)
    {
        int newFieldIndex = currentFieldIndex + direction;
        if (newFieldIndex < 0)
        {
            currentFieldIndex = 0;
        }
        else if (newFieldIndex >= fieldData.Length)
        {
            currentFieldIndex = fieldData.Length - 1;
        }
        else
        {
            currentFieldIndex = newFieldIndex;
        }
        configureStripUI(currentFieldIndex);
    }
}
