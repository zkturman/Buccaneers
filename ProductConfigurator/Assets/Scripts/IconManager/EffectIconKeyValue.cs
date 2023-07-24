using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EffectIconKeyValue
{
    [SerializeField]
    private SpecialEffectType type;
    public SpecialEffectType Type { get => type; }
    [SerializeField]
    private Sprite value;
    public Sprite Value { get => value; }
}
