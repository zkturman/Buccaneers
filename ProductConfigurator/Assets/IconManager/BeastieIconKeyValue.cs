using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BeastieIconKeyValue
{
    [SerializeField]
    private BeastieType type;
    public BeastieType Type { get => type; }
    [SerializeField]
    private Sprite value;
    public Sprite Value { get => value; }
}
