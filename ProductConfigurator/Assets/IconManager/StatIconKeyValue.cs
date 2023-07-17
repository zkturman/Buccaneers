using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatIconKeyValue
{
    [SerializeField]
    private StatType type;
    public StatType Type { get => type; }
    [SerializeField]
    private Sprite value;
    public Sprite Value { get => value; }
}
