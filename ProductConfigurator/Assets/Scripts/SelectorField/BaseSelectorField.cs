using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UIElements;
public class BaseSelectorField
{
    protected VisualElement currentElement;
    protected BaseFieldData currentData;
    private readonly string COST_PREFIX = "Cost";

    public BaseSelectorField(VisualElement fieldElement)
    {
        this.currentElement = fieldElement;
        hideName(true);
        hideCost(true);
    }

    public void ConfigureElement(BaseFieldData fieldData)
    {
        currentData = fieldData;
        setName();
        setCostValue();
        setMainIcon();
        setEffectIcon();
        setStatBonus();
    }

    private void hideName(bool shouldHide)
    {
        if (currentElement != null)
        {
            string nameLabel = SelectorFieldClassManager.Classes.NameLabelClass;
            hideElementByName(nameLabel, shouldHide);
        }
    }

    private void hideCost(bool shouldHide)
    {
        if (currentElement != null)
        {
            string costField = SelectorFieldClassManager.Classes.CostLabelClass;
            hideElementByName(costField, shouldHide);
        }
    }

    private void hideElementByName(string elementName, bool shouldHide)
    {
        if (currentElement != null)
        {
            currentElement.Q(elementName).visible = !shouldHide;
        }
    }

    protected virtual void setMainIcon()
    {
        if (currentElement != null)
        {
            VisualElement mainIcon = currentElement.Q(SelectorFieldClassManager.Classes.MainIconClass);
            mainIcon.style.backgroundImage = new StyleBackground(IconManager.Icons.GetDefaultIcon());
        }
    }

    private void setEffectIcon()
    {
        if (currentData != null)
        {
            VisualElement effectIcon = currentElement.Q(SelectorFieldClassManager.Classes.EffectIconClass);
            if (currentData.EffectType != SpecialEffectType.None)
            {
                effectIcon.style.backgroundImage = new StyleBackground(IconManager.Icons.GetEffectIcon(currentData.EffectType));
            }
            else
            {
                effectIcon.style.backgroundImage = new StyleBackground();
            }
        }
    }

    private void setStatBonus()
    {
        if (currentData != null)
        {
            VisualElement statIcon = currentElement.Q(SelectorFieldClassManager.Classes.StatBonusIconClass);
            Label statLabel = currentElement.Q<Label>(SelectorFieldClassManager.Classes.StatBonusValueClass);
            if (currentData.BonusStat != StatType.None)
            {
                statIcon.style.backgroundImage = new StyleBackground(IconManager.Icons.GetStatIcon(currentData.BonusStat));
                statLabel.text = currentData.BonusStatValue.ToString();
            }
            else
            {
                statIcon.style.backgroundImage = new StyleBackground();
                statLabel.text = string.Empty;
            }
        }
    }

    private void setName()
    {
        if (currentData != null)
        {
            string fieldName = SelectorFieldClassManager.Classes.NameLabelClass;
            string elementName = currentData.Name;
            setLabel(fieldName, elementName);
        }
    }

    private void setCostValue()
    {
        if (currentData != null)
        {
            string valueName = SelectorFieldClassManager.Classes.CostLabelClass;
            StringBuilder builder = new StringBuilder();
            builder.Append(COST_PREFIX);
            builder.Append(": ");
            builder.Append(currentData.Cost.ToString());
            setLabel(valueName, builder.ToString());
        }
    }

    private void setLabel(string labelName, string labelText)
    {
        if (currentElement != null)
        {
            currentElement.Q<Label>(labelName).text = labelText;
        }
    }

    public void HideElement(bool shouldHide)
    {
        if (currentElement != null)
        {
            currentElement.visible = !shouldHide;
            hideName(true);
            hideCost(true);
        }
    }

    public void SelectElement()
    {
        hideName(false);
        hideCost(false);
    }
}
