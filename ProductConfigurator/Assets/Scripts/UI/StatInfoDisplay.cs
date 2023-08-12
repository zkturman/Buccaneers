using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class StatInfoDisplay : MonoBehaviour
{
    [SerializeField]
    private PirateCharacter pirateInfo;
    private StatData bonusStats;
    private Dictionary<SpecialEffectType, int> specialEffectTracker;
    private Label healthValue;
    private Label healthBonus;
    private Label speedValue;
    private Label speedBonus;
    private Label attackValue;
    private Label attackBonus;
    private Label rangeValue;
    private Label rangeBonus;
    private Label specialEffectList;
    private void Awake()
    {
        //bonusStats = new StatData();
    }
    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        StatInfoNameManager nameInfo = StatInfoNameManager.Names;
        StatData pirateStats = pirateInfo.DefaultStats;
        specialEffectTracker = SpecialEffect.GenerateCounterMap();
        bonusStats = new StatData();
        healthValue = rootElement.Q<Label>(nameInfo.HealthStatValueName);
        healthBonus = rootElement.Q<Label>(nameInfo.HealthStatBonusName);
        speedValue = rootElement.Q<Label>(nameInfo.SpeedStatValueName);
        speedBonus = rootElement.Q<Label>(nameInfo.SpeedStatBonusName);
        attackValue = rootElement.Q<Label>(nameInfo.AttackStatValueName);
        attackBonus = rootElement.Q<Label>(nameInfo.AttackStatBonusName);
        rangeValue = rootElement.Q<Label>(nameInfo.RangeStatValueName);
        rangeBonus = rootElement.Q<Label>(nameInfo.RangeStatBonusName);
        specialEffectList = rootElement.Q<Label>(nameInfo.SpecialEffectList);
        setStatValues(pirateStats);
        displaySpecialEffects();
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
        string bonusText = string.Empty;
        if (bonusValue > 0)
        {
            bonusText = string.Format("+ {0}", bonusValue);
        }
        return bonusText;
    }

    public void AddSpecialEffect(SpecialEffectType typeToAdd, SpecialEffectType typeToRemove)
    {
        specialEffectTracker[typeToRemove] -= 1;
        specialEffectTracker[typeToAdd] += 1;
        displaySpecialEffects();
    }

    private void displaySpecialEffects()
    {
        List<SpecialEffectType> effectKeys = new List<SpecialEffectType>(specialEffectTracker.Keys);
        List<SpecialEffectType> effectsToDisplay = new List<SpecialEffectType>(); 
        for (int i = 0; i < effectKeys.Count; i++)
        {
            int effectCount = specialEffectTracker[effectKeys[i]];
            if (effectCount > 0)
            {
                effectsToDisplay.Add(effectKeys[i]);
            }
        }
        specialEffectList.text = createEffectsDisplay(effectsToDisplay);
    }

    private string createEffectsDisplay(List<SpecialEffectType> effectsToDisplay)
    {
        StringBuilder effectBuilder = new StringBuilder();
        if (effectsToDisplay.Count == 0)
        {
            effectBuilder.AppendLine(createEffectLine(SpecialEffectType.None));
        }
        for (int i = 0; i < effectsToDisplay.Count; i++)
        {
            if (effectsToDisplay[i] != SpecialEffectType.None)
            {
                effectBuilder.AppendLine(createEffectLine(effectsToDisplay[i]));
            }
        }
        return effectBuilder.ToString();
    }

    private string createEffectLine(SpecialEffectType effectToGenerate)
    {
        return string.Format("- {0}", SpecialEffect.TypeToText(effectToGenerate));
    }
}
