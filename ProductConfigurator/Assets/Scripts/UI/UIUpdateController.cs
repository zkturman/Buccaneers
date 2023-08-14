using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdateController : MonoBehaviour
{
    [SerializeField]
    private StatInfoDisplay statDisplay;
    [SerializeField]
    private DoubloonCostManager costDisplay;
    [SerializeField]
    private BeastieModelPicker[] beastiePickers;
    
    public void SelectElement(IFieldData newFieldData, IFieldData oldFieldData)
    {
        StatData newBonus = new StatData(newFieldData.BonusStat, newFieldData.BonusStatValue);
        SpecialEffectType newType = newFieldData.EffectType;
        int newCost = newFieldData.Cost;
        StatData oldBonus;
        SpecialEffectType oldType;
        int oldCost;
        if (oldFieldData == null)
        {
            oldBonus = new StatData();
            oldType = SpecialEffectType.None;
            oldCost = 0;
        }
        else
        {
            oldBonus = new StatData(oldFieldData.BonusStat, oldFieldData.BonusStatValue);
            oldType = oldFieldData.EffectType;
            oldCost = oldFieldData.Cost;
        }
        statDisplay.AddStatBonus(newBonus, oldBonus);
        statDisplay.AddSpecialEffect(newType, oldType);
        costDisplay.UpdateCost(newCost, oldCost);
    }

    public void SelectElement(BeastieFieldData newFieldData, BeastieFieldData oldFieldData)
    {
        SelectElement((IFieldData)newFieldData, (IFieldData)oldFieldData);
        for (int i = 0; i < beastiePickers.Length; i++)
        {
            beastiePickers[i].SelectModel(newFieldData.Type);
        }
    }

    public void SelectElement(ColourFieldData newFieldData, ColourFieldData oldFieldData)
    {
        SelectElement((IFieldData)newFieldData, (IFieldData)oldFieldData);
        for (int i = 0; i < beastiePickers.Length; i++)
        {
            beastiePickers[i].SetColour(newFieldData.Colour);
        }
    }

    public void SelectElement(AuraFieldData newFieldData, AuraFieldData oldFieldData)
    {
        SelectElement((IFieldData)newFieldData, (IFieldData)oldFieldData);
        for (int i = 0; i < beastiePickers.Length; i++)
        {
            beastiePickers[i].SetAura(newFieldData.Aura);
        }
    }
}
