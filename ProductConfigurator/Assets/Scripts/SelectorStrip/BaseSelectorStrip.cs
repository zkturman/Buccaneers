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
    protected VisualElement rootStripElement;
    protected List<VisualElement> selectorFieldElements;
    protected List<ISelectorField> selectorFieldModels;
    [SerializeField]
    private BaseFieldData[] fieldData;
    protected List<IFieldData> genericFieldData;
    protected VisualElement rootElement;
    private int currentFieldIndex;

    private void OnEnable()
    {
        rootElement = GetComponent<UIDocument>().rootVisualElement;
        findRootStripElement();
        selectorFieldElements = rootStripElement.Query("SelectorFieldTemplate").ToList();
        createModelList();
        createDataList();
        maxVisibleFields = selectorFieldElements.Count;
        hideAllFields();
        currentFieldIndex = genericFieldData.Count / 2; //start by selecting the middle index
        configureStripUI(currentFieldIndex);
        configureArrowButtons();
    }

    protected virtual void findRootStripElement()
    {
        rootStripElement = rootElement.Q("SelectorStrip");
    }
    protected virtual void createModelList()
    {
        selectorFieldModels = new List<ISelectorField>();
        for (int i = 0; i < selectorFieldElements.Count; i++)
        {
            selectorFieldModels.Add(new BaseSelectorField(selectorFieldElements[i]));
        }
    }

    protected virtual void createDataList()
    {
        genericFieldData = new List<IFieldData>(fieldData);
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
            ISelectorField field = selectorFieldModels[j];
            if (i >= 0 && i < genericFieldData.Count)
            {
                field.ConfigureElement(genericFieldData[i]);
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
        Button leftArrow = rootStripElement.Q<Button>(leftArrowButtonName);
        leftArrow.clicked += () => { inputaction(-1); };
        Button rightArrow = rootStripElement.Q<Button>(rightArrowButtonName);
        rightArrow.clicked += () => { inputaction(1); };
    }

    private void inputaction(int direction)
    {
        int newFieldIndex = currentFieldIndex + direction;
        if (newFieldIndex < 0)
        {
            currentFieldIndex = 0;
        }
        else if (newFieldIndex >= genericFieldData.Count)
        {
            currentFieldIndex = genericFieldData.Count - 1;
        }
        else
        {
            currentFieldIndex = newFieldIndex;
        }
        configureStripUI(currentFieldIndex);
    }
}
