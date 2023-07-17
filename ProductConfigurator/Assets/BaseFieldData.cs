using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BaseFieldData
{
    [SerializeField]
    private string name;
    public string Name { get => name; }
    [SerializeField]
    private int cost;
    public int Cost { get => cost; }
    [SerializeField]
    private SpecialEffectType effectType = SpecialEffectType.None;
    public SpecialEffectType EffectType { get => effectType; }
    [SerializeField]
    private StatType bonusStat = StatType.None;
    public StatType BonusStat { get => bonusStat; }
    [SerializeField]
    private int bonusStatValue = 0;
    public int BonusStatValue { get => bonusStatValue; }
    public SelectorFieldClassManager ClassManager;
}
