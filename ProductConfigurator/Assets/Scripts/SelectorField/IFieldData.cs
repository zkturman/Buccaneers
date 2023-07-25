using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFieldData
{
    public string Name { get; }
    public int Cost { get; }
    public SpecialEffectType EffectType { get; }
    public StatType BonusStat { get; }
    public int BonusStatValue { get; }
}
