using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class BaseSelectorStrip : MonoBehaviour
{
    [SerializeField]
    private int numberOfFields = 1;
    [SerializeField]
    private string leftArrowButtonName = "LeftArrow";
    [SerializeField]
    private string rightArrowButtonName = "RightArrow";
    private int maxVisibleFields;
    private List<VisualElement> selectorFieldsElements;
    private List<BaseSelectorField> selectorFields2;
    private VisualElement rootElement;
    private int currentFieldIndex;

    private void OnEnable()
    {
        rootElement = GetComponent<UIDocument>().rootVisualElement;
        VisualElement firstStrip = rootElement.Q("SelectorStrip");
        selectorFieldsElements = firstStrip.Query("SelectorFieldTemplate").ToList();
        maxVisibleFields = selectorFieldsElements.Count;
        hideAllFields();
        int middleIndex = numberOfFields / 2; //start by selecting the middle index
        configureStripUI(middleIndex);
    }

    private void hideAllFields()
    {
        for (int i = 0; i < selectorFieldsElements.Count; i++)
        {
            selectorFieldsElements[i].visible = false;
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
            if (i >= 0 && i < numberOfFields)
            {
                selectorFieldsElements[j].visible = true;
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
