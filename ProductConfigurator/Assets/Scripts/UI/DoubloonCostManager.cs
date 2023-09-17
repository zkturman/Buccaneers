using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class DoubloonCostManager : MonoBehaviour
{
    public PirateCharacter PirateInfo { get; set; }
    private int currentSpendAmount = 0;
    private Label currentDoubloons;
    private Label currentSpend;
    private VisualElement subtractionLine;
    private Label remainingDoubloons;

    void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        currentDoubloons = rootElement.Q<Label>(DoubloonNameManager.Names.CurrentDoubloonAmountName);
        currentSpend = rootElement.Q<Label>(DoubloonNameManager.Names.CostTotalName);
        subtractionLine = rootElement.Q(DoubloonNameManager.Names.SubtractionLineName);
        remainingDoubloons = rootElement.Q<Label>(DoubloonNameManager.Names.RemaininDoubloonsName);
        updateCurrentDoubloons(PirateInfo.CurrentDoubloons);
        updateCostDisplay();
    }

    private void updateCurrentDoubloons(int amountToDisplay)
    {
        currentDoubloons.text = amountToDisplay.ToString();
    }

    public void UpdateCost(int newCost, int oldCost)
    {
        currentSpendAmount -= oldCost;
        currentSpendAmount += newCost;
        updateCostDisplay();
    }

    private void updateCostDisplay()
    {
        if (currentSpendAmount == 0)
        {
            hideSubtraction(true);
        }
        else
        {
            currentSpend.text = formatSubtractionText(currentSpendAmount);
            int remainingAmount = PirateInfo.CurrentDoubloons - currentSpendAmount;
            remainingDoubloons.text = remainingAmount.ToString();
            hideSubtraction(false);
        }
    }
    
    private void hideSubtraction(bool shouldHide)
    {
        currentSpend.visible = !shouldHide;
        subtractionLine.visible = !shouldHide;
        remainingDoubloons.visible = !shouldHide;
    }

    private string formatSubtractionText(int amountToSubtract)
    {
        return string.Format("- {0}", amountToSubtract);
    }

    
}
