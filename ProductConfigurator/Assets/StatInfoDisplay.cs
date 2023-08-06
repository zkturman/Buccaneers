using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatInfoDisplay : MonoBehaviour
{
    [SerializeField]
    private PirateCharacter pirateInfo;
    private StatData bonusStats;
    private Label healthValue;
    private Label healthBonus;
    private Label speedValue;
    private Label speedBonus;
    private Label attackValue;
    private Label attackBonus;
    private Label rangeValue;
    private Label rangeBonus;
    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        StatInfoNameManager nameInfo = StatInfoNameManager.Names;
        StatData pirateStats = pirateInfo.DefaultStats;
        bonusStats = new StatData();
        healthValue = rootElement.Q<Label>(nameInfo.HealthStatValueName);
        healthBonus = rootElement.Q<Label>(nameInfo.HealthStatBonusName);
        speedValue = rootElement.Q<Label>(nameInfo.SpeedStatValueName);
        speedBonus = rootElement.Q<Label>(nameInfo.SpeedStatBonusName);
        attackValue = rootElement.Q<Label>(nameInfo.AttackStatValueName);
        attackBonus = rootElement.Q<Label>(nameInfo.AttackStatBonusName);
        rangeValue = rootElement.Q<Label>(nameInfo.RangeStatValueName);
        rangeBonus = rootElement.Q<Label>(nameInfo.RangeStatBonusName);
        setStatValues(pirateStats);
    }

    private void setStatValues(StatData dataToSet)
    {
        healthValue.text = dataToSet.Health.ToString();
        speedValue.text = dataToSet.Speed.ToString();
        attackValue.text = dataToSet.Attack.ToString();
        rangeValue.text = dataToSet.Range.ToString();
    }

    public void AddStatBonus(StatData newBonus, StatData oldBonus)
    {
        bonusStats -= oldBonus;
        bonusStats += newBonus;
        setSetBonusValues();
    }

    private void setSetBonusValues()
    {
        healthBonus.text = createBonusString(bonusStats.Health);
        speedBonus.text = createBonusString(bonusStats.Speed);
        attackBonus.text = createBonusString(bonusStats.Attack);
        rangeBonus.text = createBonusString(bonusStats.Range);
    }

    private string createBonusString(int bonusValue)
    {
        return string.Format("+ {0}", bonusValue);
    }

    public void AddSpecialEffect()
    {

    }
}
