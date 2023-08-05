using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BaseFieldData : IFieldData
{
    [SerializeField]
    private string name;
    public virtual string Name { get => name; }
    [SerializeField]
    protected int cost;
    public int Cost { get => cost; }
    [SerializeField]
    protected SpecialEffectType effectType = SpecialEffectType.None;
    public SpecialEffectType EffectType { get => effectType; }
    [SerializeField]
    protected StatType bonusStat = StatType.None;
    public StatType BonusStat { get => bonusStat; }
    [SerializeField]
    protected int bonusStatValue = 0;
    public int BonusStatValue { get => bonusStatValue; }
}
