using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdateController : MonoBehaviour
{
    [SerializeField]
    private StatInfoDisplay statDisplay;
    [SerializeField]
    private DoubloonCostManager costDisplay;
    public virtual void SelectElement(IFieldData newFieldData, IFieldData oldFieldData)
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
}
